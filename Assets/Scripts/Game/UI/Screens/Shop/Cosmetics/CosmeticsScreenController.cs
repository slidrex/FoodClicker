using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CosmeticsDataHandler;

public class CosmeticsScreenController : MenuScreenController
{
    private CosmeticsContentFeedGroup[] _cachedGroups;
    [SerializeField] private CosmeticsContentFeed cosmeticsFeed;
    protected override void OnScreenLoaded(ScreenManager.Screen screenSpefication)
    {
        if(screenSpefication == ScreenManager.Screen.COSMETICS_BACKGROUND)
        {
            cosmeticsFeed.FillFeed(_cachedGroups[0].Items);
        }
        else if(screenSpefication == ScreenManager.Screen.COSMETICS_FOOD_IMAGE)
        {
            cosmeticsFeed.FillFeed(_cachedGroups[1].Items);
        }
        var el = cosmeticsFeed.GetElements();
        for (int i = 0; i < el.Length; i++) el[i].OnWasClicked += OnFeedElementClicked;
    }
    protected override void OnScreenUnloaded(ScreenManager.Screen screenSpefication)
    {
        var el = cosmeticsFeed.GetElements();
        for (int i = 0; i < el.Length; i++) el[i].OnWasClicked -= OnFeedElementClicked;
    }
    public override void OnPlayerEnterGame()
    {
        UpdateFeed();
    }
    private void OnFeedElementClicked(CosmeticsContentFeedElement element)
    {
        var oldEquippedItemIndex = _cachedGroups[element.GroupId].GetEquippedItemIndex();
        var request = new CosmeticsRequestController.EquipCosmeticsRequest(element.ItemId, element.GroupId);
        var resp = GameRequestsCompositeRoot.Instance.CosmeticsRequestController.EquipCosmetics(request);
        if(resp != null)
        {
            cosmeticsFeed.GetElement(element.GroupId, oldEquippedItemIndex).SetEquipStatus(false);
            
            element.SetEquipStatus(true);
            DatabaseCompositeRoot.Instance.ServerHandlerDatabase.CosmeticsDataHandler.ApplyCosmetics(element.GroupId, element.ItemId);
            UpdateFeed();
        }

    }
    private void UpdateFeed()
    {
        var response = GameRequestsCompositeRoot.Instance.CosmeticsRequestController.GetPlayerCosmetics();
        _cachedGroups = DatabaseCompositeRoot.Instance.ServerHandlerDatabase.CosmeticsDataHandler.ModelToFeed(response);
    }
}
