using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private ScreenManager.Screen _toScreen;
    [SerializeField] private bool _isPressable = true;
    public ScreenManager.Screen ToScreen { get { return _toScreen; } }
    public bool IsPressable { get { return _isPressable; } }
    private Button _button;
    private bool _isInitialized;
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        if (_isInitialized == false)
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => OnPressed());
            _isInitialized = true;
        }
    }
    private void OnPressed()
    {
        ScreenManager.Instance.LoadScreen(ToScreen);
    }
    public void MarkPressable(bool isPressed)
    {
        Init();
        if (_isPressable)
            _button.interactable = !isPressed;
    }
}
