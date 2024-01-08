using AutoMapper;
using Bo.TodoAppNTÝer.Bussines.DependencyResolver.Microsoft;
using Bo.TodoAppNTÝer.Bussines.Ýnterfaces;
using Bo.TodoAppNTÝer.Bussines.Mapping.AutoMapper;
using Bo.TodoAppNTÝer.Bussines.Services;
using Bo.TodoAppNTÝer.Bussines.ValidationRules;
using Bo.TodoAppNTÝer.DataAccess.Context;
using Bo.TodoAppNTÝer.DataAccess.UnýtOfWork;
using Bo.TodoAppNTÝer.Dtos.WorkDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUow, Uow>();
builder.Services.AddScoped<IWorkService,WorkService>();
builder.Services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
builder.Services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateDtoValidator>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TodoContext>(options => options.UseSqlServer(connectionString));

var configuration = new MapperConfiguration(opt =>
{
    opt.AddProfile(new WorkProfile());
});

var mapper = configuration.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
    RequestPath = "/node_modules"
});

app.Run();
