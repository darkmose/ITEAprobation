using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class PeopleAddSystem : ReactiveSystem<GameEntity>
{
    private const string BluePeopleTagName = "BluePeople";
    private Contexts _contexts;
    private Transform _parentTransform;
    private GameConfig _gameConfig;
    public PeopleAddSystem(Contexts contexts, Transform parentTransform, GameConfig gameConfig) : base(contexts.game)
    {
        _contexts = contexts;
        _parentTransform = parentTransform;
        _gameConfig = gameConfig;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.PeopleAdd);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPeopleAdd;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var playersGroupEntity = _contexts.game.GetGroup(GameMatcher.PeopleGroup).GetSingleEntity();
        var countPlayersEntity = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.PeopleCount, GameMatcher.CountPanel)).GetSingleEntity();

        foreach (var entity in entities)
        {
            float angle = 0f;
            float angleStep = 360f / _gameConfig.peopleInRow;
            for (int i = 0; i < entity.peopleAdd.Value; i++)
            {
                var gameEntity = _contexts.game.CreateEntity();
                var gameObj = ObjectPooler.GetPooledGameObject(BluePeopleTagName);
                gameObj.transform.SetParent(_parentTransform);
                var position = GetAnglePos(playersGroupEntity, ref angle, angleStep, countPlayersEntity.peopleCount.Value + i);
                gameEntity.AddPosition(position);
                gameObj.Link(gameEntity);
                gameEntity.AddView(gameObj);
                gameEntity.isMovable = true;
                gameEntity.isPlayer = true;

                if (gameObj.TryGetComponent(out IEventListener eventListenerr))
                {
                    eventListenerr.RegisterListener(gameEntity);
                }
            }
            entity.isDestroy = true;
        }
    }

    private Vector3 GetAnglePos(GameEntity groupEntity, ref float angle, float enemiesAngleStep, int playerCount)
    {
        var groupRadius = 0f;
        var rowsCount = playerCount / _gameConfig.peopleInRow;
        var peopleRest = playerCount - (playerCount * _gameConfig.peopleInRow);

        if (peopleRest == 0)
        {
            groupRadius = _gameConfig.groupRadiusStep * rowsCount;
        }
        else
        {
            groupRadius = _gameConfig.groupRadiusStep * (rowsCount + 1);
        }

        var centerPos = groupEntity.position.Value;
        var angleResult = angle * Mathf.Deg2Rad;
        var x = Mathf.Cos(angleResult) * groupRadius + centerPos.x;
        var z = Mathf.Sin(angleResult) * groupRadius + centerPos.z;
        var position = new Vector3(x, centerPos.y, z);
        angle += enemiesAngleStep;

        return position;
    }

}


