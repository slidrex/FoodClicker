using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CosmeticsRequestController;

public class PlayerProfileRequestController
{
    public class PlayerProfileModel
    {
        public string RegistrationDate { get; set; }
        public string Email { get; set; }
        public long UserId { get; set; }
    }
    public PlayerProfileModel GetMyProfile()
    {
        var req = RestController.GetRequestMessage($"{RequestsCompositeRoot.BASE_URL}game/social/profile/get_my_profile");
        req.SendWebRequest();
        while (!req.isDone) { }
        if (req.responseCode != 200) return null;
        return JsonConvert.DeserializeObject<PlayerProfileModel>(req.downloadHandler.text);
    }
}
