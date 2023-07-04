using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuthScreenView : MonoBehaviour
{
    public enum Screen
    {
        EMAIL, CODE
    }
    [Serializable]
    public struct ScreenObject
    {
        public Screen Screen;
        public GameObject ScreenGameObject;
    }
    [Serializable]
    public struct TransferButton
    {
        public Screen ToScreen;
        public Button Button;
    }
    [SerializeField] private ScreenObject[] _screenObjects;
    [SerializeField] private TransferButton[] _transferButtons;
    [SerializeField] private TextMeshProUGUI _systemOutput;
    [SerializeField] private TextMeshProUGUI _emailField;
    [SerializeField] private TextMeshProUGUI _codeField;
    [SerializeField] private Button _emailSubmitButton;
    [SerializeField] private Button _codeSubmitButton;
    public System.Action<string> OnEmailSubmitButtonPressed;
    public System.Action<string> OnCodeSubmitButtonPressed;
    private void OnEnable()
    {
        _emailSubmitButton.onClick.AddListener(() => OnEmailSubmitButtonPressed.Invoke(_emailField.text));
        _codeSubmitButton.onClick.AddListener(() => OnCodeSubmitButtonPressed.Invoke(_codeField.text));
        foreach (var button in _transferButtons) button.Button.onClick.AddListener(() => SetScreen(button.ToScreen));
    }
    private void OnDisable()
    {
        _emailSubmitButton.onClick.RemoveAllListeners();
        _codeSubmitButton.onClick.RemoveAllListeners();
        foreach (var button in _transferButtons) button.Button.onClick.RemoveAllListeners();
    }
    public void SetScreen(Screen screen)
    {
        foreach(var screenObject in _screenObjects)
        {
            screenObject.ScreenGameObject.SetActive(screenObject.Screen == screen);
        }
    }
    public void SetSystemOutput(string text)
    {
        _systemOutput.text = text;
    }
}
