FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS image
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT "Development"

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["market.ProductCatalog/market.ProductCatalog.csproj","market.ProductCatalog/"]
COPY ["market.Core/market.Core.csproj","market.Core/"]
RUN dotnet restore "market.ProductCatalog/market.ProductCatalog.csproj"
COPY . .
WORKDIR "/src/market.ProductCatalog"
RUN dotnet build "market.ProductCatalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "market.ProductCatalog.csproj" -c Release -o /app/publish

FROM image AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "market.ProductCatalog.dll"]