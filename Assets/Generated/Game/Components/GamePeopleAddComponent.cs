//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PeopleAddComponent peopleAdd { get { return (PeopleAddComponent)GetComponent(GameComponentsLookup.PeopleAdd); } }
    public bool hasPeopleAdd { get { return HasComponent(GameComponentsLookup.PeopleAdd); } }

    public void AddPeopleAdd(int newValue) {
        var index = GameComponentsLookup.PeopleAdd;
        var component = (PeopleAddComponent)CreateComponent(index, typeof(PeopleAddComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePeopleAdd(int newValue) {
        var index = GameComponentsLookup.PeopleAdd;
        var component = (PeopleAddComponent)CreateComponent(index, typeof(PeopleAddComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePeopleAdd() {
        RemoveComponent(GameComponentsLookup.PeopleAdd);
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

    static Entitas.IMatcher<GameEntity> _matcherPeopleAdd;

    public static Entitas.IMatcher<GameEntity> PeopleAdd {
        get {
            if (_matcherPeopleAdd == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PeopleAdd);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPeopleAdd = matcher;
            }

            return _matcherPeopleAdd;
        }
    }
}
