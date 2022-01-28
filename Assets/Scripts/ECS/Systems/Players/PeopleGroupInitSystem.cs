using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class PeopleGroupInitSystem : IInitializeSystem
{
    private const string BluePeopleTagName = "BluePeople";
    private Contexts _contexts;
    private GameObject _peopleParent;
    private GameConfig _gameConfig;

    public PeopleGroupInitSystem(Contexts contexts, GameObject parent, GameConfig gameConfig)
    {
        _contexts = contexts;
        _peopleParent = parent;
        _gameConfig = gameConfig;
    }

    public void Initialize()
    {
        var groupEntity = _contexts.game.CreateEntity();
        groupEntity.isPeopleGroup = true;
        groupEntity.isMovable = true;
        groupEntity.ReplaceView(_peopleParent);
        _peopleParent.Link(groupEntity);

        if (_peopleParent.TryGetComponent(out IEventListener eventListener))
        {
            eventListener.RegisterListener(groupEntity);
        }
        
        var playerEntity = _contexts.game.CreateEntity();
        var gameObj = ObjectPooler.GetPooledGameObject(BluePeopleTagName);
        gameObj.transform.SetParent(groupEntity.view.Value.transform);
        gameObj.transform.localPosition = Vector3.zero;
        gameObj.Link(playerEntity);
        playerEntity.AddView(gameObj);
        playerEntity.isPlayer = true;
        playerEntity.AddPosition(groupEntity.view.Value.transform.position);

        if (gameObj.TryGetComponent(out IEventListener eventListenerr))
        {
            eventListenerr.RegisterListener(playerEntity);
        }

        var cameraObj = Camera.main.gameObject;
        var cameraEntity = _contexts.game.CreateEntity();
        cameraEntity.AddPosition(cameraObj.transform.position);
        cameraEntity.AddView(cameraObj);

        if (cameraObj.TryGetComponent(out IEventListener _eventListener))
        {
            _eventListener.RegisterListener(cameraEntity);
        }

        cameraEntity.isMovable = true;
        cameraEntity.isCamera = true;
        cameraEntity.AddFollow(_peopleParent);

        var countPanelEntity = _contexts.game.CreateEntity();

        var countPanelObject = GameObject.Instantiate(_gameConfig.peopleCountCanvasPrefab);
            
        var forwardDirection = countPanelObject.transform.position - cameraObj.transform.position;
        var upwardDirection = Vector3.up;
        Quaternion rotation = Quaternion.LookRotation(forwardDirection, upwardDirection);
        countPanelObject.transform.rotation = rotation;

        countPanelEntity.AddView(countPanelObject);
        countPanelEntity.AddPosition(_peopleParent.transform.position);
        countPanelEntity.isMovable = true;
        countPanelEntity.isCountPanel = true;
        var listeners = countPanelObject.GetComponents<IEventListener>();
        foreach (var listener in listeners)
        {
            listener.RegisterListener(countPanelEntity);
        }

        countPanelEntity.AddPeopleCount(0);
        countPanelEntity.AddFollow(_peopleParent);
        
    }

}
