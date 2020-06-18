# testexperticket
Repositorio para albergar un ejemplo de CRUD sencillo con EF, OpenAPI y CQRS

# Para ejecutarlo necesitas
- Docker
- Docker-compose
- dotnet core runtime 3.1

# Tecnologías y patrones
- Patrón CQRS
- Documentación de API
- dotnet EF (code first)
- Patrón builder
- Aspnet Core middleware

# Algunas referencias
- https://medium.com/@ducmeit/net-core-using-cqrs-pattern-with-mediatr-part-1-55557e90931b
- https://restfulapi.net/http-methods/#put
- https://docs.microsoft.com/es-es/aspnet/core/fundamentals/http-context?view=aspnetcore-3.1
- https://www.rafaelacosta.net/Blog/2019/7/8/swagger-c%C3%B3mo-documentar-servicios-web-api-de-aspnet-core
- https://www.pragimtech.com/blog/blazor/put-in-asp.net-core-rest-api/
- https://docs.microsoft.com/es-es/aspnet/core/data/ef-mvc/crud?view=aspnetcore-3.1
- https://stackoverflow.com/

# Explicación de la falla
La webapi actúa como punto de entrada hacia la aplicación. MessageBroker es el punto central de la arquitectura cuya función concreta es la de pasar los mensajes a UserService. Se podría haber implementado en el mismo MessageBroker todos los métodos que en UserService pero puede ser más interesante  procesarlos de manera distribuida insertándolos en algún ServiceBus o sistema de actores como Akka.net. La capa de persistencia tiene su propio proyecto con EF code first.

No he querido profundizar en aspectos como la gestión de errores ni validaciones ni patrones de búsqueda ni seguridad y autorización.

Quería que la prueba fuera ejecutable "out of the box", así que configuré EF para utilizarse en la memoria del proceso. Porsupuesto que sólo para hacer esta POC, nunca para ootro tipo de entornos.