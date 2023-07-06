using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyProfileScreen : MenuScreenController
{
    [SerializeField] private ProfileObject _profileObject;
    protected override void OnScreenLoaded(ScreenManager.Screen screenSpefication)
    {
        var response = GameRequestsCompositeRoot.Instance.PlayerProfileRequestHandler.GetMyProfile();
        _profileObject.InsertData(response);
    }
}
