FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

COPY . . 

RUN dotnet restore

RUN dotnet build -c Release

RUN dotnet publish -c Release -o out

WORKDIR /app/out

EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "BookStore.dll"]