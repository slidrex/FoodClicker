using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatRequestHandler
{
    public struct PlayerStatResponse
    {
        public int UserMoney { get; set; }
        public int Gps { get; set; }
        public int Gpc { get; set; }
    }
    public PlayerStatResponse GetPlayerStats()
    {
        var req = RestController.GetRequestMessage("http://localhost:8080/api/v0/game/shop/get_player_stats");
        req.SendWebRequest();
        while (!req.isDone) { }

        return JsonConvert.DeserializeObject<PlayerStatResponse>(req.downloadHandler.text);
    }
}
