using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CosmeticsRequestController;

public class CosmeticsController : MonoBehaviour
{
    public enum CosmeticsType
    {
        BACKGROUND = 0,
        CLICK_FOOD_IMAGE = 1,
        MONEY_IMAGE = 2
    }
    public Action<CosmeticsType, Sprite> OnCosmeticsChanged;
    public readonly Dictionary<CosmeticsType, ushort> ActiveCosmetics = new Dictionary<CosmeticsType, ushort>();
    [SerializeField] private Image[] _background;
    [SerializeField] private Image _foodImage;
    public void SetupSavedCosmetics()
    {
        PlayerCosmeticsModel[] equippedCosmetics = GameRequestsCompositeRoot.Instance.CosmeticsRequestController.GetPlayerEquippedCosmetics();
        DatabaseCompositeRoot.Instance.ServerHandlerDatabase.CosmeticsDataHandler.ApplyAllDefaultCosmetics();
        foreach (var equippedCosm in equippedCosmetics) DatabaseCompositeRoot.Instance.ServerHandlerDatabase.CosmeticsDataHandler.ApplyCosmetics(equippedCosm.GroupId, equippedCosm.ItemId);
    }
    public void SetBackground(Sprite background)
    {
        foreach(var item in _background)
            item.sprite = background;
    }
    public void SetFoodImage(Sprite food)
    {
        _foodImage.sprite = food;
    }
}
