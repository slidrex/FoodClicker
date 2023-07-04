using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRequestsCompositeRoot : MonoBehaviour
{
    public ShopRequestController ShopRequestController;
    public AscentionRequestHandler AscentionRequestHandler;
    public PlayerStatRequestHandler PlayerStatRequestHandler;
    public CosmeticsRequestController CosmeticsRequestController;
    public static GameRequestsCompositeRoot Instance;
    private void Awake()
    {
        Instance = this;
        ShopRequestController = new();
        AscentionRequestHandler = new();
        PlayerStatRequestHandler = new();
        CosmeticsRequestController = new();
    }
}
