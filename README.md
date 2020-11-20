## Docker

Criando uma instância do Sql Server para Ubuntu 16.04

* Requer 2GB de memória

```sh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Passworld" -p 1433:1433 --name datacontext -d mcr.microsoft.com/mssql/server:2019-CU4-ubuntu-16.04
```

### Compilando e publicando uma imagem da aplicação ProductCatalog
cd market/Src/market
docker build -f market.ProductCatalog\Dockerfile -t api-productcatalog:v1 .
docker run -d -p 63009:80 --link datacontext --name api-productcatalog api-productcatalog:v1

### Compilando e publicando uma imagem da aplicação CartService
cd market/Src/market
docker build -f market.CartService\Dockerfile -t api-cart:v1 .
docker run -d -p 51363:80 --link datacontext --name api-cart api-cart:v1

### Compilando e publicando uma imagem da aplicação CartService
cd market/Src/market
docker build -f market.Checkout\Dockerfile -t api-checkout:v1 .
docker run -d -p 51363:80 --link datacontext --name api-checkout api-checkout:v1

### Compilando e publicando uma imagem da aplicação marketClient
cd market/Src/marketClient
docker build -t marketclient:v1 .
docker run -d -p 4200:80 --name marketclient marketclient:v1

## Kubernetes