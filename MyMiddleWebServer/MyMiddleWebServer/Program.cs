using MyMiddleWebServer.WebHost;

WebHost host = new(5555);

host.UseStartup<Startup>();
host.Run();