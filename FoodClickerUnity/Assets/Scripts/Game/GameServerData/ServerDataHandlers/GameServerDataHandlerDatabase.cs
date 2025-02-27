using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameServerDataHandlerDatabase : MonoBehaviour
{
    public UpgradeDataHandler UpgradeDataHandler;
    public CosmeticsDataHandler CosmeticsDataHandler;
    private void Awake()
    {
        UpgradeDataHandler.ConfigureDatabase();
        CosmeticsDataHandler.Configure();
    }
}
