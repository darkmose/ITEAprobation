using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PositionListener : MonoBehaviour, IEventListener, IPositionListener
{
    private GameEntity _entity;

    public void OnPosition(GameEntity entity, Vector3 value)
    {
        transform.position = value;
    }

    public void RegisterListener(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddPositionListener(this);        
    }
}

public interface IEventListener 
{
    void RegisterListener(IEntity entity);
}
