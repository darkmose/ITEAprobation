using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PhysicsCleanupSystem : ReactiveSystem<InputEntity>
{
    public PhysicsCleanupSystem(Contexts contexts) : base(contexts.input)
    {
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.PhysicUsed);
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.Destroy();
        }
    }
}
