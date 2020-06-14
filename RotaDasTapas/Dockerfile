FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

# Copy csproj and restore as distinct layers
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "RotaDasTapas.dll"]