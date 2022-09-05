using DotnetCore6WebApiTemplate.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.WebHost.UseUrls("https://0.0.0.0:5031");
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.ConfigureForwardHeader();

//builder.Services.AddDbContext<BasketContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BasketDbConnection")));
//builder.Services.AddDbContext<WapPortalContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WapPortalConnection")));
//builder.Services.AddDbContext<BkashPaymentGatewayContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BkashPaymentGateWayConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.ConfigureRepositoryInjections();

//builder.Services.ConfigureJWTAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
    app.UseHsts();

app.UseHttpsRedirection();

app.UseCors();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
