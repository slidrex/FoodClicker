using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CosmeticsContentFeedElement : ContentFeedElement<CosmeticsDataHandler.CosmeticsContentFeedGroup.Element>
{
    [SerializeField] private TextMeshProUGUI _nameTag;
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _priceObj;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _prestigeText;
    [Header("Hightlight")]
    [SerializeField] private Image _highLight;
    [SerializeField] private Color32 _equipColor;
    [SerializeField] private Color32 _notOwnedColor;
    [SerializeField] private Color32 _readyToBuyColor;
    public int ItemId { get; private set; }
    public int GroupId { get; private set; }
    public Action<CosmeticsContentFeedElement> OnWasClicked;
    public ElementStatus Status { get; private set; }
    public enum ElementStatus
    {
        NOT_OWNED,
        OWNED,
        READY_TO_BUY,
        EQUIPPED
    }
    public override void InsertData(CosmeticsDataHandler.CosmeticsContentFeedGroup.Element data)
    {
        ElementStatus status = data.Status;
        var item = data.Item;
        _prestigeText.gameObject.SetActive(data.Item.MinPrestige != 0);
        _prestigeText.text = data.Item.MinPrestige.ToString();
        _icon.sprite = item.CosmeticsIcon;
        ItemId = data.Item.ItemId;
        GroupId = data.GroupId;
        _nameTag.text = item.Name;
        _price.text = item.Price.ToString();
        SetElementStatus(status);
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(OnButtonPressed);
    }
    public void SetElementStatus(ElementStatus status)
    {
        _priceObj.gameObject.SetActive(status == ElementStatus.NOT_OWNED || status == ElementStatus.READY_TO_BUY);
        _button.interactable = status == ElementStatus.OWNED || status == ElementStatus.READY_TO_BUY;
        
        SetHightlight(status);
        Status = status;
    }
    private void SetHightlight(ElementStatus status)
    {
        _highLight.gameObject.SetActive(status != ElementStatus.OWNED);
        if (status == ElementStatus.EQUIPPED) _highLight.color = _equipColor;
        else if (status == ElementStatus.READY_TO_BUY) _highLight.color = _readyToBuyColor;
        else _highLight.color = _notOwnedColor;
    }
    private void OnButtonPressed()
    {
        OnWasClicked.Invoke(this);
    }
}
