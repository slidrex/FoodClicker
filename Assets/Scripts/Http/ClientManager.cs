using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    public static ClientManager Instance { get; private set; }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    public static string AUTH_TOKEN { get; private set; }
    public static void SetAuthenticationToken(string token)
    {
        AUTH_TOKEN = token;
    }
}
