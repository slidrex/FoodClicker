using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuScreenController : MonoBehaviour
{
    [SerializeField] private MenuButton[] _screenButtons;
    [SerializeField] private Transform _screenObject;
    private ScreenManager.Screen _screenSpecification;
    public void LoadScreen(ScreenManager.Screen screenSpefication)
    {
        foreach (var button in _screenButtons)
        {
            if(button.ToScreen == screenSpefication)
            {
                button.MarkPressable(true);
            }
        }
        _screenSpecification = screenSpefication;
        _screenObject.gameObject.SetActive(true);
        OnScreenLoaded(screenSpefication);
    }
    public void UnloadScreen()
    {
        foreach (var button in _screenButtons)
        {
            if (button.ToScreen == _screenSpecification)
            {
                button.MarkPressable(false);
            }
        }
        _screenObject.gameObject.SetActive(false);
        OnScreenUnloaded(_screenSpecification);
    }
    protected virtual void OnScreenLoaded(ScreenManager.Screen screenSpefication)
    {

    }
    protected virtual void OnScreenUnloaded(ScreenManager.Screen screenSpefication)
    {

    }
    public virtual void OnPlayerEnterGame()
    {

    }
}
