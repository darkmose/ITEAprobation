using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PeopleUpCounterSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public PeopleUpCounterSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Player.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return !entity.isDead && entity.isPlayer;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var countEntity = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.PeopleCount, GameMatcher.CountPanel)).GetSingleEntity();

        foreach (var entity in entities)
        {
            countEntity.ReplacePeopleCount(countEntity.peopleCount.Value + 1);
        }
    }

}
