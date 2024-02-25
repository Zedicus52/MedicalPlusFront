using System;

namespace MedicalPlusFront.WebModels;

public class LoginResult
{
    public string UserName { get; set; }
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}