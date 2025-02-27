using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class StatView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private TextMeshProUGUI _gps;
    [SerializeField] private GameObject _prestigeLevelObj;
    [SerializeField] private TextMeshProUGUI _prestigeLevel;
    [SerializeField] private TextMeshProUGUI _gpc;
    
    private static Dictionary<long, string> NumberShortcuts = new Dictionary<long, string>()
    {
        [1000] = "K",
        [1000000] = "M",
        [1000000000] = "B",
        [1000000000000] = "T",
        [1000000000000000] = "q",
        [1000000000000000000] = "Q",
    };
    public static long FromStringToCurrency(string str)
    {
        char literal = str[str.Length - 1];

        long multiplier = 1;
        for (int i = NumberShortcuts.Count - 1; i >= 0; i--)
        {
            var el = NumberShortcuts.ElementAt(i);

            if (char.Parse(el.Value).Equals(literal))
            {
                multiplier = el.Key;
                break;
            }
        }

        if (multiplier != 1) str = str[..^1];

        return (long)(float.Parse(str) * multiplier);
    }
    public static string FromCurrencyToString(long currency)
    {
        float currencyFloat = currency;
        for (int i = NumberShortcuts.Count - 1; i >= 0; i--)
        {
            var currentLiteral = NumberShortcuts.ElementAt(i);
            if (currency >= currentLiteral.Key)
            {

                currencyFloat = (float)System.Math.Round(currencyFloat / currentLiteral.Key, 2);



                return $"{currencyFloat}{currentLiteral.Value}";
            }
        }
        return currency.ToString();
    }
    public void SetMoneyView(long money)
    {
        _money.text = FromCurrencyToString(money);
    }
    public void SetGPSView(int gps)
    {
        _gps.text = gps.ToString();
    }
    public void SetGPCView(int gpc)
    {
        if(_gpc != null)
        _gpc.text = gpc.ToString();
    }
    public void SetPrestigeLevelView(int level)
    {
        _prestigeLevelObj.gameObject.SetActive(level != 0);
        _prestigeLevel.text = level.ToString();
    }
    public void InsertProductionView(PlayerStatRequestHandler.PlayerStatResponse body)
    {
        SetMoneyView(body.UserMoney);
        SetGPCView(body.Gpc);
        SetGPSView(body.Gps);
    }
    public long GetMoneyView() => FromStringToCurrency(_money.text);
}
