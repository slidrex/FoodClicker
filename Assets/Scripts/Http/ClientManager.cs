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
    public static string AUTH_TOKEN { get; private set; } = "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJmaHBzZHNkdnhAZ21haWwuY29tIiwiZXhwIjoxNjg5MjM5OTI5fQ.5rDNn-aVNvy4UOmF9l_980tYQn-vwntET9tuOQ0l-Nk";
    public static void SetAuthenticationToken(string token)
    {
        AUTH_TOKEN = token;
    }
}
