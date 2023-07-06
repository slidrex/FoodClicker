using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensionController : MonoBehaviour
{
    public Action OnAscension;
    public void DoPrestigeRequest()
    {
        var resp = GameRequestsCompositeRoot.Instance.AscentionRequestHandler.DoPrestigeRequest();
        if (!resp.Equals(default(PlayerStatRequestHandler.PlayerStatResponse)))
        {
            GameCompositeRoot.Instance.StatController.SetProductionStats(resp);
            ScreenManager.Instance.LoadScreen(ScreenManager.Screen.MAIN_MENU);
            OnAscension.Invoke();
        }
    }
}
