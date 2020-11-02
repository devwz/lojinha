FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS image
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT "Development"

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["greengrocer.CartService/greengrocer.CartService.csproj","greengrocer.CartService/"]
COPY ["greengrocer.Core/greengrocer.Core.csproj","greengrocer.Core/"]
RUN dotnet restore "greengrocer.CartService/greengrocer.CartService.csproj"
COPY . .
WORKDIR "/src/greengrocer.CartService"
RUN dotnet build "greengrocer.CartService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "greengrocer.CartService.csproj" -c Release -o /app/publish

FROM image AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "greengrocer.CartService.dll"]