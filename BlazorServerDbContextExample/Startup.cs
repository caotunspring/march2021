using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorServerDbContextExample.Data;
using Microsoft.EntityFrameworkCore;
using BlazorServerDbContextExample.Grid;
using CaotunSpring002.Adapter;

namespace BlazorServerDbContextExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // register factory and configure the options
            #region snippet1
            services.AddDbContextFactory<ContactContext>(opt =>
                opt.UseSqlite($"Data Source={nameof(ContactContext.ContactsDb)}.db"));
            #endregion

            // pager
            services.AddScoped<IPageHelper, PageHelper>();

            // filters
            services.AddScoped<IContactFilters, GridControls>();

            // query adapter (applies filter to contact request).
            services.AddScoped<GridQueryAdapter>();

            // service to communicate success on edit between pages
            services.AddScoped<EditSuccess>();



            //services.AddDbContextFactory<NS002Context>(options =>
            //                    options.UseSqlServer(
            //                        Configuration.GetConnectionString("BizConnection")));
            ////https://stackoverflow.com/questions/64169025/using-identity-with-adddbcontextfactory-in-blazor

            //services.AddScoped<NS002Context>(p => p.GetRequiredService<IDbContextFactory<NS002Context>>().CreateDbContext());


            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<NS2Context>();


            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<IPageHelperV7, PageHelperV7>();
            services.AddScoped<IFiltersV7, FiltersV7>();

            services.AddScoped<A00Adapter>();
            services.AddScoped<A01Adapter>();
            services.AddScoped<A02Adapter>();
            services.AddScoped<A03Adapter>();



        }

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
