docker build -t mtoyoki/webapi.medico:latest -f WebApi.Medico/Dockerfile .
docker push mtoyoki/webapi.medico:latest 

docker build -t mtoyoki/webapi.paciente:latest -f WebApi.Paciente/Dockerfile .
docker push mtoyoki/webapi.paciente:latest 