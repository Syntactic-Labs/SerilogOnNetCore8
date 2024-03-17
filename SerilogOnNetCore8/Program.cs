using SerilogOnNetCore8.Configurations;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

#region Logging
services.AddHttpContextAccessor();
builder.Host.AddAndConfigureSerilog();
#endregion

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.InjectDependencies();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();