using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountPanelFeature : Feature
{
    public CountPanelFeature(Contexts contexts, GameConfig gameConfig) : base("Count Panel System")
    {
        Add(new CountPanelFollowSystem(contexts));
    }
}
