using MyMiddleWebServer.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiddleWebServer.WebHost
{
    public interface IStartup
    {
        public void Configure(MiddlewareBuilder builder);
    }
}
