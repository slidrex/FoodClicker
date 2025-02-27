using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerProfileRequestController;

public class LeadersRequestController
{
    public class MoneyLeaderModel
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public int PrestigeLevel { get; set; }
        public int Money { get; set; }
    }
    public List<MoneyLeaderModel> GetGoldLeaders()
    {
        var req = RestController.GetRequestMessage($"{RequestsCompositeRoot.BASE_URL}game/social/leader/get_gold_leaders");
        req.SendWebRequest();
        while (!req.isDone) { }
        if (req.responseCode != 200) return null;
        return JsonConvert.DeserializeObject<List<MoneyLeaderModel>>(req.downloadHandler.text);
    }
}
