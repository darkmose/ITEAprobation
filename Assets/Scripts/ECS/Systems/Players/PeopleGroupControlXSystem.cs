using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PeopleGroupControlXSystem : IExecuteSystem
{
    private const float PlayerGroupMovementBoundLeft = -4f;
    private const float PlayerGroupMovementBoundRight = 4.2f;
    private Contexts _contexts;
    private GameConfig _gameConfig;
    public PeopleGroupControlXSystem(Contexts contexts, GameConfig gameConfig)
    {
        _contexts = contexts;
        _gameConfig = gameConfig;
    }

    public void Execute()
    {
        var group = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.PeopleGroup, GameMatcher.Movable));
        var entities = group.GetEntities();

        foreach (var entity in entities)
        {
            if (_contexts.input.inputXEntity.hasInputX)
            {
                var xInput = _contexts.input.inputXEntity.inputX.value;
                entity.position.Value += Vector3.right * xInput * _gameConfig.playerHorizSpeed;
                entity.position.Value.x = Mathf.Clamp(entity.position.Value.x, PlayerGroupMovementBoundLeft, PlayerGroupMovementBoundRight);
            }
        }
    }
}
