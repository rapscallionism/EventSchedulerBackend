using backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddTransient<IEventService, EventService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
            builder.WithOrigins("http://localhost:5117")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//builder.Services.AddCors(options => { 
//    options.AddPolicy(
//        name: MyAllowSpecificOrigins, 
//        policy => { 
//            policy.WithOrigins("http://localhost:3000")
//                .AllowAnyHeader()
//                .AllowAnyMethod(); 
//        }
//        ); 
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

//app.MapStaticAssets();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//.WithStaticAssets();


app.MapControllerRoute(
    name: "Events",
    pattern: "/api/{controller=events}/{action=GetEvents}");

app.Run();
