FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS image
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT "Development"

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["lojinha.Checkout/lojinha.Checkout.csproj","lojinha.Checkout/"]
COPY ["lojinha.Core/lojinha.Core.csproj","lojinha.Core/"]
RUN dotnet restore "lojinha.Checkout/lojinha.Checkout.csproj"
COPY . .
WORKDIR "/src/lojinha.Checkout"
RUN dotnet build "lojinha.Checkout.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lojinha.Checkout.csproj" -c Release -o /app/publish

FROM image AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lojinha.Checkout.dll"]