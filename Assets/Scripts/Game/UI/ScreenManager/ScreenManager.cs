using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public enum Screen
    {
        MAIN_MENU,

        SHOP_UPGRADES,
        COSMETICS_BACKGROUND,

        SOCIAL_FRIENDS,
        SOCIAL_FRIENDS_REQUESTS,
        SOCIAL_FRIENDS_ADD_MENU,


        SOCIAL_TOP,
        SOCIAL_ME,
        ASCENTION_MENU,
        COSMETICS_FOOD_IMAGE
    }
    [Serializable]
    internal struct ScreenObject
    {
        public MenuScreenController Screen;
        public Screen[] ScreenTypes;
    }
    [SerializeField] private ScreenObject[] _screenControllers;
    public static ScreenManager Instance;
    private byte _loadedScreen;
    private MenuButton _unloadedButton;
    private void Awake()
    {
        Instance = this;
        Initialize();
    }
    public void LoadScreen(Screen toScreen)
    {
        if (_screenControllers[_loadedScreen].ScreenTypes[0] != Screen.MAIN_MENU)
        {
            _screenControllers[_loadedScreen].Screen.UnloadScreen();
        }

        if(toScreen != Screen.MAIN_MENU)
        {
            _loadedScreen = GetScreenIndexByType(toScreen);
            _screenControllers[_loadedScreen].Screen.LoadScreen(toScreen);
        }
    }
    public void Initialize()
    {
        foreach (var screen in _screenControllers) screen.Screen.OnPlayerEnterGame();
    }
    private byte GetScreenIndexByType(Screen screenType)
    {
        for (byte i = 0; i < _screenControllers.Length; i++)
        {
            var screen = _screenControllers[i];
            foreach(var screenType2 in screen.ScreenTypes)
            {
                if (screenType2 == screenType) return i;
            }
        }
        throw new NullReferenceException("Unknown screen type \"" + screenType.ToString() + "\"");
    }
}
