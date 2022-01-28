using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class PositionComponent : IComponent
{
    public Vector3 Value;
}

[Game]
public class ViewComponent : IComponent
{
    public GameObject Value;
}

[Game]
public class MovableComponent: IComponent
{
}

[Game]
public class DeadComponent: IComponent
{
}

[Game]
public class PlayerComponent: IComponent
{
}

[Game]
public class CameraComponent : IComponent 
{ 
}

[Game]
public class CountPanelComponent : IComponent 
{
}

[Game]
public class EnemiesCountPanelComponent : IComponent
{ }

[Game]
public class PeopleGroupComponent : IComponent
{ 
}

[Game]
public class DestroyComponent : IComponent
{ 
}

[Game, Event(EventTarget.Self)]
public class PeopleCountComponent : IComponent
{
    public int Value;
}

[Game]
public class PeopleAddComponent : IComponent 
{
    public int Value; 
}

[Game]
public class SpawnerComponent : IComponent
{
    public int Count;
    public Transform spawnPoint;
}

[Game]
public class MoveToPointComponent : IComponent 
{
    public Vector3 Point;
}

[Game]
public class EnemyComponent : IComponent
{ }

[Game]
public class EnemyGroupComponent : IComponent
{ }

[Game]
public class FightingComponent : IComponent
{ 
}

[Game]
public class FollowComponent : IComponent
{
    public GameObject FolowTarget;
}

[Game]
public class GroupDeadComponent : IComponent
{ }

[Game]
public class GameCleanupComponent : IComponent
{ }