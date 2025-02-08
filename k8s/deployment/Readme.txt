-------------------------------
- Setup inicial do Kubernetes -
-------------------------------

1. Nas configura��es do Docker Desktop, acessar a aba Kubernetes e habilitar.

2. Alterar no arquivo C:\Users\mtmorinishi\.kube\config o server para https://localhost:6443
   Toda vez que resetar o Kubernetes ser� necess�rio alterar essa configura��o novamente.

3. Realizar login no Docker Hub: docker login
   Usu�rio: mtoyoki
   Senha: 

4. Criar a imagem dos containeres e subir no Docker Hub:
> docker-publish.bat

5. Iniciar todos os containers:
> k8s\deployment\deployment.bat

6. Verificar se os pods est�o em execu��o:
> kubectl get pods

7. Ativar auto scaler:
> k8s\autoscaler\autoscaler.bat

Obs: Se for a primeira execu��o, descomentar a linha 1: "kubectl apply -f ./components.yaml"

8. Criar o banco de dados. Abrir o Package Manager Console, selecionar Default project como Infra.Data e executar o comando:
> Update-Database -StartupProject Infra.Data -Connection "Server=localhost;Database=DB_HEALTHMED;User=sa;Password=Password#2024;TrustServerCertificate=True"

--------------------------------
- Comandos Docker e Kubernetes -
--------------------------------

Para criar imagem do container Docker:
> docker build -t mtoyoki/webapi.medico:latest -f WebApi.Medico/Dockerfile .

Para subir imagem para o Docker Hub:
> docker push mtoyoki/webapi.medico:latest 

Para subir container docker individualmente no Kubernetes:
> kubectl apply -f .\k8s\webapi.medico-deployment.yaml

Para verificar os pods est�o em execu��o:
> kubectl get pods

Para verificar os logs do pos:

> kubectl logs <nome_do_pod>
Exemplo: kubectl logs webapi-56cff54d5f-drsvc

Para apagar pod:
> kubectl delete pod webapi.medico-8cb5c5445-wr5kx