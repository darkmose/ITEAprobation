using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class GameEntityDestroySystem : ITearDownSystem
{
    private Contexts _contexts; 
    public GameEntityDestroySystem(Contexts contexts)
    {
        _contexts = contexts;
    }


    public void TearDown()
    {
        var entities = _contexts.game.GetEntities();
        foreach (var entity in entities)
        {
            if (entity.hasView)
            {
                if (entity.view.Value != Camera.main)
                {
                    GameObject.Destroy(entity.view.Value);
                }
            }
            if (entity.hasPositionListener)
            {
                entity.RemovePositionListener();
            }
            if (entity.hasPeopleCountListener)
            {
                entity.RemovePeopleCountListener();
            }

            entity.RemoveAllComponents();
            entity.Destroy();
        }
    }
}
