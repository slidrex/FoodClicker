using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UpgradeFeedData //Data takes cell
{
    public string Name;
    public Sprite Sprite;
    public string Description;
    public int Quantity;
    public long Price;
    public ushort UpgradeID;

    public UpgradeFeedData(string name, Sprite sprite, string description, int level, long price, ushort upgradeID) : this()
    {
        Sprite = sprite;
        Name = name;
        Description = description;
        Quantity = level + 1;
        Price = price;
        UpgradeID = upgradeID;
    }
}
[Serializable]
public class UpgradeDataModel //Sent by server
{
    public ushort Uid { get; set; }
    public int Level { get; set; }
    public long NextLevelPrice { get; set; }
    public int Gps { get; set; }
    public int Gpc { get; set; }
}
[Serializable]
public struct UpgradeTemplate
{
    public int Uid { get; set; }
    public int Price { get; set; }
    public int BaseGpc { get; set; }
    public int BaseGps { get; set; }
}
[Serializable]
public class UpgradeFeedDataHandler //Meta data from local storage
{
    public ushort Uid;
    public string Name;
    public Sprite Sprite;
    public int BaseGpc { get; private set; }
    public int BaseGps { get; private set; }
    public int BasePrice { get; private set; }
    public void Configure(UpgradeTemplate template)
    {
        BaseGpc = template.BaseGpc;
        BaseGps = template.BaseGps;
        BasePrice = template.Price;
    }

}
public class UpgradeContentFeed : ContentFeed<UpgradeContentFeedElement, UpgradeFeedData>
{
    private void OnEnable()
    {
        foreach (var el in FeedElements) el.OnButtonClicked += OnFeedClicked;
    }
    private void OnDisable()
    {
        foreach (var el in FeedElements) el.OnButtonClicked -= OnFeedClicked;
    }
    private void OnFeedClicked(UpgradeContentFeedElement element)
    {
        var resp = GameRequestsCompositeRoot.Instance.ShopRequestController.RequestUpgrade(element.Uid);
        if(resp != null)
        {
            element.InsertData(UpgradeDataHandler.ModelToData(resp.Model));
            GameCompositeRoot.Instance.StatController.SetProductionStats(resp.Stats);
        }
    }
}
