using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using MedicalPlusFront.WebModels;


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
            return await _baseUrl.AppendPathSegment("auth/login")
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
    public async Task<IFlurlResponse?> CheckAccess(string roleName, string token)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("auth/checkAccess")
                .WithOAuthBearerToken(token)
                .SetQueryParams(new {role=roleName})
                .PostAsync();
        }
        catch (FlurlHttpException e)
        {
            if(e.StatusCode != null)
                return new FlurlResponse(e.Call);
            return null;
        }
    }

    public async Task<IFlurlResponse?> GetUserRoles(string token)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("auth/getRoles")
                .WithOAuthBearerToken(token)
                .GetAsync();
        }
        catch (FlurlHttpException e)
        {
            if (e.StatusCode != null)
                return new FlurlResponse(e.Call);
            return null;
        }
    }

    public async Task<IFlurlResponse?> GetGenders(string jwtToken)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("gender/getAll")
                .WithOAuthBearerToken(jwtToken)
                .GetAsync();
        }
        catch (FlurlHttpException e)
        {
            if (e.StatusCode != null)
                return new FlurlResponse(e.Call);
            return null;
        }
    }

    #region Difficulties

    public async Task<IFlurlResponse?> GetDifficulties(string jwtToken)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("difficulty/getAll")
                .WithOAuthBearerToken(jwtToken)
                .GetAsync();
        }
        catch (FlurlHttpException e)
        {
            if(e.StatusCode != null)
            {
                return new FlurlResponse(e.Call);
            }
            return null;
        }
    }

    #endregion

    #region Problems
    public async Task<IFlurlResponse?> CreateProblem(ProblemModel problem, string jwtToken)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("problem/create")
                .WithOAuthBearerToken(jwtToken)
                .PostJsonAsync(problem);
        }
        catch(FlurlHttpException e)
        {
            if(e.StatusCode != null)
            {
                return new FlurlResponse(e.Call);
            }
            return null;
        }
    }

    public async Task<IFlurlResponse?> UpdateProblem(ProblemModel problem, string jwtToken)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("problem/update")
                .WithOAuthBearerToken(jwtToken)
                .PutJsonAsync(problem);
        }
        catch (FlurlHttpException e)
        {
            if(e.StatusCode != null)
            {
                return new FlurlResponse(e.Call);
            }
            return null;
        }
    }

    #endregion

    #region Patients

    public async Task<IFlurlResponse?> CreatePatient(PatientModel patient,string jwtToken)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("patient/create")
                .WithOAuthBearerToken(jwtToken)
                .PostJsonAsync(patient);
        }
        catch (FlurlHttpException e)
        {
            if (e.StatusCode != null)
                return new FlurlResponse(e.Call);
            return null;
        }
    }

    public async Task<IFlurlResponse?> UpdatePatient(PatientModel patient, string jwtToken)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("patient/update")
                .WithOAuthBearerToken(jwtToken)
                .PutJsonAsync(patient);
        }
        catch (FlurlHttpException e)
        {
            if (e.StatusCode != null)
                return new FlurlResponse(e.Call);
            return null;
        }
    }

    public async Task<IFlurlResponse?> GetAllPatients(string jwtToken)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("patient/getAll")
                .WithOAuthBearerToken(jwtToken)
                .GetAsync();
        }
        catch (FlurlHttpException e)
        {
            if (e.StatusCode != null)
                return new FlurlResponse(e.Call);
            return null;
        }
    }

    #endregion

    #region Users

    public async Task<IFlurlResponse?> CreateEmployee(EmployeeModel employeeModel, string jwtToken)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("auth/create")
                .WithOAuthBearerToken(jwtToken)
                .PostJsonAsync(employeeModel);
        }
        catch(FlurlHttpException e)
        {
            if(e.StatusCode != null)
                return new FlurlResponse(e.Call);
            return null;
        }
    }

    public async Task<IFlurlResponse?> UpdateEmployee(EmployeeModel patient, string jwtToken)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("user/update")
                .WithOAuthBearerToken(jwtToken)
                .PutJsonAsync(patient);
        }
        catch (FlurlHttpException e)
        {
            if (e.StatusCode != null)
                return new FlurlResponse(e.Call);
            return null;
        }
    }

    public async Task<IFlurlResponse?> GetAllEmployees(string jwtToken)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("user/getAll")
                .WithOAuthBearerToken(jwtToken)
                .GetAsync();
        }
        catch(FlurlHttpException e)
        {
            if (e.StatusCode != null)
                return new FlurlResponse(e.Call);
            return null;
        }
    }

    public async Task<IFlurlResponse?> GetPatientsProblems(int patientId,string jwtToken)
    {
        try
        {
            return await _baseUrl.AppendPathSegment("problem/getByPatientId")
                .WithOAuthBearerToken(jwtToken)
                .SetQueryParams(new { patientId })
                .GetAsync();
        }
        catch (FlurlHttpException e)
        {
            if (e.StatusCode != null)
                return new FlurlResponse(e.Call);
            return null;
        }
    }

    #endregion
}