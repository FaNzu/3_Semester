//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//	app.UseExceptionHandler("/Home/Error");
//	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//	app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//	name: "default",
//	pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GraphicalWebMVC.Data;
using GraphicalWebMVC.Models.Seeders;

HttpClient httpClient = new();


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ArtworkMvcContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ArtworkMvcContext") ?? throw new InvalidOperationException("Connection string 'ArtworkMvcContext' not found.")));

//builder.Services.AddDefaultIdentity<DefaultUser>(options => options.SignIn.RequireConfirmedAccount = false)
//	.AddRoles<IdentityRole>()
//	.AddEntityFrameworkStores<SurfBoardWebContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(typeof(HttpClient), httpClient);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	SeedArtwork.Initialize(services);
}

#region identity
//using (var scope = app.Services.CreateScope())
//{
//	var roleM = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//	var roles = new[] { "Admin", "User", "PremiumUser" };

//	foreach (var role in roles)
//	{
//		if (!await roleM.RoleExistsAsync(role))
//		{
//			await roleM.CreateAsync(new IdentityRole(role));
//		}
//	}
//}


//using (var scope = app.Services.CreateScope())
//{
//	var userM = scope.ServiceProvider.GetRequiredService<UserManager<DefaultUser>>();

//	string email = "admin@admin.com";
//	string password = "Admin4$";
//	if (await userM.FindByEmailAsync(email) == null)
//	{
//		var user = new DefaultUser
//		{
//			UserName = email,
//			Email = email,
//			EmailConfirmed = true
//		};

//		var result = await userM.CreateAsync(user, password);

//		if (result.Succeeded)
//		{
//			await userM.AddToRoleAsync(user, "Admin");
//		}
//	}
//}

//using (var scope = app.Services.CreateScope())
//{
//	var userM = scope.ServiceProvider.GetRequiredService<UserManager<DefaultUser>>();

//	string email = "user@user.com";
//	string password = "user4$";
//	if (await userM.FindByEmailAsync(email) == null)
//	{
//		var user = new DefaultUser
//		{
//			UserName = email,
//			Email = email,
//			EmailConfirmed = true
//		};

//		var result = await userM.CreateAsync(user, password);

//		if (result.Succeeded)
//		{
//			await userM.AddToRoleAsync(user, "PremiumUser");
//		}
//	}
//}
#endregion

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLocalization("da-FR");

app.Run();
