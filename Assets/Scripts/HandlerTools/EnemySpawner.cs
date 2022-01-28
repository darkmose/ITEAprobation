using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _count;
    private Contexts _contexts;

    private void Start()
    {
        _contexts = Contexts.sharedInstance;
    }

    private void TriggerSpawner(Transform target) 
    {
        var spawnerEntity = _contexts.game.CreateEntity();
        spawnerEntity.AddSpawner(_count, transform);

        var boxCollider = GetComponentInChildren<BoxCollider>();
        boxCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
         TriggerSpawner(other.transform.root);
    }
}
