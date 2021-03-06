//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PeopleCountListenerComponent peopleCountListener { get { return (PeopleCountListenerComponent)GetComponent(GameComponentsLookup.PeopleCountListener); } }
    public bool hasPeopleCountListener { get { return HasComponent(GameComponentsLookup.PeopleCountListener); } }

    public void AddPeopleCountListener(System.Collections.Generic.List<IPeopleCountListener> newValue) {
        var index = GameComponentsLookup.PeopleCountListener;
        var component = (PeopleCountListenerComponent)CreateComponent(index, typeof(PeopleCountListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePeopleCountListener(System.Collections.Generic.List<IPeopleCountListener> newValue) {
        var index = GameComponentsLookup.PeopleCountListener;
        var component = (PeopleCountListenerComponent)CreateComponent(index, typeof(PeopleCountListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePeopleCountListener() {
        RemoveComponent(GameComponentsLookup.PeopleCountListener);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPeopleCountListener;

    public static Entitas.IMatcher<GameEntity> PeopleCountListener {
        get {
            if (_matcherPeopleCountListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PeopleCountListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPeopleCountListener = matcher;
            }

            return _matcherPeopleCountListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddPeopleCountListener(IPeopleCountListener value) {
        var listeners = hasPeopleCountListener
            ? peopleCountListener.value
            : new System.Collections.Generic.List<IPeopleCountListener>();
        listeners.Add(value);
        ReplacePeopleCountListener(listeners);
    }

    public void RemovePeopleCountListener(IPeopleCountListener value, bool removeComponentWhenEmpty = true) {
        var listeners = peopleCountListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemovePeopleCountListener();
        } else {
            ReplacePeopleCountListener(listeners);
        }
    }
}
