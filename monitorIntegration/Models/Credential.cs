using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KRIntegration.Models
{
    public class Credential
    {
        public string username { get; set; }
        public string password { get; set; }
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }

        public Credential(string username, string password, string grantType, string clientID, string clientSecret)
        {
            this.username = username;
            this.password = password;
            this.grant_type = grantType;
            this.client_id = clientID;
            this.client_secret = clientSecret;
        }
    }

    
}
