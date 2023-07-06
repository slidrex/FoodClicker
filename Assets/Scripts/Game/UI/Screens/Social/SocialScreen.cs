using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialScreen : MenuScreenController
{
    [SerializeField] private Transform _friendList;
    [SerializeField] private LeaderFeed _leaderFeed;
    [SerializeField] private Transform _friendAddMenu;
    [SerializeField] private Transform _friendRequestMenu;
    protected override void OnScreenLoaded(ScreenManager.Screen screenSpefication)
    {
        switch (screenSpefication)
        {
            case ScreenManager.Screen.SOCIAL_FRIENDS:
                _friendList.gameObject.SetActive(true); return;
            case ScreenManager.Screen.SOCIAL_TOP:
                _leaderFeed.gameObject.SetActive(true);
                var data = ModelToData(GameRequestsCompositeRoot.Instance.LeadersRequestController.GetGoldLeaders());
                _leaderFeed.FillFeed(data);
                return;
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
                _leaderFeed.gameObject.SetActive(false); return;
            case ScreenManager.Screen.SOCIAL_FRIENDS_REQUESTS:
                _friendRequestMenu.gameObject.SetActive(false); return;
            case ScreenManager.Screen.SOCIAL_FRIENDS_ADD_MENU:
                _friendAddMenu.gameObject.SetActive(false); return;
        }
    }
    private LeaderFeed.LeaderFeedElementData[] ModelToData(List<LeadersRequestController.MoneyLeaderModel> models)
    {
        var elementList = new List<LeaderFeed.LeaderFeedElementData>();
        for(int i = 0; i < models.Count; i++)
        {
            var element = new LeaderFeed.LeaderFeedElementData(models[i], i + 1);

            elementList.Add(element);
        }
        return elementList.ToArray();
    }
}
