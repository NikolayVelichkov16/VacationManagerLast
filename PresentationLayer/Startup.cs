using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddDbContext<ProjectDBContext>(options =>
            options.UseSqlServer(
                    "Server = DESKTOP - 3P4J0S4; Initial Catalog = VacationManager; Integrated Security = true; Trust Server Certificate = true;"
                    //Configuration.GetConnectionString("DefaultConnection")
                    ));

            services.AddIdentity<Worker, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ProjectDBContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            services.AddScoped<ISecurityStampValidator, Microsoft.AspNetCore.Identity.SecurityStampValidator<BusinessLayer.Worker>>();

            services.AddControllersWithViews();

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


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();

                // Configure identity routes
                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "Login",
                    defaults: new { controller = "Account", action = "Login" });

                endpoints.MapControllerRoute(
                    name: "logout",
                    pattern: "Logout",
                    defaults: new { controller = "Account", action = "Logout" });

                endpoints.MapControllerRoute(
                    name: "register",
                    pattern: "Register",
                    defaults: new { controller = "Account", action = "Register" });

                endpoints.MapControllerRoute(
                    name: "profile",
                pattern: "Profile",
                    defaults: new { controller = "Account", action = "Index" });
            });
        }
    }
}
