Executar o comando para instalar as métricas a serem exibidas pelo "kubectl top node"

> kubectl apply -f ./components.yaml

Obs: O arquivo components.yaml foi baixado do site do Kubernetes. No entanto, foi preciso incluir o argumento "--kubelet-insecure-tls" para evitar erro na validação do certificado.

Executar o comando para adicionar o autoscaler no webapi:

> kubectl apply -f ./webapi.medico-autoscaler.yaml
> kubectl apply -f ./webapi.paciente-autoscaler.yaml

Verificar execução do número de pods

> kubectl get hpa