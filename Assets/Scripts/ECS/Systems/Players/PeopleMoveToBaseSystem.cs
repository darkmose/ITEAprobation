using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PeopleMoveToBaseSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private GameConfig _gameConfig;
    public PeopleMoveToBaseSystem(Contexts contexts, GameConfig gameConfig) : base(contexts.game)
    {
        _contexts = contexts;
        _gameConfig = gameConfig;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Fighting.Removed());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPeopleGroup;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var group = _contexts.game.GetGroup(GameMatcher.Player);
        var playerEntities = group.GetEntities();
        float angle = 0f;
        float angleStep = 360f / _gameConfig.peopleInRow;
        int index = 0;
        foreach (var player in playerEntities)
        {
            var pos = GetAnglePos(entities[0], ref angle, angleStep, playerEntities.Length + index);
            //player.ReplaceMoveToPoint(pos);            
            player.ReplacePosition(pos);            
            index++;
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
