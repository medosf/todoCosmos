using TodoComos.Service;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Add MVC services
builder.Services.AddControllers();
var cosmosDbSettings = builder.Configuration.GetSection("CosmosDb");
builder.Services.AddSingleton<ICosmosDbService>(new CosmosDbService(
    cosmosDbSettings["DatabaseName"],
    cosmosDbSettings["ContainerName"],
    cosmosDbSettings["Account"],
    cosmosDbSettings["Key"]
));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<CheckCookieMiddleware>();


app.MapControllers();
app.UseStaticFiles(); // Serve static files
app.UseRouting(); // Enable routing
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
