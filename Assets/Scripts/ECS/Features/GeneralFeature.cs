using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GeneralFeature : Feature
{
    public GeneralFeature(Contexts contexts, GameConfig gameConfig) : base("General Feature")
    {
        Add(new FightingSystem(contexts, gameConfig));
        Add(new FightStopSystem(contexts));
        Add(new MoveToPointSystem(contexts));
        Add(new PositionEventSystem(contexts));
        Add(new PeopleCountEventSystem(contexts));
        Add(new GameOverSystem(contexts, gameConfig));
        Add(new RetryButtonHandlerSystem(contexts));
        Add(new MainMenuButtonHandlerSystem(contexts));

        Add(new GameEntityDestroySystem(contexts));
    }
}
