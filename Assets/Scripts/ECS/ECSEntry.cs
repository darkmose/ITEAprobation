using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;
using UnityEngine.SceneManagement;

public class ECSEntry : MonoBehaviour
{
    [SerializeField] private Transform _peopleParentTransform;
    [SerializeField] private Transform _pooledObjectsRoot;
    [SerializeField] private GameConfig _gameConfig;
    private Contexts _contexts;
    private Systems _physicSystems;
    private Systems _generalSystems;
    private Systems _gameSystems;
    private List<Systems> _allSystems;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        CreateSystems(_contexts);
        SceneManager.sceneUnloaded += OnSceneUnload;
    }

    private void OnSceneUnload(Scene scene)
    {
        ResetAll();
    }

    private void Start()
    {
        InitializeAllSystems();
    }

    private void InitializeAllSystems()
    {
        foreach (var system in _allSystems)
        {
            system.Initialize();
        }
    }

    private void ExecuteAllSystems() 
    {
        foreach (var system in _allSystems)
        {
            system.Execute();
        }
    }

    private void CleanupAllSystems()
    {
        foreach (var system in _allSystems)
        {
            system.Cleanup();
        }
    }

    [ContextMenu("ResetALL")]
    public void Test() 
    {
        ResetAll();
    } 

    private void CreateSystems(Contexts contexts)
    {
        _allSystems = new List<Systems>();

        _physicSystems = new Feature("PhysicSystems");
        _physicSystems.Add(new PhysicFeature(contexts));
        _allSystems.Add(_physicSystems);

        _gameSystems = new Feature("GameSystems");
        _gameSystems.Add(new PeopleFeature(contexts, _peopleParentTransform, _pooledObjectsRoot, _gameConfig));
        _gameSystems.Add(new CameraFeature(contexts)); 
        _gameSystems.Add(new CountPanelFeature(contexts, _gameConfig));
        _gameSystems.Add(new EnemiesFeature(contexts, _gameConfig, _pooledObjectsRoot));
        _allSystems.Add(_gameSystems);

        _generalSystems = new Feature("GeneralSystems");
        _generalSystems.Add(new GeneralFeature(contexts, _gameConfig));
        _allSystems.Add(_generalSystems);
    }

    private void ResetAll() 
    {
        foreach (var systems in _allSystems)
        {
            systems.DeactivateReactiveSystems();
            systems.ClearReactiveSystems();
        }
        foreach (var systems in _allSystems)
        {
            systems.TearDown();
        }

        _contexts.Reset();
    }


    private void Update()
    {
        ExecuteAllSystems();
        CleanupAllSystems();
    }
}
