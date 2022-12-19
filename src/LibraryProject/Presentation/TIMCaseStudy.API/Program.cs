using FluentValidation.AspNetCore;
using TIMCaseStudy.API.Infrastructure.ActionFilters;
using TIMCaseStudy.API.Infrastructure.Extensions;
using TIMCaseStudy.Application;
using TIMCaseStudy.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServicesRegistration();
builder.Services.AddApplicationServicesRegistration();

// Add Policy
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("*", "*").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));

builder.Services.AddControllers(options => {
    options.Filters.Add<ValidateModelStateFilter>();
})
.AddFluentValidation();

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

//app.ConfigureExceptionHandler();
app.ConfigureExceptionHandling(app.Environment.IsDevelopment());

app.UseAuthorization();

app.MapControllers();

app.Run();
