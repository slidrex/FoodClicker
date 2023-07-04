using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfiguration : MonoBehaviour
{
    private void Start()
    {
        var stats = GameRequestsCompositeRoot.Instance.PlayerStatRequestHandler.GetPlayerStats();
        GameCompositeRoot.Instance.StatView.InsertProductionView(stats);
    }
}
