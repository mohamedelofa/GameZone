namespace GameZone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = (builder.Configuration.GetConnectionString("DefaultConnection")) ?? throw new InvalidOperationException("No connection string exist");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICategoriesService, CategoriesService>();
			builder.Services.AddScoped<IDevicesService, DevicesService>();
            builder.Services.AddScoped<IGamesService, GamesService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
