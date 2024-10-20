
using SLibrary.BusinessLayers;
using SLibrary.DataModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBusinnesLayers();
builder.Services.AddDataModel(builder.Configuration);

builder.Services.AddCors(options => {
    options.AddPolicy("cors", policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(config => config
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());


app.UseAuthorization();

app.MapControllers();

app.Run();

