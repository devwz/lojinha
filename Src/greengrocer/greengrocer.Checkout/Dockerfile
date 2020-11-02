FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS image
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT "Development"

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["greengrocer.Checkout/greengrocer.Checkout.csproj","greengrocer.Checkout/"]
COPY ["greengrocer.Core/greengrocer.Core.csproj","greengrocer.Core/"]
RUN dotnet restore "greengrocer.Checkout/greengrocer.Checkout.csproj"
COPY . .
WORKDIR "/src/greengrocer.Checkout"
RUN dotnet build "greengrocer.Checkout.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "greengrocer.Checkout.csproj" -c Release -o /app/publish

FROM image AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "greengrocer.Checkout.dll"]