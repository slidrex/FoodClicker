using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static CosmeticsDataHandler.CosmeticsDatabaseGroup;
using static CosmeticsRequestController;

[CreateAssetMenu(menuName = "Food Clicker/ID Data Handler/Shop/Cosmetics data handler")]
public sealed class CosmeticsDataHandler : ScriptableObject
{

    [Serializable]
    public class CosmeticsDatabaseGroup
    {
        public BaseServerCosmeticsDatabase CosmeticsHandlerDatabase;
        public CosmeticsGroupItem[] Items;
    }
    [Serializable]
    public class CosmeticsGroupItem
    {
        public string Name;
        public Sprite CosmeticsIcon;
        public int ItemId;
        [field: SerializeField] public int Price { get; set; }
        [field: SerializeField] public int MinPrestige { get; set; }
    }
    /// <summary>
    /// Sends to feed
    /// </summary>
    [Serializable]
    public class CosmeticsContentFeedGroup
    {
        [field: SerializeField] public Element[] Items { get; private set; }
        [field: SerializeField] public int EquippedItemId { get; private set; }
        public void SetEquippedItemId(int id)
        {
            EquippedItemId = id;
        }
        public CosmeticsContentFeedGroup(Element[] items)
        {
            Items = items;
            EquippedItemId = items.Where(x => x.Status == CosmeticsContentFeedElement.ElementStatus.EQUIPPED).Select(x => x.Item.ItemId).FirstOrDefault();
        }
        [Serializable]
        public class Element
        {
            public CosmeticsContentFeedElement.ElementStatus Status;
            public int GroupId;
            public CosmeticsGroupItem Item;

            public Element(CosmeticsGroupItem item, int groupId)
            {
                Item = item;
                GroupId = groupId;
                Status = CosmeticsContentFeedElement.ElementStatus.NOT_OWNED;
            }
            public static Element[] GroupItemToDefaultElement(CosmeticsGroupItem[] items, int groupId)
            {
                var responseItems = new Element[items.Length];
                for(int i = 0; i < items.Length; i++)
                {
                    responseItems[i] = new Element(items[i], groupId);
                }
                return responseItems;
            }
        }
    }
    private bool initialized;
    [SerializeField] private List<CosmeticsDatabaseGroup> _databaseGroups;
    public void Configure()
    {
        initialized = true;
        List<List<CosmeticsGroupElement>> baseGroupElements = GameRequestsCompositeRoot.Instance.CosmeticsRequestController.GetAllCosmeticsTemplates();

        for (int groupId = 0; groupId < baseGroupElements.Count; groupId++)
        {
            for(int itemId = 0; itemId < baseGroupElements[groupId].Count; itemId++)
            {
                int internId = itemId + 1;
                var currentGroup = _databaseGroups[groupId];
                if (currentGroup.Items[itemId].ItemId != itemId) throw new Exception("ID setup rule violation");
                var template = currentGroup.Items[internId];
                template.Price = baseGroupElements[groupId][itemId].Price;
                template.MinPrestige = baseGroupElements[groupId][itemId].MinPrestige;
            }
        }
    }
    public void ApplyAllDefaultCosmetics()
    {
        foreach(var db in _databaseGroups)
        {
            db.CosmeticsHandlerDatabase.ApplyCosmetics(0);
        }
    }
    public void ApplyCosmetics(int groupId, int itemId)
    {
        if(_databaseGroups.Count > groupId)
            _databaseGroups[groupId].CosmeticsHandlerDatabase.ApplyCosmetics(itemId);
    }
    private CosmeticsContentFeedGroup[] GetDefaultFeed()
    {
        var list = new CosmeticsContentFeedGroup[_databaseGroups.Count];
        for(int groupId = 0; groupId < _databaseGroups.Count; groupId++)
        {
            var group = _databaseGroups[groupId];

            var items = CosmeticsContentFeedGroup.Element.GroupItemToDefaultElement(group.Items, groupId);
            list[groupId] = new CosmeticsContentFeedGroup(items);
        }
        return list;
    }
    public void ActualizeGroupFeed(int groupId, CosmeticsContentFeed feed, CosmeticsContentFeedGroup[] groups)
    {
        if (feed.GetElements() == null) return;
        var statController = GameCompositeRoot.Instance.StatController;
        var updateGroup = groups[groupId];
        for(int i = 0; i < updateGroup.Items.Length; i++)
        {
            var item = updateGroup.Items[i];
            if(item.Status != CosmeticsContentFeedElement.ElementStatus.OWNED && item.Status != CosmeticsContentFeedElement.ElementStatus.EQUIPPED)
            {
                int price = item.Item.Price;
                bool isAffordable = statController.IsAffordable(price) && statController.HasEnoughPrestigeLevel(item.Item.MinPrestige);
                if (item.Status == CosmeticsContentFeedElement.ElementStatus.READY_TO_BUY && !isAffordable)
                {
                    SetElementStatus(groupId, item.Item.ItemId, CosmeticsContentFeedElement.ElementStatus.NOT_OWNED, feed, groups);
                }
                else if(item.Status == CosmeticsContentFeedElement.ElementStatus.NOT_OWNED && isAffordable)
                {
                    SetElementStatus(groupId, item.Item.ItemId, CosmeticsContentFeedElement.ElementStatus.READY_TO_BUY, feed, groups);
                }
            }
        }
        
    }
    public CosmeticsContentFeedGroup[] ModelToFeed(PlayerCosmeticsGroupModel[] playerCosmetics)
    {
        CosmeticsContentFeedGroup[] responseFeed = GetDefaultFeed();
        if (initialized == false) throw new Exception("Handling cosmetics data before initializing");
        
        for(int groupId = 0; groupId < playerCosmetics.Length; groupId++)
        {
            var responseFeedGroup = responseFeed[groupId];
            var playerGroup = playerCosmetics[groupId];
            if(playerGroup != null && playerGroup.Items != null)
                for(int playerItem = 0; playerItem < playerGroup.Items.Count; playerItem++)
                {
                    var newAvailableSlot = playerGroup.Items[playerItem];
                    responseFeedGroup.Items[newAvailableSlot.ItemId].Status = CosmeticsContentFeedElement.ElementStatus.OWNED;
                }
                responseFeedGroup.Items[playerGroup.EquippedItemId].Status = CosmeticsContentFeedElement.ElementStatus.EQUIPPED;
            responseFeedGroup.SetEquippedItemId(playerGroup.EquippedItemId);
        }

        return responseFeed;
    }
    public void SetElementStatus(int groupId, int itemId, CosmeticsContentFeedElement.ElementStatus status, CosmeticsContentFeed feed, CosmeticsContentFeedGroup[] groups)
    {
        var element = groups[groupId].Items[itemId];
        element.Status = status;
        if (status == CosmeticsContentFeedElement.ElementStatus.EQUIPPED) 
        {
            int oldEquippedItem = groups[groupId].EquippedItemId;
            groups[groupId].SetEquippedItemId(itemId);
            groups[groupId].Items[oldEquippedItem].Status = CosmeticsContentFeedElement.ElementStatus.OWNED;
            ApplyCosmetics(groupId, itemId);
            feed.GetElement(groupId, oldEquippedItem).SetElementStatus(CosmeticsContentFeedElement.ElementStatus.OWNED);
        }
        feed.GetElement(groupId, itemId).SetElementStatus(status);
    }
}