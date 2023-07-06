using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Android.Gradle;
using UnityEditor.PackageManager;
using UnityEngine;
using static PlayerStatRequestHandler;

public class CosmeticsRequestController
{
    public class CosmeticsGroupElement
    {
        public int ItemId { get; set; }
        public int Price { get; set; }
        public int MinPrestige { get; set; }
    }
    public class PlayerCosmeticsGroupModel
    {
        public int EquippedItemId;
        public List<CosmeticsGroupedItemModel> Items;
        public class CosmeticsGroupedItemModel
        {
            public int ItemId;
        }
    }
    public class PlayerCosmeticsModel
    {

        public int GroupId { get; set; }
        public int ItemId { get; set; }
        public PlayerCosmeticsModel(int groupId, int itemId)
        {
            GroupId = groupId;
            ItemId = itemId;
        }
    }
    public class BuyCosmeticsResponse
    {
        public PlayerCosmeticsModel Model { get; set; }
        public PlayerStatResponse Stats { get; set; }
    }
    public List<List<CosmeticsGroupElement>> GetAllCosmeticsTemplates()
    {
        var req = RestController.GetRequestMessage("http://localhost:8080/api/v0/game/shop/cosmetics/get_all_items");
        req.SendWebRequest();
        while (!req.isDone) { }

        return JsonConvert.DeserializeObject<List<List<CosmeticsGroupElement>>>(req.downloadHandler.text);
    }
    public PlayerCosmeticsGroupModel[] GetPlayerCosmetics()
    {
        var req = RestController.GetRequestMessage("http://localhost:8080/api/v0/game/shop/cosmetics/get_all_player_cosmetics");
        req.SendWebRequest();
        while (!req.isDone) { }

        return JsonConvert.DeserializeObject<PlayerCosmeticsGroupModel[]>(req.downloadHandler.text);
    }
    public PlayerCosmeticsModel[] GetPlayerEquippedCosmetics()
    {
        var req = RestController.GetRequestMessage("http://localhost:8080/api/v0/game/shop/cosmetics/get_player_equipped_cosmetics");
        req.SendWebRequest();
        while (!req.isDone) { }

        return JsonConvert.DeserializeObject<PlayerCosmeticsModel[]>(req.downloadHandler.text);
    }
    public class EquipCosmeticsRequest
    {
        public int groupId { get; set; }
        public int itemId { get; set; }

        public EquipCosmeticsRequest(int itemId, int groupId)
        {
            this.itemId = itemId;
            this.groupId = groupId;
        }
    }
    public class BuyCosmeticsRequest
    {
        public int groupId { get; set; }
        public int itemId { get; set; }

        public BuyCosmeticsRequest(int itemId, int groupId)
        {
            this.itemId = itemId;
            this.groupId = groupId;
        }
    }
    public PlayerCosmeticsModel EquipCosmetics(EquipCosmeticsRequest request)
    {
        string postData = JsonConvert.SerializeObject(request);

        using var req = RestController.PostRequestMessage("http://localhost:8080/api/v0/game/shop/cosmetics/equip_cosmetics", postData);
        
        req.SendWebRequest();
        
        while (!req.isDone) { }
        if (req.responseCode != 200) return null;
        return JsonConvert.DeserializeObject<PlayerCosmeticsModel>(req.downloadHandler.text);
    }
    public BuyCosmeticsResponse BuyCosmetics(BuyCosmeticsRequest request)
    {
        string postData = JsonConvert.SerializeObject(request);

        using var req = RestController.PostRequestMessage("http://localhost:8080/api/v0/game/shop/cosmetics/buy_cosmetics", postData);

        req.SendWebRequest();

        while (!req.isDone) { }
        if (req.responseCode != 200) return null;
        return JsonConvert.DeserializeObject<BuyCosmeticsResponse>(req.downloadHandler.text);
    }
}
