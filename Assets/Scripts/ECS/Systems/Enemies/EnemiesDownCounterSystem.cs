using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EnemiesDownCounterSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public EnemiesDownCounterSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Dead);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isEnemy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var countEntity = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.PeopleCount, GameMatcher.EnemiesCountPanel)).GetSingleEntity();
        countEntity.ReplacePeopleCount(countEntity.peopleCount.Value - entities.Count);
        
        if (countEntity.peopleCount.Value == 0)
        {
            var enemyGroupEntity = _contexts.game.GetGroup(GameMatcher.EnemyGroup).GetSingleEntity();
            enemyGroupEntity.isGroupDead = true;
        }       
    }
}
