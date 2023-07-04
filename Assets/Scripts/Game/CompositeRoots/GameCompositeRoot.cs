using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompositeRoot : MonoBehaviour
{
    public static GameCompositeRoot Instance { get; private set; }
    public CosmeticsController CosmeticsController;
    public StatView StatView;
    private void Awake()
    {
        Instance = this;
    }
}
