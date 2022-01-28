using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class FightingSystem : ReactiveSystem<GameEntity>
{
    private const float HalfScale = 0.5f;
    private const float FullTurnAngle = 360f;
    private Contexts _contexts;
    private GameConfig _gameConfig;
    public FightingSystem(Contexts contexts, GameConfig gameConfig) : base(contexts.game)
    {
        _contexts = contexts;
        _gameConfig = gameConfig;
    }



    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Fighting);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isFighting;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (entities.Count == 2)
        {             
            Vector3 centerPos = Vector3.Lerp(entities[0].position.Value, entities[1].position.Value, HalfScale);
            var fightingPlayers = _contexts.game.GetEntities(GameMatcher.Player);
            var fightingEnemies = _contexts.game.GetEntities(GameMatcher.Enemy);

            var angle = 0f;
            var enemiesAngleStep = FullTurnAngle / fightingEnemies.Length;
            var playersAngleStep = FullTurnAngle / fightingPlayers.Length;

            foreach (var enemy in fightingEnemies)
            {
                var angleResult = angle * Mathf.Deg2Rad;
                var x = Mathf.Cos(angleResult) * _gameConfig.fightGroupRadius + centerPos.x;
                var z = Mathf.Sin(angleResult) * _gameConfig.fightGroupRadius + centerPos.z;
                var point = new Vector3(x, centerPos.y, z);
                angle += enemiesAngleStep;
                Vector3 position = enemy.view.Value.transform.position;
                enemy.ReplacePosition(position);
                enemy.ReplaceMoveToPoint(point);
            }
            foreach (var player in fightingPlayers)
            {
                var angleResult = angle * Mathf.Deg2Rad;
                var x = Mathf.Cos(angleResult) * _gameConfig.fightGroupRadius + centerPos.x;
                var z = Mathf.Sin(angleResult) * _gameConfig.fightGroupRadius + centerPos.z;
                var point = new Vector3(x, centerPos.y, z);
                angle += playersAngleStep;
                Vector3 position = player.view.Value.transform.position;
                player.ReplacePosition(position);
                player.ReplaceMoveToPoint(point);
            }               
        }        
    }

}
