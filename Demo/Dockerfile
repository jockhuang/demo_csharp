FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App


# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
# RUN dotnet publish -c Release -o out
RUN dotnet publish -c Development -o out
# RUN dotnet ef migrations script --idempotent --output "out/EFMigration.sql"

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "Demo.dll"]

USER root
RUN apt-get update && apt-get install -y curl
