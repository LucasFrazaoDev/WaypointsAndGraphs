# Waypoints and graph

## Inteligência Artificial (IA)

O projeto possui uma IA que utiliza o algoritmo A* para encontrar o caminho mais eficiente para os personagens não jogáveis (NPCs) se movimentarem pelo ambiente.

### Algoritmo A*

O algoritmo A* é um algoritmo de busca de caminho usado para encontrar o caminho mais curto entre um ponto de partida e um ponto de destino em um grafo ponderado. Ele é amplamente utilizado em jogos para simular o movimento inteligente de NPCs, roteamento de personagens e muito mais.

No projeto implementei o algoritmo A* em um grafo para permitir que o veículo se mova de forma inteligente pelo cenário e encontre o caminho mais eficiente para alcançar seus destinos.

## Aprendizado e evolução durante o projeto
### Utilização de Métodos Privados na Unity

Neste projeto, aprendi a utilizar métodos privados ao invés de públicos na Unity para melhorar a encapsulação e a segurança do código.

#### Abordagem inicial

![MethodsBefore](Assets/Resources/Images/MethodsBefore.png)

#### Projeto final

<div>
  <img src="Assets/Resources/Images/ButtonsClass.png" alt="ButtonClass" width="500" />
  <img src="Assets/Resources/Images/MethodsAfter.png" alt="MethodsAfter" width="500" />
</div>

Principais benefícios da utilização de métodos privados:

- Encapsulação de funcionalidades: ao definir métodos como privados, restringimos seu acesso somente à classe em que estão definidos. Isso ajuda a organizar o código, ocultando detalhes de implementação desnecessários e evitando que outros scripts acessem métodos que não deveriam ser chamados externamente.
- Proteção contra modificações indesejadas: ao tornar um método privado, garantimos que ele só possa ser chamado dentro da classe em que está definido. Isso evita que outros desenvolvedores modifiquem ou sobrescrevam o comportamento de um método sem entender completamente suas dependências e implicações.
- Melhoria da segurança e estabilidade: a utilização de métodos privados ajuda a reduzir a exposição de partes sensíveis do código, protegendo-o contra acesso não autorizado e possíveis quebras de funcionalidade.

Ao longo deste projeto, refatorei o código existente, substituindo métodos públicos por métodos privados sempre que possível. Essa abordagem melhorou a estrutura do código, tornando-o mais modular, legível e menos propenso a erros.

### Uso de Delegates

O projeto faz uso de delegates no padrão Observer para desacoplar o código e permitir uma comunicação eficiente entre os componentes. 

Os delegates são tipos de dados que permitem referenciar e chamar métodos com assinaturas específicas. No caso deste projeto, foram utilizados delegates para lidar com eventos relacionados aos efeitos sonoros (SFX) e efeitos visuais (VFX) do jogo.

![DelegatesAndEvents](Assets/Resources/Images/DelegatesAndEvents.png)

Foram definidos dois delegates: `TankMoving` e `TankStopped`. O delegate `TankMoving` é acionado quando o tanque está se movendo, enquanto o delegate `TankStopped` é acionado quando o tanque parou de se mover. 

Esses delegates são usados para notificar outros componentes do jogo sobre as ações do tanque, como reprodução de sons de movimento ou exibição de partículas de poeira. Ao usar delegates, o código fica desacoplado e permite que diferentes partes do projeto respondam a eventos de forma independente, tornando-o mais flexível e fácil de manter.

![EventsMethods](Assets/Resources/Images/EventsMethods.png)

Essa abordagem baseada em delegates ajuda a promover uma arquitetura escalável e modular, permitindo que novos componentes sejam adicionados e removidos sem alterar diretamente o código existente.

## Executando o projeto no navegador
[Projeto no itch.io](https://lordfrazao.itch.io/ai-with-graph)

## Como Executar o Jogo Localmente

1. Clone este repositório em sua máquina local.
2. Abra a pasta do projeto no Unity.
3. Faça as configurações necessárias (se houver) e compile o projeto para a plataforma desejada.
4. Execute o jogo a partir do ambiente de desenvolvimento Unity ou abra o arquivo de build no navegador.


## Créditos

- Agradecimentos à doutora Penny de Byl pelos ensinamentos no seu curso de Inteligência Artificial.

## Licença

- MIT License
