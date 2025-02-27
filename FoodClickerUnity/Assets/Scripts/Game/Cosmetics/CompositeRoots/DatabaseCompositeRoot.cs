using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseCompositeRoot : MonoBehaviour
{
    public ServerDataCosmticsDatabase CosmeticsDatabase;
    public GameServerDataHandlerDatabase ServerHandlerDatabase;
    public static DatabaseCompositeRoot Instance;
    private void Awake()
    {
        Instance = this;
    }
}
