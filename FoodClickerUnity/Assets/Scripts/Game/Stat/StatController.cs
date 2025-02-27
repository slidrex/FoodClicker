using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatController : MonoBehaviour
{
    private StatProvider _statProvider;
    [SerializeField] private StatView _statView;
    public Action OnMoneyChanged;
    internal void Init()
    {
        _statProvider = new StatProvider();
    }
    public void SetMoney(long money)
    {
        _statProvider.Money = money;
        _statView.SetMoneyView(money);
        OnMoneyChanged?.Invoke();
    }
    public void SetGPC(int gpc)
    {
        _statProvider.GPC = gpc;
        _statView.SetGPCView(gpc);
    }
    public void SetGPS(int gps) 
    {
        _statProvider.GPS = gps;
        _statView.SetGPSView(gps);
    }
    public void SetPrestigeLevel(int level)
    {
        _statProvider.PrestigeLevel = level;
        _statView.SetPrestigeLevelView(level);
    }
    public void SetProductionStats(PlayerStatRequestHandler.PlayerStatResponse body)
    {
        SetGPC(body.Gpc);
        SetGPS(body.Gps);
        SetMoney(body.UserMoney);
        SetPrestigeLevel(body.PrestigeLevel);
    }
    public bool HasEnoughPrestigeLevel(int requiredLevel)
    {
        return requiredLevel <= _statProvider.PrestigeLevel;
    }
    public bool IsAffordable(long money)
    {
        return _statProvider.Money >= money;
    }
    public bool IsAffordable(string money)
    {
        return _statProvider.Money >= StatView.FromStringToCurrency(money);
    }
}
