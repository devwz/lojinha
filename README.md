## Docker

Criando uma instância do Sql Server para Ubuntu 16.04

* Requer 2GB de memória

```sh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=password" -p 1433:1433 --name datacontext -d mcr.microsoft.com/mssql/server:2019-CU4-ubuntu-16.04
```

### Compilando e publicando uma imagem da aplicação ProductCatalog
```sh
cd market/Src/market
docker build -f market.ProductCatalog\Dockerfile -t api-productcatalog:v1 .
docker run -d -p 31402:80 --link datacontext --name api-productcatalog api-productcatalog:v1
```

### Compilando e publicando uma imagem da aplicação CartService
```sh
cd market/Src/market
docker build -f market.CartService\Dockerfile -t api-cart:v1 .
docker run -d -p 31404:80 --link datacontext --name api-cart api-cart:v1
```

### Compilando e publicando uma imagem da aplicação CheckoutService
```sh
cd market/Src/market
docker build -f market.Checkout\Dockerfile -t api-checkout:v1 .
docker run -d -p 31406:80 --link datacontext --name api-checkout api-checkout:v1
```

### Compilando e publicando uma imagem da aplicação marketClient
```sh
cd market/Src/marketClient
docker build -t marketclient:v1 .
docker run -d -p 31408:80 --name marketclient marketclient:v1
```

## Kubernetes

### Configurar secret para Sql Server
```sh
kubectl create secret generic mssql --from-literal=SA_PASSWORD="password"
```

### Rodar deployment para o Sql Server
```sh
kubectl apply -f data-mssql-deployment.yaml
```