using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class GameOverSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private GameConfig _gameConfig;

    public GameOverSystem(Contexts contexts, GameConfig gameConfig) : base(contexts.game)
    {
        _contexts = contexts;
        _gameConfig = gameConfig;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GroupDead);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPeopleGroup;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.view.Value.Unlink();
            entity.Destroy();
        }
       
        var endGameEntity = _contexts.game.CreateEntity();
        var endGameCanvas = GameObject.Instantiate(_gameConfig.endGameCanvas);
        endGameEntity.AddView(endGameCanvas);
        Time.timeScale = 0;
    }




}
