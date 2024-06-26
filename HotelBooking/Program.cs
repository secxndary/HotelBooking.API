using AspNetCoreRateLimit;
using Contracts;
using HotelBooking.Extensions;
using HotelBooking.Presentation.Filters.ActionFilters;
using HotelBooking.Utility;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using NLog;
using Service.DataShaping;
using Shared.DataTransferObjects.OutputDtos;

NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
    new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
        .Services.BuildServiceProvider()
        .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
        .OfType<NewtonsoftJsonPatchInputFormatter>().First();

var builder = WebApplication.CreateBuilder(args);
LogManager.Setup().LoadConfigurationFromFile(
    string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureVersioning();

builder.Services.ConfigureResponseCaching();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.ConfigureSwagger();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddScoped<IDataShaper<RoomDto>, DataShaper<RoomDto>>();
builder.Services.AddScoped<ValidateMediaTypeAttribute>();
builder.Services.AddScoped<IRoomLinks, RoomLinks>();

builder.Services.AddControllers(config => 
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
}).AddXmlDataContractSerializerFormatters()
  .AddCustomCSVFormatter()
  .AddApplicationPart(typeof(HotelBooking.Presentation.AssemblyReference).Assembly);

builder.Services.AddCustomMediaTypes();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(
    new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.All
    }
);

app.UseCors("CorsPolicy");
app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();