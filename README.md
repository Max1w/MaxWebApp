# 🏛️ MaxWebApp

## Descrição

O **MaxWebApp** é uma aplicação web para gestão de patrimônio, desenvolvida em **ASP.NET Web Forms (.NET Framework 4.8.1)**. Ela permite cadastrar, visualizar, editar e dar baixa em itens patrimoniais, com cálculo automático de depreciação integrado.

Foi construída com **ASP.NET Web Forms**, **Bootstrap 5**, **jQuery** e **SQL Server**, se comunicando com a **PatrimonioAPI** para todas as operações de dados (GET, POST, PUT, DELETE).

O projeto foi criado para servir como interface visual (front-end web) do sistema de controle de patrimônio, complementando a PatrimonioAPI. O usuário pode cadastrar bens, calcular depreciação automaticamente, acompanhar o inventário completo e registrar saídas/baixas de itens.

---

## Instrução de Instalação

**Pré-requisitos:**
- Visual Studio 2019 ou superior (com workload de desenvolvimento Web ASP.NET)
- .NET Framework 4.8.1
- SQL Server
- **[PatrimonioAPI](https://github.com/seu-usuario/Patrimonio)** rodando em `https://localhost:7279`

**1. Clone o repositório**

```bash
git clone https://github.com/seu-usuario/MaxWebApp.git
```

**2. Abra a solução no Visual Studio**

```
MaxWebAppA.sln
```

**3. Restaure os pacotes NuGet**

No Visual Studio: `Tools > NuGet Package Manager > Restore NuGet Packages`  
Ou via terminal:

```bash
nuget restore MaxWebAppA.sln
```

**4. Configure a connection string**

No arquivo `Web.config`, ajuste a connection string para o seu banco de dados local:

```xml
<connectionStrings>
  <add name="ConectandoAoBD"
       connectionString="Data Source=SEU_SERVIDOR;Initial Catalog=SUA_BASE;User ID=SEU_USUARIO;Password=SUA_SENHA;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

**5. Configure a URL da API**

| Arquivo | Ocorrências |
|---------|-------------|
| `PageEntrada/Entrada.aspx.cs` | `POST /v1/TodosOsItens` |
| `PageSaida/Saida.aspx.cs` | `DELETE /v1/TodosOsItens` |
| `PageInventario/InventarioDeItens.aspx.cs` | `GET` e `PUT /v1/TodosOsItens` |

**6. Inicie a PatrimonioAPI**

A aplicação depende da PatrimonioAPI estar rodando. Inicie-a antes de rodar o MaxWebApp.

**7. Execute o projeto**

No Visual Studio, pressione `F5` ou clique em **IIS Express** para iniciar.

---

## Instruções de Uso

Ao iniciar, a aplicação abre na **página inicial** com os cards de navegação para cada módulo.

### Páginas disponíveis

---

#### 🏠 Home (`Default.aspx`)

Página inicial com cards de acesso rápido para os módulos: Entrada, Saída, Inventário e Estoque.

---

#### ➕ Entrada (`/PageEntrada/Entrada.aspx`)

Formulário completo para **cadastrar um novo item patrimonial**.

- Preencha os dados do item (código, placa, descrição, tipo, grupo etc.)
- Informe o valor de aquisição, vida útil e taxa de depreciação anual
- Clique em **"Calcular"** para que o sistema preencha automaticamente:
  - Valor Residual
  - Valor Depreciável
  - Valor Depreciado
  - Saldo a Depreciar
  - Valor Líquido Contábil
- Clique em **"Salvar"** para enviar o item à API

**Validações aplicadas:**
- Campos obrigatórios não podem estar vazios
- Limite de caracteres por campo
- Verificação de duplicidade por `codigo_item` e `placa_item`

---

#### 📋 Inventário (`/PageInventario/InventarioDeItens.aspx`)

Lista todos os itens cadastrados em uma **GridView paginada**.

- Clique em um item para abrir o formulário de edição lateral
- Edite os campos desejados e clique em **"Salvar Alterações"**
- As mesmas validações da Entrada são aplicadas na edição
- Suporta paginação para grandes volumes de dados

---

#### 🗑️ Saída (`/PageSaida/Saida.aspx`)

Página para **dar baixa (excluir) itens patrimoniais**.

- Exibe a lista de itens em GridView paginada
- Selecione um ou mais itens via checkbox
- Clique em **"Excluir Selecionados"** para remover em lote via API

---

#### ℹ️ Sobre (`/PageSobre/About.aspx`) e Contato (`/PageContact/Contact.aspx`)

Páginas informativas do sistema.

---

### Funcionalidades extras

| Recurso | Descrição |
|---------|-----------|
| **Dark Mode** | Botão na navbar alterna o tema escuro, com preferência salva no `localStorage` |
| **Notificações** | Alertas visuais de sucesso, erro, duplicidade e limite de caracteres via JavaScript |
| **Cálculo automático** | Depreciação calculada no servidor (C#) e também disponível via JavaScript no cliente |

---

### Estrutura do Projeto

```
MaxWebApp/
├── Calc/
│   └── CalculoDepreciacaoDosItens.cs   # Lógica de cálculo de depreciação
├── Modelo/
│   └── ItemModelo.cs                   # Modelo de dados do item
├── PageEntrada/
│   └── Entrada.aspx(.cs)               # Página de cadastro de itens
├── PageInventario/
│   └── InventarioDeItens.aspx(.cs)     # Página de listagem e edição
├── PageSaida/
│   └── Saida.aspx(.cs)                 # Página de baixa/exclusão
├── PageSobre/
│   └── About.aspx(.cs)                 # Página sobre
├── PageContact/
│   └── Contact.aspx(.cs)               # Página de contato
├── Scripts/
│   ├── CalculoDepreciacao.js           # Cálculo de depreciação no cliente
│   ├── Validacao.js                    # Validações de formulário
│   ├── Notificacao.js                  # Notificações visuais
│   └── configuracao.js                 # Dark mode
├── MetodosBancoDeDadosApi.cs           # Métodos HTTP para consumo da API
├── Operacao.cs                         # Consultas diretas ao SQL Server
├── ValidacaoDosCampos.cs               # Validações de negócio
├── Site.Master                         # Layout principal (navbar, footer)
├── Web.config                          # Connection string e configurações
└── Default.aspx                        # Página inicial
```

## Licença

Este projeto está sob a licença [MIT](https://opensource.org/licenses/MIT).
