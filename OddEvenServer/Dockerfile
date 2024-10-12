FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /app

COPY "OddEvenServer.csproj" ./
RUN dotnet restore

COPY . ./
RUN dotnet publish OddEvenServer.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine

WORKDIR /app

COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80

ENTRYPOINT ["dotnet", "OddEvenServer.dll"]
