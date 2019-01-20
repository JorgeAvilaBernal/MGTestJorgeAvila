using MasGlobal.Common;
using ServiceStack;
using System.Collections.Generic;

namespace MasGlobal.DAL
{
    public class EmployeeObjects
    {
        //static HttpClient client = new HttpClient();
        //Needs newtonsoft on the DAL project to keep it short on externals I used ServiceStack
        //public static List<EmployeeDTO> GetEmployeeHttpClient(string url)
        //{
        //    string response = string.Empty;
        //    using (var httpClient = new HttpClient())
        //        response = httpClient.GetStringAsync(new Uri(url)).Result;
        //    return JsonConvert.DeserializeObject<List<EmployeeDTO>>(response);
        //}
        
        public static List<EmployeeDTO> GetEmployees(string url)
        {
            return url.GetJsonFromUrl().FromJson<List<EmployeeDTO>>();
        }
    }
}
