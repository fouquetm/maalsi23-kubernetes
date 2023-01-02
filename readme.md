project source : https://www.c-sharpcorner.com/article/rabbitmq-message-queue-using-net-core-6-web-api/

1. install rabbitmq (helm chart or other way)
helm chart config:
- auth.username
- auth.password
- annotations with nginx ingress controller
dont forget to expose 5672 port on localhost

2. update api and console app configuration in related appsettings.json file
- rabbitmq hostname
- rabbitmq username
- rabbitmq password

3. run both with visual studio or command line
4. add product & read the console output