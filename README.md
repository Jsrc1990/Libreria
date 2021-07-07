# LIBRERÍA

PROYECTO DE UNA LIBRERÍA EN ASP.NET MVC (FRAMEWORK)

## ASPECTOS TENICOS:

ENTITY FRAMEWORK TO ORACLE
GUID (Identificador unico) para las primary Keys
USO DE MODELOS
SWAGGER
INYECCIÓN DE DEPENDENCIAS POR MEDIANTE UNITY
LINQ
CAPAS

FALTÓ:
PONER LOS ENDPOINTS EN APPSETTINGS.JSON
PONER KENDO, AUNQUE ES UN FRAMEWORK DE JAVASCRIPT COMO MUCHOS OTROS, OSEA NO HAY PROBLEMA

## CAPAS:

![image](https://user-images.githubusercontent.com/10767482/124768679-7ae7c080-defe-11eb-9045-a3b7c7b89bd3.png)

------------------------------------------------------------ BACK:

### **Libreria.Database**

Proyecto de base de datos para almacenar los scripts

### **Libreria.Repository**

Acá está EntityFramework con conexión a OracleDB
Además están las clases repository para construir el envío y recepción de datos

### **Libreria.BackBusiness**

Es una capa intermedia de logicas, validaciones, etc, entre la Web Api y la obtención de los datos

### **Libreria.WebApi**

El servicio que expone los datos a ser consumidos por las aplicaciones del lado del Front

------------------------------------------------------------ FRONT:

### **Libreria.Proxy**

Acá está el WebClient para conectarse a la WebApi
también se preparan los request y los responses
Además Se guardan los endpoints, apikey, etc.

### **Libreria.FrontBusiness**

Es una capa intermedia de logicas, validaciones, etc, entre la capa presentación y la obtención de daots

### **Libreria.WebApp**

La aplicación web que es expuesta para el uso de los clientes

------------------------------------------------------------ COMMON:

### **Libreria.Model**

Son los modelos que son usados por las capas del Front, que son agregados como vinculos del proyecto
de Libreria.Repository autogenerados por EntityFramework

### **TransversalLibrary**

Es una librería que se usa en todas las demás capas y proyectos, en él basicamente tiene el Response<T> que se usa
en todas partes, sin embargo puede tener más clases esenciales para otros desarrollos.

# EVIDENCIAS FUNCIONALES:
  
## BACK:
  
![image](https://user-images.githubusercontent.com/10767482/124770877-4ffe6c00-df00-11eb-98d5-8e9865092c9a.png)

![image](https://user-images.githubusercontent.com/10767482/124766163-470b9b80-defc-11eb-95a9-151bbb416f59.png)

![image](https://user-images.githubusercontent.com/10767482/124766323-702c2c00-defc-11eb-9a5b-e62eb33956b7.png)
  
## FRONT:
  
  ## AUTOR
  
![image](https://user-images.githubusercontent.com/10767482/124765506-a4ebb380-defb-11eb-8735-cf17052bb07d.png)

 ### FILTRO EN LA BUSQUEDA:
  
![image](https://user-images.githubusercontent.com/10767482/124765766-ea0fe580-defb-11eb-820e-8b2264f56939.png)
  
![image](https://user-images.githubusercontent.com/10767482/124768939-b1254000-defe-11eb-92a3-b0c04424747b.png)

![image](https://user-images.githubusercontent.com/10767482/124765863-03189680-defc-11eb-8b0b-d231d9330c1e.png)
  
![image](https://user-images.githubusercontent.com/10767482/124765629-c482dc00-defb-11eb-9202-56a59fc94db0.png)

![image](https://user-images.githubusercontent.com/10767482/124767633-9a321e00-defd-11eb-8087-cb0b64c42b31.png)

![image](https://user-images.githubusercontent.com/10767482/124767699-a9b16700-defd-11eb-892e-21c23a979479.png)

# LIBRO
  
![image](https://user-images.githubusercontent.com/10767482/124768141-0876e080-defe-11eb-943d-a8efea2a3c91.png)

![image](https://user-images.githubusercontent.com/10767482/124768296-2b08f980-defe-11eb-9b18-90e17ba9b199.png)

![image](https://user-images.githubusercontent.com/10767482/124768349-352af800-defe-11eb-9756-6ab3c615343f.png)
  
![image](https://user-images.githubusercontent.com/10767482/124767914-d49bbb00-defd-11eb-86f0-81758c286e36.png)

 # ETC.



