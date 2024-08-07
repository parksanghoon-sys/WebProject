using Microsoft.AspNetCore.Mvc;

namespace _2.MvcTest
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            var builder = WebApplication.CreateBuilder(args);

            // Startup.ConfigureServices
            // This method gets called by the runtime. Use this method to add services to the container.
            // Add services to the container.
            //builder.Services.AddMvc();
            //builder.Services.AddControllers(); // Web API
            builder.Services.AddControllersWithViews(); // MVC + Web API

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Startup.Configure
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            #region HTTP
            // C# 11.0 버전의 원시 문자열 리터럴(Raw string literals)
            string htmlTag = """
<html lang="ko">
<body>
    <h1>Hello ASP.NET Core 8.0</h1>
</body>
</html>
""";

            app.MapGet("/html-content-rendering", () => Results.Content(htmlTag, "text/html"));
            #endregion

            #region HTML
            // app.UseDefaultFiles();
            //app.UseStaticFiles(); // 정적인 HTML, CSS, JS, 이미지 파일 등을 제공하는 미들웨어
            #endregion

            app.UseRouting(); // 라우팅 미들웨어

            //app.MapDefaultControllerRoute();
            //app.MapControllers(); // Web API
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
    public class MvcController : Controller
    {
        public string Hello() => "Hello, MVC";
    }
}
