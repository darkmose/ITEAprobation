using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveToPointSystem : IExecuteSystem
{
    private const float Speed = 3f;
    private const float DistanceAccuracy = 0.01f;
    private Contexts _contexts;

    public MoveToPointSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var group = _contexts.game.GetGroup(GameMatcher.MoveToPoint);
        var entities = group.GetEntities();

        foreach (var entity in entities)
        {
            if (entity.hasMoveToPoint)
            {
                entity.ReplacePosition(Vector3.MoveTowards(entity.position.Value, entity.moveToPoint.Point, Time.deltaTime * Speed));
                if (Vector3.Distance(entity.position.Value, entity.moveToPoint.Point) < DistanceAccuracy)
                {
                    entity.RemoveMoveToPoint();
                }
            }
        }
    
    }
}
