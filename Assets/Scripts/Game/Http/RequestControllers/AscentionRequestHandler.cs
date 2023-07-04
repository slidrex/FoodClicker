using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using static ShopRequestController;

public class AscentionRequestHandler
{
    public class AscentionPriceResponse
    {
        public long Price { get; set; }
    }
    public AscentionPriceResponse GetAscentionPrice()
    {
        var req = RestController.GetRequestMessage("http://localhost:8080/api/v0/game/ascention/get_ascention_price");
        req.SendWebRequest();
        while (!req.isDone) { }
        return JsonConvert.DeserializeObject<AscentionPriceResponse>(req.downloadHandler.text);
    }
    public PlayerStatRequestHandler.PlayerStatResponse DoPrestigeRequest()
    {
        var req = RestController.PatchRequestMessage("http://localhost:8080/api/v0/game/ascention/do_prestige");
        req.SendWebRequest();
        while (!req.isDone) { }
        return JsonConvert.DeserializeObject<PlayerStatRequestHandler.PlayerStatResponse>(req.downloadHandler.text);
    }
}
