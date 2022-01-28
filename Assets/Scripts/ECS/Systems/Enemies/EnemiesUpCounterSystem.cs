using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EnemiesUpCounterSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public EnemiesUpCounterSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Enemy.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isEnemy && !entity.isDead;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var countEntity = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.PeopleCount, GameMatcher.EnemiesCountPanel)).GetSingleEntity();

        foreach (var entity in entities)
        {
            countEntity.ReplacePeopleCount(countEntity.peopleCount.Value + 1);
        }
    }

}
