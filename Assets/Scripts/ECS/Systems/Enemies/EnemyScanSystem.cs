using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EnemyScanSystem : ReactiveSystem<GameEntity>
{
    private const float ScanDistance = 5f;
    private readonly Contexts _contexts;

    public EnemyScanSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPeopleGroup && !entity.isFighting;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var enemyGroupEntities = _contexts.game.GetEntities(GameMatcher.AllOf(GameMatcher.EnemyGroup, GameMatcher.Movable));
            for (int i = 0; i < enemyGroupEntities.Length; i++)
            {
                if (!enemyGroupEntities[i].isFighting)
                {
                    var distance = Vector3.Distance(entity.position.Value, enemyGroupEntities[i].position.Value);
                    if (distance < ScanDistance)
                    {
                        entity.isFighting = true;
                        enemyGroupEntities[i].isFighting = true;
                        entity.isMovable = false;
                        enemyGroupEntities[i].isMovable = false;
                    }
                }
            }
        }
    }
}
