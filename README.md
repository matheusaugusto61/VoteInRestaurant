# **Voto em restaurante**
> Esse projeto foi desenvolvido para um processo seletivo

## **Instalação e pré-requisitos**

💻 Requisitos:
* IDE(Integrated Development Environment): [Visual Studio](https://visualstudio.microsoft.com/pt-br/#vs-section);
* [Docker](https://www.docker.com);   
* [Git](https://git-scm.com/downloads).
* Conta no [github](https://github.com/signup?ref_cta=Sign+up&ref_loc=header+logged+out&ref_page=%2F&source=header-home)

Com todos os requisitos preenchidos, vamos para a criação do ambiente local, onde ficarão os arquivos do projeto.

### Baixando o projeto:

1. Clique no botão **fork**, localizado no canto superior direito. Fork nada mais é do que uma cópia atual do repositório;
2. Depois de realizar o fork, uma cópia do projeto ficará disponível em seus repositorios. Copie a URL do repositório e guarde-a pois precisaremos dela mais tarde;
3. Inicie o terminal do gitbash ou um terminal de sua preferência;
  - Navegue até a pasta que você deseja que os arquivos do projeto sejam armazenados.
4. Comandos:
 - Crie um novo repositório git, com o seguinte comando: 
```
git init
```
Usaremos esse repositório para receber um repositório remoto existente.

  - Defina e relacione um repositório remoto, digitando o seguinte comando: 
```
git remote add origin https://github.com/matheusaugusto61/VoteInRestaurant.git
```
E para finalizar baixe o conteúdo disponível na url que você informou no passo anterior, com o comando:
```
git pull origin master
```
5. Crie um container docker utilizando esse comando::
```
docker run --name mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=root -d mariadb:latest
```

Pronto! A partir deste momento todos os arquivos estarão na pasta que você definiu anteriormente.


