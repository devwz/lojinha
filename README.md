## Docker

Criando uma instância do Sql Server para Ubuntu 16.04

* Requer 2GB de memória

```sh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Passworld" -p 1433:1433 --name datacontext -d mcr.microsoft.com/mssql/server:2019-CU4-ubuntu-16.04
```

### Compilando e publicando uma imagem da aplicação ProductCatalog
cd lojinha/Src/lojinha
docker build -f lojinha.ProductCatalog\Dockerfile -t api-productcatalog:v1 .
docker run -d -p 63009:80 --link datacontext --name api-productcatalog api-productcatalog:v1

### Compilando e publicando uma imagem da aplicação CartService
cd lojinha/Src/lojinha
docker build -f lojinha.CartService\Dockerfile -t api-cart:v1 .
docker run -d -p 51363:80 --link datacontext --name api-cart api-cart:v1

### Compilando e publicando uma imagem da aplicação CartService
cd lojinha/Src/lojinha
docker build -f lojinha.Checkout\Dockerfile -t api-checkout:v1 .
docker run -d -p 51363:80 --link datacontext --name api-checkout api-checkout:v1

### Compilando e publicando uma imagem da aplicação lojinhaClient
cd lojinha/Src/lojinhaClient
docker build -t lojinhaclient:v1 .
docker run -d -p 4200:80 --name lojinhaclient lojinhaclient:v1

## Kubernetes