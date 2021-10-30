# Api - Projeto UStart

## EF Core

Instalar a ferramenta do EF no CLI
```
dotnet tool install --global dotnet-ef
```
https://docs.microsoft.com/pt-br/ef/core/cli/dotnet

### Migrations

Antes de criar a migrations é necessário adicionar a referência do para a biblioteca do EF Design
```bash
cd Infrastructure 
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.2

cd API
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.2

dotnet clean && dotnet build
```

Como criar as migrations
```bash
cd API
dotnet ef migrations add usuarios -c UStartContext --project ../Infrastructure/Infrastructure.csproj
dotnet ef migrations add usuarios_nome -c UStartContext --project ../Infrastructure/Infrastructure.csproj

#Criar grupo produto
dotnet ef migrations add grupo_produto -c UStartContext --project ../Infrastructure/Infrastructure.csproj

# criar cliente
dotnet ef migrations add cliente -c UStartContext --project ../Infrastructure/Infrastructure.csproj

# criar produto
dotnet ef migrations add produto -c UStartContext --project ../Infrastructure/Infrastructure.csproj
```


## Configuração do banco de dados

```
Database=d12u2mbohu86bt;
Username=ndbztyvxfbrveh;
Password=c464bb425b213bc4b0906d78a680ad3ae3f4314a1b7e0946b3ca7058c2fcae98;
Host=ec2-18-207-72-235.compute-1.amazonaws.com;
Port=5432
;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;
```


## Postman

Link
https://www.postman.com/grey-satellite-490926/workspace/ustart-postman-public

