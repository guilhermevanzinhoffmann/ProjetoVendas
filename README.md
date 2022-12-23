# ProjetoVendas
Teste Convicti.  
Para rodar o projeto (Ambiente windows):  
1 - Certifique-se que o ambiente Docker esteja instalado na sua máquina  
2 - Faça download ou clone este repositório  
3 - Após obter os arquivos do projeto, navegue pelo terminal até a paste ControleVendas  
4 - Na pasta ControleVendas, digite docker compose up  
5 - Espere terminar o processo  
6 - Para acessar o Swagger (endpoints da api) digite no navegador https://localhost:PORTA/swagger/index.html  
  6.1 - Substitua PORTA pela porta correta que você encontra digitando no terminal docker compose ps  
  6.2 - Encontre a porta que corresponda ao serviço ControleVendas  
7 - Para acessar os endpoints é necessário estar autenticado (Autenticação JWT)  
8 - Para autenticar, acesse o endpoint de login  
  8.1 - Informe algum email e o password disponibilizados na documentação do projeto  
  8.2 - Copie o token que a requisição retornar  
  8.3 - Vá para o topo da página e clique no botão Autheticate  
  8.4 - No campo de texto digite Bearer[space] e depois cole o token (sem as aspas)  
9 - Você terá acesso aos endpoints que correspondem ao seu nível de privilégios, de acordo com o role do usuário informado no login  .


Sobre testes unitários:    
Não foi possível desenvolver os testes unitários por falta de tempo. Caso possa interessar, enytre em contato para ter acesso a um repositório contendo testes unitários feitos por mim.   
