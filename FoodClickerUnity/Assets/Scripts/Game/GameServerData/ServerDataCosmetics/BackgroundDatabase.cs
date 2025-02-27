using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Food Clicker/ID Data Handler/Cosmetics/Background")]
public class BackgroundDatabase : ServerCosmeticsDatabase<Sprite>
{
    public override void ApplyCosmetics(int itemId)
    {
        GameCompositeRoot.Instance.CosmeticsController.SetBackground(GetItem(itemId).Item);
    }
}
