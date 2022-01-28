using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FightStopSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public FightStopSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GroupDead);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isFighting;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var group = _contexts.game.GetGroup(GameMatcher.Fighting);
        var fightEntities = group.GetEntities();

        foreach (var fightEntity in fightEntities)
        {
            fightEntity.isFighting = false;
            fightEntity.isMovable = true;
        }
    }

}
