using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.SceneManagement;

public class RetryButtonHandlerSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;
    public RetryButtonHandlerSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.RetryButton);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasRetryButton;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var gameEntities = _contexts.game.GetEntities();
        foreach (var entity in gameEntities)
        {
            entity.isDestroy = true;
        }

        foreach (var entity in entities)
        {
            entity.Destroy();
        }
    }
}
