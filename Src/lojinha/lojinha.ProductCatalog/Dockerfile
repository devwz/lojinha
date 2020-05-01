FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS image
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT "Development"

# copy csproj
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY lojinha.ProductCatalog/lojinha.ProductCatalog.csproj lojinha.ProductCatalog/
COPY lojinha.Core/lojinha.Core.csproj lojinha.Core/

RUN dotnet restore lojinha.ProductCatalog/lojinha.ProductCatalog.csproj

COPY . .
WORKDIR /src/lojinha.ProductCatalog
RUN dotnet build lojinha.ProductCatalog.csproj -c Release -o /app

# build
FROM build AS publish
RUN dotnet publish lojinha.ProductCatalog.csproj -c Release -o /app

# run
FROM image AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "lojinha.ProductCatalog.dll"]
