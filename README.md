https://github.com/domaindrivendev/Swashbuckle.AspNetCore

dotnet add package Swashbuckle.AspNetCore

services.AddMvc();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});