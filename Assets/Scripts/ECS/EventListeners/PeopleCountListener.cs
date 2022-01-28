using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PeopleCountListener : MonoBehaviour, IEventListener, IPeopleCountListener
{
    [SerializeField] private Text _peopleCountText;
    private GameEntity _entity;

    public void OnPeopleCount(GameEntity entity, int value)
    {
        _peopleCountText.text = value.ToString();
    }

    public void RegisterListener(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddPeopleCountListener(this);
    }
}
