# Itau

- Para efetuar o build da imagem docker, executar o comando: 
  - docker build -f ".\Itau.Api\Dockerfile" --force-rm -t itauapi  "."

- Para baixar e subir os containers necessários para rodar a aplicação, é necessário executar os comandos:
  - cd .\Itau.Api\
  - docker compose up -d

# Link's para acesso:
- Web Api: http://localhost:8080/
- Elastic: http://localhost:9200/
- Kibana: http://localhost:5601/
