using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.TouchScreenKeyboard;

public class CosmeticsContentFeedElement : ContentFeedElement<CosmeticsDataHandler.CosmeticsContentFeedGroup.CosmeticsContentFeedGroupElement>
{
    [SerializeField] private TextMeshProUGUI _nameTag;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _equipLight;
    [SerializeField] private Transform _priceObj;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Button _button;
    public int ItemId { get; private set; }
    public int GroupId { get; private set; }
    public Action<CosmeticsContentFeedElement> OnWasClicked;
    public override void InsertData(CosmeticsDataHandler.CosmeticsContentFeedGroup.CosmeticsContentFeedGroupElement data)
    {
        var item = data.Item;
        _icon.sprite = item.CosmeticsIcon;
        ItemId = data.Item.ItemId;
        GroupId = data.GroupId;
        _nameTag.text = item.Name;
        _priceObj.gameObject.SetActive(!data.IsAvailable);
        _price.text = item.Price.ToString();
        _button.interactable = data.IsAvailable;
        SetEquipStatus(data.IsEquipped);
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(OnButtonPressed);
    }
    public void SetEquipStatus(bool status)
    {
        _equipLight.gameObject.SetActive(status);
        _button.interactable = !status;
    }
    private void OnButtonPressed()
    {
        OnWasClicked.Invoke(this);
    }
}
