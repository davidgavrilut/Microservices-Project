FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY PlatformService.csproj ./
RUN dotnet restore 

COPY . ./
RUN dotnet publish -c Release -o out /app/PlatformService.csproj

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "PlatformService.dll" ]