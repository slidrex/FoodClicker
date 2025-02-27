using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LoginRequest
{
    public string email { get; set; }
    public int code { get; set; }
    public LoginRequest(string email, int code)
    {
        this.email = email;
        this.code = code;
    }
}
