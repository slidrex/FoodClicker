using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using static ShopRequestController;

public class AscentionRequestHandler
{
    public class PrestigeLevelResponse
    {
        public int PrestigeLevel { get; set; }
    }
    public class AscentionPriceResponse
    {
        public long Price { get; set; }
    }
    public AscentionPriceResponse GetAscentionPrice()
    {
        var req = RestController.GetRequestMessage($"{RequestsCompositeRoot.BASE_URL}game/ascention/get_ascention_price");
        req.SendWebRequest();
        while (!req.isDone) { }
        return JsonConvert.DeserializeObject<AscentionPriceResponse>(req.downloadHandler.text);
    }
    public PlayerStatRequestHandler.PlayerStatResponse DoPrestigeRequest()
    {
        var req = RestController.PatchRequestMessage($"{RequestsCompositeRoot.BASE_URL}game/ascention/do_prestige");
        req.SendWebRequest();
        while (!req.isDone) { }
        return JsonConvert.DeserializeObject<PlayerStatRequestHandler.PlayerStatResponse>(req.downloadHandler.text);
    }
    public PrestigeLevelResponse GetAscentionLevel()
    {
        var req = RestController.GetRequestMessage($"{RequestsCompositeRoot.BASE_URL}game/ascention/get_prestige_level");
        req.SendWebRequest();
        while (!req.isDone) { }
        return JsonConvert.DeserializeObject<PrestigeLevelResponse>(req.downloadHandler.text);
    }
}
