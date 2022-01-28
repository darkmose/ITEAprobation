using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PeopleGroupMoveSystem : IExecuteSystem
{
    private Contexts _contexts;
    private GameConfig _gameConfig;

    public PeopleGroupMoveSystem(Contexts contexts, GameConfig gameConfig)
    {
        _contexts = contexts;
        _gameConfig = gameConfig;
    }

    public void Execute()
    {
        var group = _contexts.game.GetGroup(GameMatcher.PeopleGroup);
        var entities = group.GetEntities();

        foreach (var entity in entities)
        {
            if (entity.isMovable)
            {
                var pos = entity.view.Value.transform.position;
                pos.z += _gameConfig.playerSpeed * Time.deltaTime;
                entity.ReplacePosition(pos);
            }
        }

    }
}

