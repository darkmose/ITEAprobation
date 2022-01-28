using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.SceneManagement;

public class MainMenuButtonHandlerSystem : ReactiveSystem<InputEntity>
{
    public MainMenuButtonHandlerSystem(Contexts contexts) : base(contexts.input)
    {
        contexts.Reset();
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.MainMenuButton);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMainMenuButton;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var entity in entities)
        {
            var sceneIndex = entity.mainMenuButton.mainMenuScene.buildIndex;
            SceneManager.LoadScene(sceneIndex);
            entity.Destroy();
        }

    }
}
