using System;
using System.Collections.Generic;
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
    }
    [Serializable]
    public class CosmeticsContentFeedGroup
    {
        public CosmeticsContentFeedGroupElement[] Items;
        public void SetItems(CosmeticsContentFeedGroupElement[] items)
        {
            Items = items;
        }
        public int GetEquippedItemIndex() { for(int i =0; i< Items.Length; i++) { if (Items[i].IsEquipped) return Items[i].Item.ItemId; } return -1; }
        [Serializable]
        public class CosmeticsContentFeedGroupElement
        {
            public bool IsAvailable;
            public bool IsEquipped;
            public int GroupId;
            public CosmeticsGroupItem Item;

            public CosmeticsContentFeedGroupElement(CosmeticsGroupItem item, int groupId, bool isAvailable)
            {
                Item = item;
                GroupId = groupId;
                IsEquipped = false;
                IsAvailable = isAvailable;
            }
            public static CosmeticsContentFeedGroupElement[] GroupItemToElement(CosmeticsGroupItem[] items, int groupId)
            {
                var responseItems = new CosmeticsContentFeedGroupElement[items.Length];
                for(int i = 0; i < items.Length; i++)
                {
                    responseItems[i] = new CosmeticsContentFeedGroupElement(items[i], groupId, false);
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
                currentGroup.Items[internId].Price = baseGroupElements[groupId][itemId].Price;
            }
        }
    }
    public void ApplyCosmetics(int groupId, int itemId)
    {
        _databaseGroups[groupId].CosmeticsHandlerDatabase.ApplyCosmetics(itemId);
    }
    private CosmeticsContentFeedGroup[] GetDefaultFeed()
    {
        var list = new CosmeticsContentFeedGroup[_databaseGroups.Count];
        for(int groupId = 0; groupId < _databaseGroups.Count; groupId++)
        {
            var group = _databaseGroups[groupId];

            var items = CosmeticsContentFeedGroup.CosmeticsContentFeedGroupElement.GroupItemToElement(group.Items, groupId);
            list[groupId] = new CosmeticsContentFeedGroup();
            list[groupId].SetItems(items);
        }
        return list;
    }
    public CosmeticsContentFeedGroup[] ModelToFeed(PlayerCosmeticsGroupModel[] playerCosmetics)
    {
        CosmeticsContentFeedGroup[] responseFeed = GetDefaultFeed();
        if (initialized == false) throw new Exception("Handling cosmetics data before initializing");

        for(int groupId = 0; groupId < playerCosmetics.Length; groupId++)
        {
            var responseFeedGroup = responseFeed[groupId];
            var playerGroup = playerCosmetics[groupId];
            responseFeedGroup.Items[playerGroup.EquippedItemId].IsEquipped = true;
            for(int playerItem = 0; playerItem < playerGroup.Items.Count; playerItem++)
            {
                var newAvailableSlot = playerGroup.Items[playerItem];
                responseFeedGroup.Items[newAvailableSlot.ItemId].IsAvailable = true;
            }
        }

        return responseFeed;
    }
}
