using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScreen : MenuScreenController
{
    [SerializeField] private UpgradeContentFeed _upgradesScreen;
    [SerializeField] private CosmeticsContentFeed _cosmeticsScreen;
    protected override void OnScreenLoaded(ScreenManager.Screen screenSpefication)
    {
        switch (screenSpefication)
        {
            case ScreenManager.Screen.SHOP_UPGRADES:
                var models = GameRequestsCompositeRoot.Instance.ShopRequestController.GetPlayerProduction();
                _upgradesScreen.FillFeed(UpgradeDataHandler.ModelToData(models));
                _upgradesScreen.gameObject.SetActive(true);
                return;
        }
    }
    protected override void OnScreenUnloaded(ScreenManager.Screen screenSpefication)
    {
        switch (screenSpefication)
        {
            case ScreenManager.Screen.SHOP_UPGRADES:
                _upgradesScreen.gameObject.SetActive(false);
                return;
        }
    }
}
