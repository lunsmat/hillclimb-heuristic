O seguinte trabalho implementa a Hill Climbing para o seguinte problema

<img src="/modelagem.jpg" alt="Modelo" />

A solução é dada por gerar uma solução aleatória para o problema colocando em um array a solução sem repetir os valores, após isso roda em loop cada iteração do programa até que se alcance 500 iterações ou que a melhor vizinho gerado seja igual ao estado atual da solução, em caso que não seja igual, mas que a função objetivo permaneça igual, o problema mistura a solução para que chegue em novos resultados.

Em cada iteração acontece o seguinte caso:

- Gera o melhor vizinho. Os vizinhos são gerados por meio de testar todas as possibilidades do vizinho.
- Verifica se o melhor vizinho é a mesma solução atual, se sim parar iterações
- Caso vizinho diferente e fun~çao objetiva igual, misturar a solução no melhor vizinho
- Incorporar esse melhor vizinho na solução atual
- Aumenta a iteração

As constantes definidas foram:
- Máximo de iterações: 500

O tempo em média do algoritmo está em volta dos 87,98ms

Para rodar basta ter o dotnet na versão 8.0 e rodar o comando `dotnet run`

Quando o algoritmo é rodado ele retorna um resultado como o exemplo abaixo:

```
Media de Tempo: 86,98ms
Media de Iterações: 4,4 Iterações
Desvio Padrão de Tempo: 42,150838663068136ms
Desvio Padrão de Iterações: 1,3564659966250538 Iterações
Menor Tempo: 27ms
Menor Número de Iterações: 2 Iterações

5 Melhores resultados

Estado Inicial: 2 6 4 7 5 1 0 3 8
Melhor estado: 7 6 0 3 4 5 8 2 1
Objetivo: 79
Iterações: 6
Tempo de Execução: 152ms

Estado Inicial: 2 0 6 4 3 5 7 8 1
Melhor estado: 7 6 0 3 4 5 8 2 1
Objetivo: 79
Iterações: 4
Tempo de Execução: 139ms

Estado Inicial: 7 8 5 3 2 0 1 4 6
Melhor estado: 7 5 8 3 4 2 6 0 1
Objetivo: 81
Iterações: 4
Tempo de Execução: 227ms

Estado Inicial: 7 0 6 4 8 5 1 2 3
Melhor estado: 4 1 8 3 0 5 6 2 7
Objetivo: 81
Iterações: 5
Tempo de Execução: 220ms

Estado Inicial: 2 3 4 5 8 1 6 0 7
Melhor estado: 2 1 8 3 4 5 6 0 7
Objetivo: 81
Iterações: 3
Tempo de Execução: 203ms
```