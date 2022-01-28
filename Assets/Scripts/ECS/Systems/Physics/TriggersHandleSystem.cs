using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class TriggersHandleSystem : ReactiveSystem<InputEntity>
{
    private const string x2BoostName = "x2";
    private const string x3BoostName = "x3";
    private const string plus10BoostName = "Plus10";
    private const string plus15BoostName = "Plus15";
    private const string plus30BoostName = "Plus30";
    private const string plus40BoostName = "Plus40";
    private const string MortalObstacleTagName = "Mortal Obstacle";
    private Contexts _contexts;
    public TriggersHandleSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.TriggerEnter);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasTriggerEnter;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var entity in entities)
        {
            var triggeredEntity = (GameEntity)entity.triggerEnter.entity;
            switch (entity.triggerEnter.TagName)
            {
                case MortalObstacleTagName:
                    triggeredEntity.isDead = true;
                    break;
                case x2BoostName:
                    { 
                        var countEntity = _contexts.game.GetGroup(GameMatcher.PeopleCount).GetSingleEntity();
                        var resultPeopleAdd = countEntity.peopleCount.Value;
                        var peopleAddEntity = _contexts.game.CreateEntity();
                        peopleAddEntity.AddPeopleAdd(resultPeopleAdd);
                    }
                    break;
                case x3BoostName:
                    {
                        var countEntity = _contexts.game.GetGroup(GameMatcher.PeopleCount).GetSingleEntity();
                        var resultPeopleAdd = countEntity.peopleCount.Value * 2;
                        var peopleAddEntity = _contexts.game.CreateEntity();
                        peopleAddEntity.AddPeopleAdd(resultPeopleAdd);
                    }
                    break;
                case plus10BoostName:
                    {
                        var resultPeopleAdd = 10;
                        var peopleAddEntity = _contexts.game.CreateEntity();
                        peopleAddEntity.AddPeopleAdd(resultPeopleAdd);
                    }
                    break;
                case plus15BoostName:
                    {
                        var resultPeopleAdd = 15;
                        var peopleAddEntity = _contexts.game.CreateEntity();
                        peopleAddEntity.AddPeopleAdd(resultPeopleAdd);
                    }
                    break;
                case plus30BoostName:
                    {
                        var resultPeopleAdd = 30;
                        var peopleAddEntity = _contexts.game.CreateEntity();
                        peopleAddEntity.AddPeopleAdd(resultPeopleAdd);
                    }
                    break;
                case plus40BoostName:
                    {
                        var resultPeopleAdd = 40;
                        var peopleAddEntity = _contexts.game.CreateEntity();
                        peopleAddEntity.AddPeopleAdd(resultPeopleAdd);
                    }
                    break;
                default:
                    break;
            }
            entity.isPhysicUsed = true;
        }
    }
}
