using AutoMapper;
using Bo.TodoAppNT�er.Bussines.DependencyResolver.Microsoft;
using Bo.TodoAppNT�er.Bussines.�nterfaces;
using Bo.TodoAppNT�er.Bussines.Mapping.AutoMapper;
using Bo.TodoAppNT�er.Bussines.Services;
using Bo.TodoAppNT�er.Bussines.ValidationRules;
using Bo.TodoAppNT�er.DataAccess.Context;
using Bo.TodoAppNT�er.DataAccess.Un�tOfWork;
using Bo.TodoAppNT�er.Dtos.WorkDtos;
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
