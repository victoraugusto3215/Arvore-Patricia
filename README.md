# Árvore PATRICIA - Seminário AED II (2025)

Este projeto foi desenvolvido como parte do seminário da disciplina de **Algoritmos e Estruturas de Dados II**, ministrada pela professora Roselene Henrique Pereira Costa. O objetivo é apresentar, de forma didática e interativa, o funcionamento da **Árvore PATRICIA**, uma estrutura de dados eficiente para buscas baseadas em prefixos binários.

## 🧠 Sobre a Árvore PATRICIA

A **Árvore PATRICIA** (Practical Algorithm to Retrieve Information Coded in Alphanumeric) foi proposta por **Donald R. Morrison** em **1968**, com foco em buscas eficientes sobre grandes volumes de dados alfanuméricos.

Ela é uma variação otimizada da Trie, eliminando ramos redundantes e utilizando a posição do primeiro bit divergente como critério de decisão.

### 🔎 Características principais:

- Compacta e eficiente para buscas por prefixo.
- Dispensa balanceamento, pois a estrutura depende da ordem dos bits.
- Utilizada em sistemas de dicionários, compressão, redes, e bancos de dados.

---

## ⚙️ Funcionalidades da Aplicação

A aplicação foi desenvolvida em **C# com Windows Forms** e possui uma interface simples para demonstrar o funcionamento da árvore:

- **Inserção** de palavras: convertidas em binário, respeitando a lógica da PATRICIA.
- **Busca** de palavras: com realce visual no nó correspondente.
- **Remoção** de palavras: com ajuste de ponteiros.
- **Visualização gráfica** da estrutura da árvore com nós internos e folhas destacadas.

---

### 🛠 Aplicações Práticas

A Árvore PATRICIA é amplamente utilizada em:

- **Bancos de dados**: como indexador de chaves binárias;
- **Roteadores e redes**: para encontrar o melhor caminho utilizando prefixos de endereços IP (CIDR);
- **Redes P2P**: como estrutura base para busca eficiente e roteamento descentralizado;
- **Blockchain**: em modelos de escalabilidade e descentralização;
- **Processamento de XML**: otimizando a manipulação de grandes documentos com estrutura hierárquica complexa.

Essas aplicações reforçam a versatilidade da Árvore PATRICIA no tratamento de dados complexos e volumosos.

---

## 💻 Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET Windows Forms
- **Recursos**: Desenho gráfico com GDI+, estrutura recursiva, manipulação de bits

---

## 📊 Comparação com Outras Árvores

| Estrutura       | Busca por Prefixo | Uso de Memória | Balanceamento |
|-----------------|------------------|----------------|----------------|
| Trie            | Ótima            | Alta           | Não necessário |
| Árvore Patricia | Ótima            | Baixa          | Não necessário |
| AVL / Red-Black | Média             | Média          | Necessário     |

---

## 📚 Referências

- Morrison, D. R. (1968). *Practical Algorithm to Retrieve Information Coded in Alphanumeric*.
- Cormen, T. H. et al. *Algoritmos: Teoria e Prática*.
- https://en.wikipedia.org/wiki/Radix_tree
- Slides e explicações produzidos pelo grupo.

---

## 📌 Instruções para Executar

1. Abra o projeto no Visual Studio.
2. Compile e execute a solução.
3. Utilize o campo de entrada para inserir, buscar ou remover palavras.
4. A visualização gráfica é atualizada automaticamente.
