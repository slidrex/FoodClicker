using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LeaderFeed;

public class LeaderFeed : ContentFeed<LeaderFeedElement, LeaderFeedElementData>
{
    public struct LeaderFeedElementData
    {
        public LeadersRequestController.MoneyLeaderModel Model { get; private set; }
        public int PlaceIndex { get; private set; }

        public LeaderFeedElementData(LeadersRequestController.MoneyLeaderModel model, int placeIndex)
        {
            Model = model;
            PlaceIndex = placeIndex;
        }
    }
}
