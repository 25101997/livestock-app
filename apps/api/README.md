dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package AutoMapper --version 12.0.1
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1

docker run -it --rm -v "$PWD":/app -w /app -e DOTNET_CLI_HOME=/app -p 5109:5109 dotnet-engine:1.01 sh

dotnet clean
dotnet restore
dotnet build
dotnet run --urls "http://0.0.0.0:5109"