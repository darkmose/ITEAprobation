using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine.SceneManagement;

[Input]
public class ColliderCollisionComponent : IComponent
{
    public GameEntity first;
    public GameEntity second;
}

[Input]
public class TriggerEnterComponent : IComponent
{
    public IEntity entity;
    public string TagName;
}

[Input, Unique]
public class InputXComponent : IComponent
{
    public float value;
}

[Input]
public class UsedComponent : IComponent 
{ 
}

[Input]
public class PhysicUsedComponent : IComponent 
{ 
}

[Input]
public class RetryButtonComponent : IComponent
{
    public Scene scene;
}

[Input]
public class MainMenuButtonComponent : IComponent
{
    public Scene mainMenuScene;
}

[Input]
public class InputCleanupComponent : IComponent
{ }


