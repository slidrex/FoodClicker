using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfiguration : MonoBehaviour
{
    private void Start()
    {
        var stats = RequestsCompositeRoot.Instance.PlayerStatRequestHandler.GetPlayerStats();
        GameCompositeRoot.Instance.StatController.SetProductionStats(stats);
        GameCompositeRoot.Instance.CosmeticsController.SetupSavedCosmetics();
    }
}
