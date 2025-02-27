using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompositeRoot : MonoBehaviour
{
    public static GameCompositeRoot Instance { get; private set; }
    public CosmeticsController CosmeticsController;
    public AscensionController AscensionController;
    public StatController StatController;
    private void Awake()
    {
        StatController.Init();
        Instance = this;
    }
}
