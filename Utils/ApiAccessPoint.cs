using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace MedicalPlusFront.Utils;

public class ApiAccessPoint
{
    public static ApiAccessPoint Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ApiAccessPoint();
            return _instance;
        }
    }

    private const string _baseUrl = "https://localhost:7061/api";
    
    private static ApiAccessPoint _instance;

    public async Task<IFlurlResponse?> Login(string login, string password)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("Auth/login")
                .SetQueryParams(new { UserName = login, Password = password })
                .PostAsync();
        }
        catch (FlurlHttpException e)
        {
            if(e.StatusCode != null)
                return new FlurlResponse(e.Call);
            return null;
        }
        
    }
}