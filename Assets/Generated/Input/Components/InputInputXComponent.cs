//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity inputXEntity { get { return GetGroup(InputMatcher.InputX).GetSingleEntity(); } }
    public InputXComponent inputX { get { return inputXEntity.inputX; } }
    public bool hasInputX { get { return inputXEntity != null; } }

    public InputEntity SetInputX(float newValue) {
        if (hasInputX) {
            throw new Entitas.EntitasException("Could not set InputX!\n" + this + " already has an entity with InputXComponent!",
                "You should check if the context already has a inputXEntity before setting it or use context.ReplaceInputX().");
        }
        var entity = CreateEntity();
        entity.AddInputX(newValue);
        return entity;
    }

    public void ReplaceInputX(float newValue) {
        var entity = inputXEntity;
        if (entity == null) {
            entity = SetInputX(newValue);
        } else {
            entity.ReplaceInputX(newValue);
        }
    }

    public void RemoveInputX() {
        inputXEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public InputXComponent inputX { get { return (InputXComponent)GetComponent(InputComponentsLookup.InputX); } }
    public bool hasInputX { get { return HasComponent(InputComponentsLookup.InputX); } }

    public void AddInputX(float newValue) {
        var index = InputComponentsLookup.InputX;
        var component = (InputXComponent)CreateComponent(index, typeof(InputXComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceInputX(float newValue) {
        var index = InputComponentsLookup.InputX;
        var component = (InputXComponent)CreateComponent(index, typeof(InputXComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveInputX() {
        RemoveComponent(InputComponentsLookup.InputX);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherInputX;

    public static Entitas.IMatcher<InputEntity> InputX {
        get {
            if (_matcherInputX == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputX);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputX = matcher;
            }

            return _matcherInputX;
        }
    }
}
