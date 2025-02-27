using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CosmeticsImage : MonoBehaviour
{
    private Image _image;
    [SerializeField] private CosmeticsController.CosmeticsType _cosmeticsType;
    private void Awake()
    {
        GameCompositeRoot.Instance.CosmeticsController.OnCosmeticsChanged += OnCosmeticsChanged;
        _image = GetComponent<Image>();   
    }
    private void OnDestroy() => GameCompositeRoot.Instance.CosmeticsController.OnCosmeticsChanged -= OnCosmeticsChanged;
    private void OnCosmeticsChanged(CosmeticsController.CosmeticsType type, Sprite sprite)
    {
        if(type == _cosmeticsType) SetNewImage(sprite);
    }
    private void SetNewImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
