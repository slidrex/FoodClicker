using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClickFoodController : MonoBehaviour
{
    [SerializeField] private Button _clickableFood;
    private float timeSinceCycle;
    private void OnEnable()
    {
        _clickableFood.onClick.AddListener(OnClick);
    }
    private void OnDisable()
    {
        _clickableFood.onClick.RemoveAllListeners();
    }
    private void Update()
    {
        if (timeSinceCycle < 1.0f)
        {
            timeSinceCycle += Time.deltaTime;
        }
        else
        {
            var response = GameRequestsCompositeRoot.Instance.ShopRequestController.CompleteCycle();
            GameCompositeRoot.Instance.StatController.SetMoney(response.userMoney);
            timeSinceCycle = 0;
        }
    }
    private void OnClick()
    {
        var response = GameRequestsCompositeRoot.Instance.ShopRequestController.PerformClick();
        GameCompositeRoot.Instance.StatController.SetMoney(response.userMoney);
    }
}
