#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlazorDemo/Server/BlazorDemo.Server.csproj", "BlazorDemo/Server/"]
COPY ["BlazorDemo/Client/BlazorDemo.Client.csproj", "BlazorDemo/Client/"]
COPY ["BlazorDemo/Shared/BlazorDemo.Shared.csproj", "BlazorDemo/Shared/"]
RUN dotnet restore "BlazorDemo/Server/BlazorDemo.Server.csproj"
COPY . .
WORKDIR "/src/BlazorDemo/Server"
RUN dotnet build "BlazorDemo.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorDemo.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorDemo.Server.dll"]