using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMiddleWebServer.Middlewares
{
    public class StaticFileMiddleware : IMiddleware
    {
        public HttpHandler? Next { get; set; }

        public void Handle(HttpListenerContext context)
        {

            if (Path.HasExtension(context.Request.RawUrl))
            {
                try
                {
                    string filename = context.Request.RawUrl.Substring(1);
                    string path = @$"C:\Users\namiqrasullu\Desktop\MyMiddleWebServer\MyMiddleWebServer\wwwroot\{filename}";
                    var bytes = File.ReadAllBytes(path);

                    if (Path.GetExtension(path) == ".htm")
                        context.Response.AddHeader("Content-Type", "text/htm");
                    else if (Path.GetExtension(path) == ".png")
                        context.Response.AddHeader("Context-Type", "image/png");

                    context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                }
                catch
                {
                    context.Response.StatusCode = 404;
                    context.Response.StatusDescription = "File not found";
                }
            }
            Next?.Invoke(context);

        }
    }
}
