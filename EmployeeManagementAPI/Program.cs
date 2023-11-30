var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(policies =>
{
    policies.AddDefaultPolicy(bydefault =>
    {
        bydefault.AllowAnyHeader();
        bydefault.AllowAnyMethod();
        bydefault.AllowAnyOrigin();
    });


    //We will have to add [CORS("customerPolicy")] Above controller name in controller class so that, only customers from Amazon.com can make only GET and POST calls
    policies.AddPolicy("DepartmentsPolicy", policy =>
    {
        policy.AllowAnyHeader().WithOrigins("https://localhost:7295/").WithMethods(new string[] { "GET", "POST" });
    });
});

builder.Services.AddScoped(typeof(EmployeeManagementAPI.Models.EF.EmployeeDetailsDbContext));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
