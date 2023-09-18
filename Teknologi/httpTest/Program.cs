namespace httpTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", (HttpContext context) =>
            //    {
            //        //var UserAgent = "";
            //        //if (context.Request.Headers.ContainsKey("User-Agent"))
            //        //{
            //        //    UserAgent = context.Request.Headers["User-Agent"];
            //        //}
            //        //context.Response.StatusCode = 200;
            //        //return "Request path: " + UserAgent;

            //        context.Response.ContentType = "text/html";
            //        return "<h2>du dum</h2>";
            //    }
            //);


            app.Run(async (HttpContext context) =>
            {
                string path = context.Request.Path;

                if (path == "/" || path == "/home")
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("du er home");
                }
                else if (path == "/fejl")
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Du dum self er der fejl her");
                }
                else if (path == "/products")
                {
                    string id = "";
                    if (context.Request.Query.ContainsKey("id"))
                    {
                        id = context.Request.Query["id"];
                    }
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync($"produkt: {id}");
                }
                else
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsync("denne side findes ikke");
                }
            });
            app.Run();
        }
    }
}