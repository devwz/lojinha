## Docker

Criando uma instância do Sql Server para Ubuntu 16.04

* Requer 2GB de ram

```sh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Passworld" -p 1433:1433 --name datacontext -d mcr.microsoft.com/mssql/server:2019-CU4-ubuntu-16.04
```

Compilando e publicando uma imagem da aplicação ProductCatalog

cd lojinha/Src/lojinha
```sh
docker build -f lojinha.ProductCatalog\Dockerfile -t productcatalog:v1 .

docker run -d -p 63009:80 --link datacontext --name productcatalog productcatalog:v1
```

Compilando e publicando uma imagem da aplicação lojinhaClient

cd lojinha/Src/lojinhaClient
```sh
docker build -t lojinhaclient:v1 .

docker run -d -p 4200:80 --name lojinhaclient lojinhaclient:v1
```