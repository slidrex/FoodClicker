using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeContentFeedElement : ContentFeedElement<UpgradeFeedData>
{
    [SerializeField] private TextMeshProUGUI _nameTag;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _quantity;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Button _button;
    public ushort Uid { get; private set; }
    public Action<UpgradeContentFeedElement> OnButtonClicked;
    public override void InsertData(UpgradeFeedData data)
    {
        _icon.sprite = data.Sprite;
        _nameTag.text = data.Name;
         Uid = data.UpgradeID;
        _quantity.text = data.Quantity.ToString();
        _description.text = data.Description;
        _price.text = data.Price.ToString();
        _button.onClick.RemoveAllListeners();
        UpdateAvailableness();
        _button.onClick.AddListener(() => OnButtonClicked.Invoke(this));
    }
    private void OnEnable()
    {
        GameCompositeRoot.Instance.StatView.OnMoneyChanged += UpdateAvailableness;
    }
    private void OnDisable()
    {
        GameCompositeRoot.Instance.StatView.OnMoneyChanged -= UpdateAvailableness;
    }
    public void UpdateAvailableness()
    {
        _button.interactable = CurrencyController.IsAffordable(int.Parse(_price.text));
    }
}
