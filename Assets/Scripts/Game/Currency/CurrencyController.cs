using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    
    public static bool IsAffordable(long price)
    {
        long playerMoney = GameCompositeRoot.Instance.StatView.GetMoneyView();

        return playerMoney >= price;
    }
    public static bool IsAffordable(string price)
    {
        long playerMoney = GameCompositeRoot.Instance.StatView.GetMoneyView();

        return playerMoney >= StatView.FromStringToCurrency(price);
    }
}
