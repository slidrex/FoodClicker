using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static LeaderFeed;

public class LeaderFeedElement : ContentFeedElement<LeaderFeedElementData>
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _networth;
    [SerializeField] private TextMeshProUGUI _prestigeLevel;
    [SerializeField] private TextMeshProUGUI _place;
    public override void InsertData(LeaderFeedElementData data)
    {
        var model = data.Model;
        string email = model.Username;
        _name.text = email.Substring(0, email.IndexOf('@'));
        _networth.text = model.Money.ToString();
        _place.text = data.PlaceIndex.ToString();
        _prestigeLevel.gameObject.SetActive(model.PrestigeLevel != 0);
        _prestigeLevel.text = model.PrestigeLevel.ToString();
    }
}
