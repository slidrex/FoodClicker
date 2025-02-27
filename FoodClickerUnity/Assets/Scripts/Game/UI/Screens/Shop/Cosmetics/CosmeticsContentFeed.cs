using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CosmeticsDataHandler;

public class CosmeticsContentFeed : ContentFeed<CosmeticsContentFeedElement, CosmeticsContentFeedGroup.Element>
{
    public CosmeticsContentFeedElement[] GetElements() => FeedElements;
    public CosmeticsContentFeedElement GetElement(int groupId, int itemId)
    {
        for(int i = 0; i < FeedElements.Length; i++)
        {
            if (FeedElements[i].GroupId == groupId && FeedElements[i].ItemId == itemId) return FeedElements[i];
        }
        return null;
    }
}
