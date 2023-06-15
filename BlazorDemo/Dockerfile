#1 - Récupérer l'image de base ==> sdk:6.0 de chez microsoft
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS buildsdk
#2 - Restorer les nugets,.... dans notre image
#2.1 me déplacer dans un dossier pour copier mon csproj
WORKDIR /src
#2.2 Copier mes csprojs
#2.2.1 Copier mon csproj principal
COPY ["Client/BlazorDemo.Client.csproj", "BlazorDemo/Client/"]
#2.2.2 Copier mon csproj dépendant (projet shared)
COPY ["Shared/BlazorDemo.Shared.csproj", "BlazorDemo/Shared/"]
#2.3 Restaurer les dépendances via dotnet restore
WORKDIR "/src/BlazorDemo/Client"
RUN dotnet restore BlazorDemo.Client.csproj  
WORKDIR "/src/BlazorDemo/Shared"
RUN dotnet restore BlazorDemo.Shared.csproj  
#3 - Copier notre code
WORKDIR "/src/BlazorDemo/Client"
COPY ["Client/", "/src/BlazorDemo/Client"]
WORKDIR "/src/BlazorDemo/Shared"
COPY ["Shared/", "/src/BlazorDemo/Shared"]
#4 -  builder notre code dans l'image
WORKDIR "/src/BlazorDemo/Shared"
RUN dotnet build BlazorDemo.Shared.csproj -c Release -o /app/build -v d
WORKDIR "/src/BlazorDemo/Client"
RUN dotnet build BlazorDemo.Client.csproj -c Release -o /app/build -v d
#5 - publish de notre realease
FROM buildsdk AS publish
RUN dotnet publish BlazorDemo.Client.csproj -c Release -o /app/publish
#6 - recupération de l'image nginx
FROM nginx:stable-alpine3.17 as Final
#7 - déplacement dans le dossier html usr/share/nginx/html
WORKDIR /usr/share/nginx/html
#8 - Copier notre publish wwwroot
COPY --from=publish /app/publish/wwwroot .
#9 - configuration de nginx