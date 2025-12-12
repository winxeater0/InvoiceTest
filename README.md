# Projeto — Processamento de Notas Fiscais de Serviço (NFS-e)

Este projeto foi desenvolvido como solução para um teste técnico para vaga de Desenvolvedor Backend Pleno.  
O sistema processa arquivos XML de Notas Fiscais de Serviço (NFS-e), extrai informações principais, salva em banco SQL Server e disponibiliza via API REST.

---

# 🏗 Arquitetura Utilizada
O projeto segue princípios de:

- **DDD (Domain-Driven Design)**
- **Clean Code**
- **SOLID**
- **Separação em camadas:**
/src
/Domain
/Application
/Infrastructure
/Presentation (API)
/tests
xUnit tests


---

# 🧩 Funcionalidades

### ✔ Leitura de XML  
- Abre e lê múltiplos arquivos XML  
- Valida estrutura e campos obrigatórios  
- Trata erros e inconsistências

### ✔ Extração de Informações
Extrai:  
- Número da nota  
- CNPJ do prestador  
- CNPJ do tomador  
- Data de emissão  
- Descrição do serviço  
- Valor total

### ✔ Regras de Validação
- CNPJ deve ter 14 dígitos  
- Valor > 0  
- Data válida  
- Campos obrigatórios não podem ser nulos  

### ✔ Persistência
- SQL Server  
- Entity Framework Core  
- Migrations incluídas  

### ✔ API REST  
- `GET /notas` → retorna todas as notas salvas

---

# 🐳 Execução com Docker

## 1️⃣ Criar arquivo `.env` na raiz:

SA_PASSWORD=YourStrong@Password123


## 2️⃣ Subir containers:

docker-compose up -d --build


## A API estará disponível em:

http://localhost:5000/notas


## O SQL Server em:

localhost:1433

## 🧪 Testes

Rodar testes:

dotnet test


## Os testes cobrem:

Casos positivos

Casos negativos (XML inválido, CNPJ inválido, valores incorretos etc.)

Repository

Services de aplicação

## 📄 Exemplos de XML usados

Os dois arquivos de nota fiscal usados no teste estão disponíveis em /src/Application/XmlSamples/.

## 📚 Tecnologias Utilizadas

.NET 8

C#

SQL Server 2022

Entity Framework Core

xUnit

Docker & Docker Compose

## 📁 Estrutura Final do Projeto
``` /
├── docker-compose.yml
├── .env
├── README.md
├── src/
│   ├── Domain/
│   ├── Application/
│   ├── Infrastructure/
│   │    ├── Migrations/
│   ├── Presentation/
│        ├── Controllers/
│        ├── Program.cs
│        ├── Dockerfile
└── tests/
    ├── UnittTests
```
