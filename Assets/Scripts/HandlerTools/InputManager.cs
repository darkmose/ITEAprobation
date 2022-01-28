using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class InputManager : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const float AxisDeadZone = 0.01f;
    private Systems _systems;
    private Contexts _contexts;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        CreateSystems(_contexts);
    }

    private void Start()
    {
        _systems.Initialize();
        _contexts.input.SetInputX(0);
    }

    private void CreateSystems(Contexts contexts)
    {
        _systems = new Feature("InputSystem");
    }

    private void InputXScan() 
    {
        if (Input.GetAxis(HorizontalAxisName) > AxisDeadZone)
        {
            _contexts.input.inputXEntity.ReplaceInputX(Input.GetAxis(HorizontalAxisName));
        }
        else if (Input.GetAxis(HorizontalAxisName) < -AxisDeadZone)
        {
            _contexts.input.inputXEntity.ReplaceInputX(Input.GetAxis(HorizontalAxisName));
        }
        else
        {
            _contexts.input.inputXEntity.ReplaceInputX(0);
        }
    }

    private void Update()
    {
        InputXScan();
        _systems.Execute();   
        _systems.Cleanup();   
    }
}
