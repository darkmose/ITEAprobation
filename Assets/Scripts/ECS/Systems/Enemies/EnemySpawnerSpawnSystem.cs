using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class EnemySpawnerSpawnSystem : ReactiveSystem<GameEntity>
{
    private const string EnemyTagName = "RedPeople";
    private Contexts _contexts;
    private GameConfig _gameConfig;

    public EnemySpawnerSpawnSystem(Contexts contexts, GameConfig gameConfig) : base(contexts.game)
    {
        _contexts = contexts;
        _gameConfig = gameConfig;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Spawner);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSpawner;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var groupEntity = _contexts.game.CreateEntity();
            var groupObject = new GameObject("EnemyGroup");
            var positionListener = groupObject.AddComponent<PositionListener>();
            groupEntity.AddView(groupObject);
            positionListener.RegisterListener(groupEntity);
            groupEntity.AddPosition(entity.spawner.spawnPoint.position);
            groupEntity.view.Value.transform.position = entity.spawner.spawnPoint.position;
            groupEntity.isEnemyGroup = true;
            groupEntity.isMovable = true;

            var countPanelEntity = PrepareCountPanel(groupEntity, groupObject);

            float angle = 0f;
            float enemiesAngleStep = 360 / _gameConfig.peopleInRow;


            for (int i = 0; i < entity.spawner.Count; i++)
            {
                var enemyObject = ObjectPooler.GetPooledGameObject(EnemyTagName);
                enemyObject.transform.SetParent(groupObject.transform);

                Vector3 position = GetAnglePos(groupEntity, ref angle, enemiesAngleStep, countPanelEntity.peopleCount.Value + i);

                var enemyEntity = _contexts.game.CreateEntity();
                enemyEntity.isEnemy = true;
                enemyEntity.AddView(enemyObject);
                enemyObject.Link(enemyEntity);
                enemyEntity.AddPosition(position);

                if (enemyObject.TryGetComponent(out IEventListener eventListener))
                {
                    eventListener.RegisterListener(enemyEntity);
                }

            }
            entity.isDestroy = true;
        }
    }

    private GameEntity PrepareCountPanel(GameEntity groupEntity, GameObject groupObject)
    {
        var countPanelEntity = _contexts.game.CreateEntity();
        var countPanelObject = GameObject.Instantiate(_gameConfig.peopleCountCanvasPrefab);
        var cameraObj = Camera.main;
        var forwardDirection = countPanelObject.transform.position - cameraObj.transform.position;
        var upwardDirection = Vector3.up;
        Quaternion rotation = Quaternion.LookRotation(forwardDirection, upwardDirection);
        countPanelObject.transform.rotation = rotation;
        countPanelEntity.AddView(countPanelObject);
        countPanelEntity.AddPosition(groupEntity.view.Value.transform.position);
        countPanelEntity.isMovable = true;
        countPanelEntity.isEnemiesCountPanel = true;

        var listeners = countPanelObject.GetComponents<IEventListener>();
        foreach (var listener in listeners)
        {
            listener.RegisterListener(countPanelEntity);
        }
        countPanelEntity.AddPeopleCount(0);
        countPanelEntity.AddFollow(groupObject);
        return countPanelEntity;
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
