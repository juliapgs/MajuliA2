# Majuli Crochê - Sistema de Gestão de Loja de Crochê

Este é um projeto de um sistema de gestão para a loja **Majuli Crochê**, com todos os endpoints devem esta documentados no swagger. 

## Sobre o Projeto

O **Majuli Crochê** é uma aplicação API REST com .net core que foi projetada para atender às necessidades de uma loja de crochê que vende produtos como tapetes, caminhos de mesa, centros de mesa e outros itens de decoração artesanal. A aplicação possui uma série de funcionalidades para gerenciar as operações diárias da loja de forma eficiente e segura.

## Principais Funcionalidades

- **Gerenciamento de Produtos**: Cadastro, visualização, atualização e exclusão de produtos vendidos na loja, incluindo detalhes como nome, tamanho, cor e preço.
- **Sistema de Vendas**: Registro de vendas, com cálculo automático de valores e aplicação de cupons de desconto. Permite visualizar as vendas feitas e suas informações, como forma de pagamento e detalhes de contato.
- **Controle de Fornecedores**: Cadastro de fornecedores que fornecem os materiais necessários para a produção dos itens de crochê, com informações de contato e detalhes relevantes.
- **Gerenciamento de Materiais**: Controle dos materiais utilizados na confecção dos produtos de crochê, com registro de quantidade, tipo e fornecedor associado.
- **Gerenciamento de Cupons**: Sistema para criar e gerenciar cupons de desconto que podem ser aplicados às vendas, com opções de configurar a validade e o valor do desconto.
- **Categorias de Produtos**: Organização dos produtos por categorias, facilitando a navegação e o gerenciamento do catálogo.

## CRUDs Implementados

1. **Produto**: 
   - Funcionalidades: Cadastro, edição, exclusão e listagem de produtos com atributos como nome, tamanho, cor, e preço.
2. **Venda**: 
   - Funcionalidades: Registro de vendas com cálculo do valor total, aplicação de cupons e registro de informações como endereço e forma de pagamento.
3. **Fornecedor**: 
   - Funcionalidades: Cadastro e gerenciamento de fornecedores com detalhes como nome, e-mail, telefone e informações de contato.
4. **Cupom**: 
   - Funcionalidades: Criação e gerenciamento de cupons de desconto com atributos como código, valor de desconto e data de validade.
5. **Categoria**: 
   - Funcionalidades: Organização dos produtos por categorias, permitindo o gerenciamento e a categorização do catálogo de forma eficiente.
6. **Material**:
   - Funcionalidades: Cadastro, atualização e controle de materiais utilizados na confecção dos produtos, incluindo detalhes como tipo, quantidade e fornecedor.
