#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OriginInsurance.WebApi/OriginInsurance.WebApi.csproj", "OriginInsurance.WebApi/"]
COPY ["OriginInsurance.Application/OriginInsurance.Application.csproj", "OriginInsurance.Application/"]
COPY ["OriginInsurance.Domain/OriginInsurance.Domain.csproj", "OriginInsurance.Domain/"]
RUN dotnet restore "OriginInsurance.WebApi/OriginInsurance.WebApi.csproj"
COPY . .
WORKDIR "/src/OriginInsurance.WebApi"
RUN dotnet build "OriginInsurance.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OriginInsurance.WebApi.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OriginInsurance.WebApi.dll"]

# Using Development env exclusively to facilitate testing with swagger.
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_HTTP_PORT=https://+:5000
ENV ASPNETCORE_URLS=http://+:5000