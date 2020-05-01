## Docker

Criando uma instância do Sql Server para Ubuntu 16.04

* Requer 2GB de ram

```sh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password" -p 1433:1433 --name datacontext -d mcr.microsoft.com/mssql/server:2019-CU4-ubuntu-16.04
```

Compilando e publicando uma imagem da aplicação ProductCatalog

```sh
docker build -f lojinha.ProductCatalog\Dockerfile -t productcatalog:v1 .

docker run -d -p 63009:80 --link datacontext --name productcatalog productcatalog:v1
```
