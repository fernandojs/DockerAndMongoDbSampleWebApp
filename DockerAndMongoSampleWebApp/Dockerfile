FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY DockerAndMongoSampleWebApp/DockerAndMongoSampleWebApp.csproj DockerAndMongoSampleWebApp/
COPY DockerAndMongoSampleWebApp.Domain.ValueObjects/DockerAndMongoSampleWebApp.Domain.ValueObjects.csproj DockerAndMongoSampleWebApp.Domain.ValueObjects/
COPY DockerAndMongoSampleWebApp.Domain/DockerAndMongoSampleWebApp.Domain.csproj DockerAndMongoSampleWebApp.Domain/
COPY DockerAndMongoSampleWebApp.Infra.MongoDb/DockerAndMongoSampleWebApp.Infra.MongoDb.csproj DockerAndMongoSampleWebApp.Infra.MongoDb/
RUN dotnet restore DockerAndMongoSampleWebApp/DockerAndMongoSampleWebApp.csproj
COPY . .
WORKDIR /src/DockerAndMongoSampleWebApp
RUN dotnet build DockerAndMongoSampleWebApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DockerAndMongoSampleWebApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerAndMongoSampleWebApp.dll"]
