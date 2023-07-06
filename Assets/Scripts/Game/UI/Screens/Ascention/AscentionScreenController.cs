using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AscentionScreenController : MenuScreenController
{
    [SerializeField] private Button _ascentionSubmitButton;
    [SerializeField] private TextMeshProUGUI _ascentionPriceholder;
    private void OnEnable()
    {
        _ascentionSubmitButton.onClick.AddListener(OnAscentionButtonClicked);
        GameCompositeRoot.Instance.StatController.OnMoneyChanged += UpdatePrestigeButtonInteractionStatus;
    }
    private void OnDisable()
    {
        GameCompositeRoot.Instance.StatController.OnMoneyChanged -= UpdatePrestigeButtonInteractionStatus;
        _ascentionSubmitButton.onClick.RemoveAllListeners();
    }
    protected override void OnScreenLoaded(ScreenManager.Screen screenSpefication)
    {
        if(screenSpefication == ScreenManager.Screen.ASCENTION_MENU)
        {
            var ascentionPrice = GameRequestsCompositeRoot.Instance.AscentionRequestHandler.GetAscentionPrice();
            _ascentionPriceholder.text = StatView.FromCurrencyToString(ascentionPrice.Price);
            UpdatePrestigeButtonInteractionStatus();
        }
    }
    private void UpdatePrestigeButtonInteractionStatus()
    {
        _ascentionSubmitButton.interactable = GameCompositeRoot.Instance.StatController.IsAffordable(_ascentionPriceholder.text);
    }
    private void OnAscentionButtonClicked()
    {
        GameCompositeRoot.Instance.AscensionController.DoPrestigeRequest();
    }
}
