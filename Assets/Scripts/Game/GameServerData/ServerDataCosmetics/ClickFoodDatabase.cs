using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ServerDataCosmticsDatabase;

[CreateAssetMenu(menuName = "Food Clicker/ID Data Handler/Cosmetics/Click food image")]
public class ClickFoodDatabase : ServerCosmeticsDatabase<Sprite>
{
    public override void ApplyCosmetics(int itemId)
    {
        GameCompositeRoot.Instance.CosmeticsController.SetFoodImage(GetItem(itemId).Item);
    }
}
