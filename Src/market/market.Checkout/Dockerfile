FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS image
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT "Development"

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["market.Checkout/market.Checkout.csproj","market.Checkout/"]
COPY ["market.Core/market.Core.csproj","market.Core/"]
RUN dotnet restore "market.Checkout/market.Checkout.csproj"
COPY . .
WORKDIR "/src/market.Checkout"
RUN dotnet build "market.Checkout.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "market.Checkout.csproj" -c Release -o /app/publish

FROM image AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "market.Checkout.dll"]