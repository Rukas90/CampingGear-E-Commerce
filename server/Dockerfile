FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet publish "TrailStore.Host/TrailStore.Host.csproj" -o /published /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine
WORKDIR /app
COPY --from=build /published .
EXPOSE 8080
ENTRYPOINT [ "dotnet", "TrailStore.Host.dll" ]