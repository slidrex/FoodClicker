using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ShopRequestController
{
    public struct PlayerMoneyResponse
    {
        public int userMoney { get; set; }
    }
    [Serializable]
    public class UpgradeResponse
    {
        public PlayerStatRequestHandler.PlayerStatResponse Stats;
        public UpgradeDataModel Model;
    }
    public PlayerMoneyResponse PerformClick()
    {
        var req = RestController.PatchRequestMessage("http://localhost:8080/api/v0/game/currency/perform_click");
        req.SendWebRequest();
        while (!req.isDone) { }
        return JsonConvert.DeserializeObject<PlayerMoneyResponse>(req.downloadHandler.text);
    }
    public PlayerMoneyResponse CompleteCycle() 
    {
        var req = RestController.PatchRequestMessage("http://localhost:8080/api/v0/game/currency/complete_cycle");
        req.SendWebRequest();
        while (!req.isDone) { }
        return JsonConvert.DeserializeObject<PlayerMoneyResponse>(req.downloadHandler.text);
    }
    public UpgradeTemplate[] GetUpgradeTemplates()
    {
        var req = RestController.GetRequestMessage("http://localhost:8080/api/v0/game/shop/production/get_production_templates");
        req.SendWebRequest();
        while (!req.isDone) { }
        return JsonConvert.DeserializeObject<UpgradeTemplate[]>(req.downloadHandler.text);
    }
    public UpgradeDataModel[] GetPlayerProduction()
    {
        var req = RestController.GetRequestMessage("http://localhost:8080/api/v0/game/shop/production/get_player_production");
        req.SendWebRequest();
        while (!req.isDone) { }
        return JsonConvert.DeserializeObject<UpgradeDataModel[]>(req.downloadHandler.text);
    }
    public UpgradeResponse RequestUpgrade(ushort uid)
    {
        var req = RestController.PatchRequestMessage($"http://localhost:8080/api/v0/game/shop/production/upgrade_production/{uid}");
        req.SendWebRequest();
        while (!req.isDone) { }
        return req.responseCode == 200 ? JsonConvert.DeserializeObject<UpgradeResponse>(req.downloadHandler.text) : null;
    }
}
