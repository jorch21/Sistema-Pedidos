# Sistema-Pedidos

## Descripción
Cuenta con los siguientes módulos:
* Módulo de Pedidos
* Módulo de Menús
* Módulo de Clientes
* Módulo de Motorizados
* Módulo de Usuarios
* Módulo de Consultas

![Pantalla principal sistema](https://github.com/jorch21/Sistema-Pedidos/blob/main/screenshot.jpg)

---
---

## Instrucciones de conexión a la base de datos
Se debe buscar la carpeta **servicios** dentro de ServiciosWCF y se debe modidicar cada una de las clases que contiene la siguiente cadena de conexión:
```C#
SqlConnection cn = new SqlConnection("server=.;database=SistemaPedidos;integrated security=SSPI");
```
Donde:
* server = . o localhost o la dirección IP del computador. (Para esto es necesario ejectar SQL Server con **autenticación Windows**)
* database = Nombre de la Base de datos

---
---

## Instrucciones de Ejecución del Sistema
Se debe ejecutar en el navegador el servicio que se muestra en la imagen a continuación:

![Ejecucion servicio](https://github.com/jorch21/Sistema-Pedidos/blob/main/ejecutar.jpg)

Posteriormente proceder a ejecutarlo directamente en Visual Studio.
