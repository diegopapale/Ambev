# Projeto Ambev - DeveloperStore Sales API

1. Título do Projeto
DeveloperStore Sales API

2. Descrição
Esta API gerencia registros de vendas, permitindo a criação, leitura, atualização e exclusão de vendas, com regras de negócio específicas e eventos relacionados ao ciclo de vida das vendas.

3. Requisitos do Projeto
- Linguagem/Frameworks: .NET 8.0.
- Banco de Dados: PostgreSQL.
- Ferramentas Necessárias: Git, PostgreSQL e .NET 8.

4. Configuração do Ambiente
- Clonagem do Repositório:
  git clone https://github.com/seu-usuario/seu-repositorio.git
- Instalação de Dependências:
  Comandos para restaurar pacotes: dotnet restore.
- Configuração de Acesso ao banco de dados:
  Configurar no appsettings.json, na sessão ConnectionStrings >> DefaultConnection.

5. Execução do Projeto
- Como rodar o projeto localmente:
  Definir o Projeto Developerstore.API, como projeto de inicialização padrão.
  Utilizar comando dotnet run
- Como acessar a API:
  https://localhost:5000/swagger/index.html

6. Estrutura da API
- Endpoints principais da API:
POST /api/vendas: Cria uma nova venda.
GET /api/vendas/{id}: Busca uma venda pelo ID.
PUT /api/vendas/{id}: Atualiza uma venda existente.
DELETE /api/vendas/{id}: Cancela uma venda.

7. Documentação
Como acessar ou gerar a documentação da API, com o Swagger:
Acesse http://localhost:5000/swagger.

8. Tecnologias Usadas
Tecnologias e frameworks utilizados:
.NET 8
Entity Framework
PostgreSQL
Swagger

9. Regras de Negócio
- Compras acima de 4 itens têm 10% de desconto.
- Compras entre 10 e 20 itens têm 20% de desconto.
- Não é permitido vender acima de 20 itens.
