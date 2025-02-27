using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestsCompositeRoot : MonoBehaviour
{
    public const string BASE_URL = "http://192.168.0.109:8080/api/v0/";
    public ShopRequestController ShopRequestController;
    public AscentionRequestHandler AscentionRequestHandler;
    public PlayerStatRequestHandler PlayerStatRequestHandler;
    public CosmeticsRequestController CosmeticsRequestController;
    public LeadersRequestController LeadersRequestController;
    public PlayerProfileRequestController PlayerProfileRequestHandler;
    public static RequestsCompositeRoot Instance;
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
