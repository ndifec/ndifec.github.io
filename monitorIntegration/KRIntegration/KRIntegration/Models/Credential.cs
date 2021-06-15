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
        public string grantType { get; set; }
        public string clientID { get; set; }
        public string clientSecret { get; set; }

        public Credential(string username, string password, string grantType, string clientID, string clientSecret)
        {
            this.username = username;
            this.password = password;
            this.grantType = grantType;
            this.clientID = clientID;
            this.clientSecret = clientSecret;
        }
    }

    
}
