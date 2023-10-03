using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Vehicle.WebAPI.Hubs;
using Vehicle.DAL;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository;
using Vehicle.Repository.Common;
using Vehicle.Service;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    // Declare your services with proper lifetime

    builder.RegisterType<VehicleMakeService>().As<IGenericService<VehicleMakeModel>>().InstancePerDependency();
    builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>().InstancePerDependency();
    builder.RegisterType<VehicleMakeModel>().As<IVehicleMakeModel>().InstancePerDependency();

    builder.RegisterType<VehicleModelService>().As<IGenericService<VehicleModelModel>>().InstancePerDependency();
    builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>().InstancePerDependency();
    builder.RegisterType<VehicleModelModel>().As<IVehicleModelModel>().InstancePerDependency();

    builder.RegisterType<VehicleTypeService>().As<IGenericService<VehicleTypeModel>>().InstancePerDependency();
    builder.RegisterType<VehicleTypeRepository>().As<IVehicleTypeRepository>().InstancePerDependency();
    builder.RegisterType<VehicleTypeModel>().As<IVehicleTypeModel>().InstancePerDependency();

    builder.RegisterType<VehicleService>().As<IGenericService<VehicleEntityModel>>().InstancePerDependency();
    builder.RegisterType<VehicleRepository>().As<IVehicleRepository>().InstancePerDependency();
    builder.RegisterType<VehicleEntityModel>().As<IVehicleEntityModel>().InstancePerDependency();

    builder.RegisterType<EngineService>().As<IGenericService<EngineModel>>().InstancePerDependency();
    builder.RegisterType<EngineRepository>().As<IEngineRepository>().InstancePerDependency();
    builder.RegisterType<EngineModel>().As<IEngineModel>().InstancePerDependency();

    builder.RegisterType<FuelTypeService>().As<IGenericService<FuelTypeModel>>().InstancePerDependency();
    builder.RegisterType<FuelTypeRepository>().As<IFuelTypeRepository>().InstancePerDependency();

    builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
    builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerDependency();

    builder.RegisterType<RoleService>().As<IGenericService<RoleModel>>().InstancePerDependency();
    builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerDependency();

    builder.RegisterType<ColourService>().As<IGenericService<ColourModel>>().InstancePerDependency();
    builder.RegisterType<ColourRepository>().As<IColourRepository>().InstancePerDependency();

    builder.RegisterType<SeatTypeService>().As<IGenericService<SeatTypeModel>>().InstancePerDependency();
    builder.RegisterType<SeatTypeRepository>().As<ISeatTypeRepository>().InstancePerDependency();


    builder.RegisterType<SeatTypeColourService>().As<IGenericService<SeatTypeColourModel>>().InstancePerDependency();
    builder.RegisterType<SeatTypeColourRepository>().As<ISeatTypeColourRepository>().InstancePerDependency();

    builder.RegisterType<SeatsService>().As<IGenericService<SeatsModel>>().InstancePerDependency();
    builder.RegisterType<SeatsRepository>().As<ISeatsRepository>().InstancePerDependency();

    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();

});


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "VehicleProject";
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<VehicleContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/chatHub");

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<VehicleContext>();
    dataContext.Database.Migrate();
}

app.Run();
