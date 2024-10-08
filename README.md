# Desafio B3: Cálculo CDB

## Backend - .NET

O backend do projeto é composto pelos seguintes componentes:

- **WebApi**: Projeto principal que deve ser configurado como inicializador. Contém a controller responsável pelo cálculo do CDB.
  - **Funcionalidades**:
    - Receber requisições de cálculo de CDB.
    - Validar os dados de entrada.
    - Retornar os resultados do cálculo.

- **Application**: Contém os serviços (cálculos e regras de negócio).
  - **Funcionalidades**:
    - Implementar a lógica de cálculo do CDB.
    - Aplicar regras de negócio específicas.
    - Gerenciar a comunicação entre a WebApi e o Domain.

- **Domain**: Inclui os domínios e interfaces.
  - **Funcionalidades**:
    - Definir as entidades do domínio.
    - Estabelecer contratos e interfaces para os serviços.

- **B3.Test**: Projeto dedicado aos testes.
  - **Funcionalidades**:
    - Executar testes unitários.
    - Garantir a qualidade e a precisão dos cálculos e das regras de negócio.

## Frontend - Angular

O frontend foi desenvolvido utilizando Angular e Angular Material.

### Funcionalidades:

- **Interface de Usuário**:
  - Formulário para entrada de dados necessários para o cálculo do CDB.
  - Exibição dos resultados do cálculo.

- **Interação com o Backend**:
  - Enviar requisições para a WebApi.
  - Receber e exibir os resultados do cálculo.

### Passos para executar o projeto:

1. Instale as dependências:
   ```bash
   npm install
   ```
2. Inicie o frontend:
   ```bash
   npm start
   ```

---
