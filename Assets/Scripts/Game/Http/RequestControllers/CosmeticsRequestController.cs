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
    public PlayerCosmeticsModel EquipCosmetics(EquipCosmeticsRequest request)
    {
        string postData = JsonConvert.SerializeObject(request);

        using var req = RestController.PostRequestMessage("http://localhost:8080/api/v0/game/shop/cosmetics/equip_cosmetics", postData);
        
        req.SendWebRequest();
        
        while (!req.isDone) { }
        return JsonConvert.DeserializeObject<PlayerCosmeticsModel>(req.downloadHandler.text);
    }
}
