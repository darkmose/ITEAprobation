using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class CollisionsHandleSystem : ReactiveSystem<InputEntity>
{
    public CollisionsHandleSystem(Contexts contexts) : base(contexts.input)
    {
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.ColliderCollision);
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.colliderCollision.first.isDead = true;
            entity.colliderCollision.second.isDead = true;
            entity.isPhysicUsed = true;
        }
    }
}

