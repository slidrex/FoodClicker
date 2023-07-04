using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialScreen : MenuScreenController
{
    [SerializeField] private Transform _friendList;
    [SerializeField] private Transform _topList;
    [SerializeField] private Transform _friendAddMenu;
    [SerializeField] private Transform _friendRequestMenu;
    protected override void OnScreenLoaded(ScreenManager.Screen screenSpefication)
    {
        switch (screenSpefication)
        {
            case ScreenManager.Screen.SOCIAL_FRIENDS:
                _friendList.gameObject.SetActive(true); return;
            case ScreenManager.Screen.SOCIAL_TOP:
                _topList.gameObject.SetActive(true); return;
            case ScreenManager.Screen.SOCIAL_FRIENDS_REQUESTS:
                _friendRequestMenu.gameObject.SetActive(true); return;
            case ScreenManager.Screen.SOCIAL_FRIENDS_ADD_MENU:
                _friendAddMenu.gameObject.SetActive(true); return;
        }
    }
    protected override void OnScreenUnloaded(ScreenManager.Screen screenSpefication)
    {
        switch (screenSpefication)
        {
            case ScreenManager.Screen.SOCIAL_FRIENDS:
                _friendList.gameObject.SetActive(false); return;
            case ScreenManager.Screen.SOCIAL_TOP:
                _topList.gameObject.SetActive(false); return;
            case ScreenManager.Screen.SOCIAL_FRIENDS_REQUESTS:
                _friendRequestMenu.gameObject.SetActive(false); return;
            case ScreenManager.Screen.SOCIAL_FRIENDS_ADD_MENU:
                _friendAddMenu.gameObject.SetActive(false); return;
        }
    }
}
