using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRequestsCompositeRoot : MonoBehaviour
{
    public ShopRequestController ShopRequestController;
    public AscentionRequestHandler AscentionRequestHandler;
    public PlayerStatRequestHandler PlayerStatRequestHandler;
    public CosmeticsRequestController CosmeticsRequestController;
    public LeadersRequestController LeadersRequestController;
    public PlayerProfileRequestController PlayerProfileRequestHandler;
    public static GameRequestsCompositeRoot Instance;
    private void Awake()
    {
        Instance = this;
        LeadersRequestController = new();
        PlayerProfileRequestHandler = new();
        ShopRequestController = new();
        AscentionRequestHandler = new();
        PlayerStatRequestHandler = new();
        CosmeticsRequestController = new();
    }
}
