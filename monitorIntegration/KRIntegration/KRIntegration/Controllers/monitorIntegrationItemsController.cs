using System.Collections.Generic;
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

        const string UserName = "";
        const string TestUserName = "chris@kindlyreminders.com.ndifechang";
        const string Password = "";
        const string TestPassword = "Integration1!";
        const string UrlLogin = "";
        const string TestUrlLogin = "https://test.salesforce.com/services/oauth2/token";
        const string TestURLCall = "https://kindlyreminders--ndifechang.my.salesforce.com/services/apexrest/MonitorIntegration";
        const string URLCall = "https://kindlyreminders.my.salesforce.com/services/apexrest/MonitorIntegration";
        const string TestClientID = "3MVG98dostKihXN4UHAFu5o1Pf9QUd7D7MMKIaHEbwWa.v3HS6s9q8PsAmh1EPaNwViR6kwfha4fibHhgDqQB";
        const string ClientID = "";
        const string TestClientSecret = "EA234228B9713E4F110D50AAE1A416C1E86B0BB2866CCA97C573E84F72D59152";
        const string ClientSecret = "";
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

            return Ok(stringcontent);
        }

        public static async void SfTestLogin(monitorInformationItem data)
        {
            Credential credential = new Credential(TestUserName, TestPassword, GrantType, ClientID, ClientSecret);

            var client = new RestClient(TestUrlLogin);
            var request = new RestRequest("");

            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(credential);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var response = client.Post(request);
            var content = response.Content;
            response.ContentType = "application/json";

            Token token = new JsonDeserializer().Deserialize<Token>(response);

            HttpClient sfCall = new HttpClient();
            sfCall.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.access_token);
            var sfCallResponse = await sfCall.PostAsync(TestURLCall, new StringContent(JsonConvert.SerializeObject(data)));
           
        }

        private bool monitorInformationItemExists(long id)
        {
            return _context.Items.Any(e => e.id == id);
        }
    }
}
