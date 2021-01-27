using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public class DefaultConfigProvider
    {
        public string PlayerName { get { return "Player"; } }
        
        private string LocalHostIP { get { return "127.0.0.1"; } }
        private string LocalHostPort { get { return "7777"; } }
        public Server LocalHostServer
        {
            get
            {
                return new Server()
                {
                    Address = LocalHostIP,
                    Port = LocalHostPort
                };
            }
        }

    }
}
