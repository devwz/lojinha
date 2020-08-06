FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS image
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT "Development"

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["lojinha.CartService/lojinha.CartService.csproj","lojinha.CartService/"]
COPY ["lojinha.Core/lojinha.Core.csproj","lojinha.Core/"]
RUN dotnet restore "lojinha.CartService/lojinha.CartService.csproj"
COPY . .
WORKDIR "/src/lojinha.CartService"
RUN dotnet build "lojinha.CartService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lojinha.CartService.csproj" -c Release -o /app/publish

FROM image AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lojinha.CartService.dll"]