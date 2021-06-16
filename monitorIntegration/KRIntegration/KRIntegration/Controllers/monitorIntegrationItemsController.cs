using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using monitorIntegration.Models;
using Newtonsoft.Json;
using KRIntegration.Models;
using RestSharp;
using RestSharp.Serialization.Json;

namespace monitorIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class monitorIntegrationItemsController : ControllerBase
    {
        private readonly monitorIntegrationContext _context;

        const string UserName = "chris@kindlyreminders.com";
        const string TestUserName = "chris@kindlyreminders.com.ndifechang";
        const string Password = "Integration1!";
        const string TestPassword = "Integration1!";
        const string UrlLogin = "https://login.salesforce.com/services/oauth2/token";
        const string TestUrlLogin = "https://test.salesforce.com/services/oauth2/token";
        const string TestURLCall = "https://kindlyreminders--ndifechang.my.salesforce.com/services/apexrest/MonitorIntegration";
        const string URLCall = "https://kindlyreminders.my.salesforce.com/services/apexrest/MonitorIntegration";
        const string TestClientID = "3MVG98dostKihXN4UHAFu5o1Pf9QUd7D7MMKIaHEbwWa.v3HS6s9q8PsAmh1EPaNwViR6kwfha4fibHhgDqQB";
        const string ClientID = "3MVG9l2zHsylwlpQ5c1SzEbzFShwMVFHnjXKQczOY42efZsk7VChh1lMiugbiqHaNTu0XQKkU5UOSkoKuTc.3";
        const string TestClientSecret = "EA234228B9713E4F110D50AAE1A416C1E86B0BB2866CCA97C573E84F72D59152";
        const string ClientSecret = "C9F0DB00B19D1B26CD616C56A708D18B86227A8B4341109C86A598EA738EFF96";
        const string GrantType = "password";

        public monitorIntegrationItemsController(monitorIntegrationContext context)
        {
            _context = context;
        }


        // POST: api/monitorIntegrationItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<monitorInformationItem>> PostmonitorInformationItem(monitorInformationItem data)
        {
            _context.Items.Add(data);
            await _context.SaveChangesAsync();

            var client = new HttpClient();
            string jsonString = JsonConvert.SerializeObject(data);
            var stringcontent = new StringContent(jsonString);

            SfTestLogin(data);
            //SfLogin(data);

            return Ok();
        }

        public static void SfTestLogin(monitorInformationItem data)
        {
            
            var client = new RestClient(TestUrlLogin);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "BrowserId=QF7VcsCcEeuj8MXGuN1_ug");
            request.AddParameter("username", TestUserName);
            request.AddParameter("password", TestPassword);
            request.AddParameter("grant_type", GrantType);
            request.AddParameter("client_id", TestClientID);
            request.AddParameter("client_secret", TestClientSecret);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var response = client.Post(request);
            var content = response.Content;
            Token token = new JsonDeserializer().Deserialize<Token>(response);

            SfTestCall(token, data);
            SfCall(token, data);

        }

        public static void SfLogin(monitorInformationItem data)
        {

            var client = new RestClient(UrlLogin);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "BrowserId=QF7VcsCcEeuj8MXGuN1_ug");
            request.AddParameter("username", UserName);
            request.AddParameter("password", Password);
            request.AddParameter("grant_type", GrantType);
            request.AddParameter("client_id", ClientID);
            request.AddParameter("client_secret", ClientSecret);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var response = client.Post(request);
            var content = response.Content;
            Token token = new JsonDeserializer().Deserialize<Token>(response);

            SfTestCall(token, data);

        }

        public static void SfTestCall(Token token, monitorInformationItem data)
        {
            var client = new RestClient(TestURLCall);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer "+ token.access_token);
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(data);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        public static void SfCall(Token token, monitorInformationItem data)
        {
            var client = new RestClient(URLCall);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + token.access_token);
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(data);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        private bool monitorInformationItemExists(long id)
        {
            return _context.Items.Any(e => e.id == id);
        }
    }
}
