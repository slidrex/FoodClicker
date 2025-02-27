using UnityEngine;
using static CosmeticsDataHandler;
using static CosmeticsRequestController;

public class CosmeticsScreenController : MenuScreenController
{
    [SerializeField] private CosmeticsContentFeedGroup[] _cachedGroups;
    [SerializeField] private CosmeticsContentFeed cosmeticsFeed;
    private CosmeticsDataHandler _handler;
    private int _currentGroupId;
    public override void OnPlayerEnterGame() //Start
    {
        _handler = DatabaseCompositeRoot.Instance.ServerHandlerDatabase.CosmeticsDataHandler;
        UpdateFeedScript();
    }
    private void OnEnable()
    {
        GameCompositeRoot.Instance.AscensionController.OnAscension += OnAscension;
        GameCompositeRoot.Instance.StatController.OnMoneyChanged += OnMoneyChanged;
    }
    private void OnDisable()
    {
        GameCompositeRoot.Instance.AscensionController.OnAscension -= OnAscension;
        GameCompositeRoot.Instance.StatController.OnMoneyChanged -= OnMoneyChanged;
    }
    private void OnMoneyChanged()
    {
        _handler.ActualizeGroupFeed(_currentGroupId, cosmeticsFeed, _cachedGroups);
    }
    private void OnAscension()
    {
        UpdateFeedScript();
        _handler.ApplyAllDefaultCosmetics();
    }
    protected override void OnScreenLoaded(ScreenManager.Screen screenSpefication)
    {
        if(screenSpefication == ScreenManager.Screen.COSMETICS_BACKGROUND)
        {
            LoadConfig(0);
        }
        else if(screenSpefication == ScreenManager.Screen.COSMETICS_FOOD_IMAGE)
        {
            LoadConfig(1);
        }
        var el = cosmeticsFeed.GetElements();
        for (int i = 0; i < el.Length; i++) el[i].OnWasClicked += OnFeedElementClicked;
    }
    protected override void OnScreenUnloaded(ScreenManager.Screen screenSpefication)
    {
        var el = cosmeticsFeed.GetElements();
        for (int i = 0; i < el.Length; i++) el[i].OnWasClicked -= OnFeedElementClicked;
    }
    private void OnFeedElementClicked(CosmeticsContentFeedElement element)
    {
        int groupId = element.GroupId;
        var elementStatus = element.Status;
        int newItemIndex = element.ItemId;

        if(elementStatus == CosmeticsContentFeedElement.ElementStatus.READY_TO_BUY) BuyItem(groupId, newItemIndex);
        else if(elementStatus == CosmeticsContentFeedElement.ElementStatus.OWNED) EquipItem(groupId, newItemIndex);
    }
    private void EquipItem(int groupId, int newItemId)
    {
        var request = new EquipCosmeticsRequest(newItemId, groupId);
        var resp = RequestsCompositeRoot.Instance.CosmeticsRequestController.EquipCosmetics(request);
        if(resp != null)
        {
            _handler.SetElementStatus(groupId, newItemId, CosmeticsContentFeedElement.ElementStatus.EQUIPPED, cosmeticsFeed, _cachedGroups);
        }
    }
    private void BuyItem(int groupId, int newItemId)
    {
        var request = new BuyCosmeticsRequest(newItemId, groupId);
        var resp = RequestsCompositeRoot.Instance.CosmeticsRequestController.BuyCosmetics(request);
        if (resp != null)
        {
            GameCompositeRoot.Instance.StatController.SetProductionStats(resp.Stats);
            _handler.SetElementStatus(groupId, newItemId, CosmeticsContentFeedElement.ElementStatus.EQUIPPED, cosmeticsFeed, _cachedGroups);
        }
    }
    private void UpdateFeedScript()
    {
        var response = RequestsCompositeRoot.Instance.CosmeticsRequestController.GetPlayerCosmetics();
        _cachedGroups = _handler.ModelToFeed(response);
    }
    private void LoadConfig(int groupId)
    {
        cosmeticsFeed.FillFeed(_cachedGroups[groupId].Items);
        _handler.ActualizeGroupFeed(groupId, cosmeticsFeed, _cachedGroups);
        _currentGroupId = groupId;
    }
}
