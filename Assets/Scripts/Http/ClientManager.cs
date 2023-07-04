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
    public static string AUTH_TOKEN { get; private set; } = "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJkaW5hbWlrZXI0QGdtYWlsLmNvbSIsImV4cCI6MTY4ODkwMzc3MX0.QGYkgT7GyQRUInZ5nRTpTmkwtYOa0pcvYSbjHi2QHPc";
    public static void SetAuthenticationToken(string token)
    {
        AUTH_TOKEN = token;
    }
}
