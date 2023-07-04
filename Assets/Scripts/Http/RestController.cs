using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Unity.Collections;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class RestController
{
    public static UnityWebRequest PostRequestMessage(string uri, string postDataJSON)
    {
        byte[] data = new UTF8Encoding().GetBytes(postDataJSON);
        using var nativeData = new NativeArray<byte>(data, Allocator.Temp);
        var request = new UnityWebRequest(uri, "POST");
        request.uploadHandler?.Dispose();
        request.downloadHandler?.Dispose();
        request.downloadHandler = new DownloadHandlerBuffer();
        request.uploadHandler = new UploadHandlerRaw(nativeData.ToArray());
        request.SetRequestHeader("Authorization", $"Bearer {ClientManager.AUTH_TOKEN}");
        request.SetRequestHeader("Content-Type", "application/json");
        request.disposeUploadHandlerOnDispose = true;
        request.disposeDownloadHandlerOnDispose = true;

        return request;
    }
    public static UnityWebRequest PatchRequestMessage(string uri, object postData = null)
    {
        var request = new UnityWebRequest(uri, "PATCH");
        request.downloadHandler = new DownloadHandlerBuffer();
        if (postData != null) request.uploadHandler = new UploadHandlerRaw(new UTF8Encoding().GetBytes(JsonConvert.SerializeObject(postData)));
        request.SetRequestHeader("Authorization", $"Bearer {ClientManager.AUTH_TOKEN}");
        request.SetRequestHeader("Content-Type", "application/json");

        return request;
    }
    public static UnityWebRequest GetRequestMessage(string uri)
    {
        var request = new UnityWebRequest(uri, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Authorization", $"Bearer {ClientManager.AUTH_TOKEN}");
        request.SetRequestHeader("Content-Type", "application/json");

        return request;
    }
}
