using Blazored.LocalStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MotherSLAdmin.Data;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        string testApi = "";
        string liveApi = "";
        string apiType = "";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            testApi = Configuration.GetValue<string>("ApiLinks:test");//"http://api.stassentea.melstasoft.com:80";
            liveApi = Configuration.GetValue<string>("ApiLinks:live"); //"http://api.stassentea.melstasoft.com:80";
            apiType = Configuration.GetValue<string>("ApiLinks:type");
        }

        public string GetAPI()
        {
            if (apiType == "live")
                return liveApi;
            else
                return testApi;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredLocalStorage();
            services.Configure<AppSettingsApi>(Configuration.GetSection(AppSettingsApi.sectionName));
            services.Configure<PaymentGateway>(Configuration.GetSection(PaymentGateway.sectionName));
            services.AddHttpClient<IPaymentService, PaymentService>();
            services.AddHttpClient<IApiService, ApiService>(client =>
            {
                client.BaseAddress = new Uri(GetAPI());
            });
            services.AddTransient<IFileUpload, FileUpload>();
            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
