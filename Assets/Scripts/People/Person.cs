using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class Person : MonoBehaviour
{
    private const string MortalObstacleTagName = "Mortal Obstacle";
    private const string EnemyTagName = "Enemy";
    private const string BoostsLayerName = "Boost";
    private const string x2BoostName = "x2";
    private const string x3BoostName = "x3";
    private const string plus10BoostName = "Plus10";
    private const string plus15BoostName = "Plus15";
    private const string plus30BoostName = "Plus30";
    private const string plus40BoostName = "Plus40";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(MortalObstacleTagName))
        {
            var link = gameObject.GetEntityLink();
            var entity = Contexts.sharedInstance.input.CreateEntity();
            entity.AddTriggerEnter(link.entity, MortalObstacleTagName);
        }
        if (LayerMask.LayerToName(other.gameObject.layer) == BoostsLayerName)
        {
            Debug.Log($"Bonus is {other.tag}");

            var fields = other.GetComponentInParent<GreenField>();
            fields.DestroyBoosters();
            var link = gameObject.GetEntityLink();
            var entity = Contexts.sharedInstance.input.CreateEntity();
            switch (other.tag)
            {
                case x2BoostName:
                    entity.AddTriggerEnter(link.entity, x2BoostName);
                    break;
                case x3BoostName:
                    entity.AddTriggerEnter(link.entity, x3BoostName);
                    break;
                case plus10BoostName:
                    entity.AddTriggerEnter(link.entity, plus10BoostName);
                    break;
                case plus15BoostName:
                    entity.AddTriggerEnter(link.entity, plus15BoostName);
                    break;
                case plus30BoostName:
                    entity.AddTriggerEnter(link.entity, plus30BoostName);
                    break;
                case plus40BoostName:
                    entity.AddTriggerEnter(link.entity, plus40BoostName);
                    break;
                case EnemyTagName:
                    var firstEntity = (GameEntity)gameObject.GetEntityLink().entity;
                    var secondEntity = (GameEntity)other.gameObject.GetEntityLink().entity;
                    var newEntity = Contexts.sharedInstance.input.CreateEntity();
                    newEntity.AddColliderCollision(firstEntity, secondEntity);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(EnemyTagName))
        {
            var firstEntity = (GameEntity)gameObject.GetEntityLink().entity;
            var secondEntity = (GameEntity)collision.collider.gameObject.GetEntityLink().entity;
            var entity = Contexts.sharedInstance.input.CreateEntity();
            entity.AddColliderCollision(firstEntity, secondEntity);
            if (TryGetComponent(out CapsuleCollider capsuleCollider))
            {
                capsuleCollider.enabled = false;
            }
        }
    }
}
