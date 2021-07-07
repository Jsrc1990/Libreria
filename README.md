# Libreria

PROYECTO DE UNA LIBRERÍA EN ASP.NET MVC (FRAMEWORK)

#CAPAS:

------------------------------------------------------------ BACK:

**Libreria.Database**

Proyecto de base de datos para almacenar los scripts

**Libreria.Repository**

Acá está EntityFramework con conexión a OracleDB
Además están las clases repository para construir el envío y recepción de datos

**Libreria.BackBusiness**

Es una capa intermedia de logicas, validaciones, etc, entre la Web Api y la obtención de los datos

**Libreria.WebApi**

El servicio que expone los datos a ser consumidos por las aplicaciones del lado del Front

------------------------------------------------------------ FRONT:

**Libreria.Proxy**

Acá está el WebClient para conectarse a la WebApi
también se preparan los request y los responses
Además Se guardan los endpoints, apikey, etc.

**Libreria.FrontBusiness**

Es una capa intermedia de logicas, validaciones, etc, entre la capa presentación y la obtención de daots

**Libreria.WebApp**

La aplicación web que es expuesta para el uso de los clientes

------------------------------------------------------------ COMMON:

**Libreria.Model**

Son los modelos que son usados por las capas del Front, que son agregados como vinculos del proyecto
de Libreria.Repository autogenerados por EntityFramework

**TransversalLibrary**

Es una librería que se usa en todas las demás capas y proyectos, en él basicamente tiene el Response<T> que se usa
en todas partes, sin embargo puede tener más clases esenciales para otros desarrollos.







