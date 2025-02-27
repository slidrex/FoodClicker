using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfileObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _id;
    [SerializeField] private TextMeshProUGUI _email;
    [SerializeField] private TextMeshProUGUI _registrationDate;
    public void InsertData(PlayerProfileRequestController.PlayerProfileModel model)
    {
        _id.text = "ID: " + model.UserId.ToString();
        _email.text = model.Email;
        _registrationDate.text = model.RegistrationDate;
    }
}
