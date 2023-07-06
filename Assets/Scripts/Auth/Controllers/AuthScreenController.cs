using Newtonsoft.Json;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AuthScreenController : MonoBehaviour
{
    private AuthScreenView.Screen _currenctScreen;
    private const string FOOD_ID_URI = "http://localhost:8080/api/v0/foodid/";
    [SerializeField] private AuthScreenView _authScreenView;
    private string _specifiedString;
    private void OnEnable()
    {
        _authScreenView.OnEmailSubmitButtonPressed = (string v) => StartCoroutine(EmailSubmit(v));
        _authScreenView.OnCodeSubmitButtonPressed = (string v) => StartCoroutine(CodeSubmit(v));
    }
    private void OnDisable()
    {
        _authScreenView.OnEmailSubmitButtonPressed= null;
        _authScreenView.OnCodeSubmitButtonPressed = null;
    }
    private IEnumerator EmailSubmit(string value)
    {
        var codeRequest = new ConfirmationCodeRequest(value);
        string codeRequestJSON = JsonConvert.SerializeObject(codeRequest);
        _specifiedString = value;
        var request = RestController.PostRequestMessage($"{FOOD_ID_URI}email/send_confirmation_code", codeRequestJSON);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError) yield return null;
        var httpResponse = JsonConvert.DeserializeObject<HttpStatusResponse>(request.downloadHandler.text);
        if (request.responseCode == 200 )
        {
            _authScreenView.SetScreen(AuthScreenView.Screen.CODE);
        }

        _authScreenView.SetSystemOutput(httpResponse.Status);
    }
    private IEnumerator CodeSubmit(string value) 
    {
        if (int.TryParse(value[..^1], out var code))
        {

            var loginRequest = new LoginRequest(_specifiedString, code);
            string codeRequestJSON = JsonConvert.SerializeObject(loginRequest);

            var request = RestController.PostRequestMessage($"{FOOD_ID_URI}auth/authenticate", codeRequestJSON);
            yield return request.SendWebRequest();

            if (request.responseCode == 200)
            {
                var tokenResponse = JsonConvert.DeserializeObject<AuthTokenResponse>(request.downloadHandler.text);
                
                ClientManager.SetAuthenticationToken(tokenResponse.AccessToken);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                var errorMessage = JsonConvert.DeserializeObject<HttpStatusResponse>(request.downloadHandler.text);
                _authScreenView.SetSystemOutput(errorMessage.Status);
            }
        }
        else _authScreenView.SetSystemOutput("Input must contain only digits");
    }
}
