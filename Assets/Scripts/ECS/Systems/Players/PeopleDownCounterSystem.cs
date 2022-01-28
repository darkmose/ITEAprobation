using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PeopleDownCounterSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public PeopleDownCounterSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Dead.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPlayer;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var countEntity = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.PeopleCount, GameMatcher.CountPanel)).GetSingleEntity();

        countEntity.ReplacePeopleCount(countEntity.peopleCount.Value - entities.Count);
        if (countEntity.peopleCount.Value == 0)
        {
            var groupEntity = _contexts.game.GetGroup(GameMatcher.PeopleGroup).GetSingleEntity();
            groupEntity.isGroupDead = true;
            return;
        }
        
    }

}
