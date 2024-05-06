## Comandos utiles para las migraciones  y actualizaciones
Esta es una estrategia de primero crear los modelos y luegomediante las `migraciones` crear la base de datos y la entidades.

1. `Add-Migration "Create Users Table"`
2. `Udpate-Database -Verbose` 
3. `Script-migration`. Se usa mostrar lo que se va a realizar la migracion o el script que se realizara.
4. `remove-migration`. Se usara para romever una migracion echa.

## Controllers en C#
1. `[Controller]`: Esto nos dice que la clase al cula hace referencia es un controlador.
2. Para gestinar cualquier controlador dentro del archivo de `controller` existe verbos `http` que nos permite controlar la rutas de nuestra app.
3. Tenemos que usar la opcion de `crear controller con uso de acciones de Entity Framework` a la hora de crear la aplicacion de controller com `scaffolding del codigo`.
4. Un `User` puede tener roles para poder modificar o realiazar los procesos en la base de datos.

## Operaciones y consultas avanzadas 


## JWT token e .NET
Para esto primero tenemos que instala alguanas depedencias con Nuget
1. JWT
2. Sytem.IdetentifyModel.Token.JWT
3. Microsoft.AspNetCore.Authentication.JwtBearer
4. Microsoft.IdentifyModel.JsonWebTokens

## Internacionalizaicon de Aplicaciones & Control de versiones
- Este es una forma de controlar o versionas nuestra aplicaion de API RESTFUL
- La internalizaion implica la `Globalizacion` & `Localizacion`
- `La Globalizacion` implica desplegar la aplicacion en distintos lenguajes y que soporten distintas expresiones culturales
- `Locallizacion` consiste en adapatar una aplicaion `globalizada` a los parametros locales en en donde se pretente desplegar o usar.
Se prentende adapatar la aplicacion a las distintas ragos culturales donde se desplega la app.


## Gestion de versionado de la aplicacion
- Cuando se tenga que agregar nuevas caracteristicas a la aplicacion, es necesario agregar una nueva version
que muestre los cambios implementados en la aplicacion.
- Esto implica una nueva version
- No obstante, necesitamos utilizar las versione anteriores, de tal manera que se pueda 
ofrecer al cliente diferentes versiones `compatibbles` para ofrecer al cliente
- Es necesario realizar una correcta gestion de las `versiones` para poder ofrecer al cliente diferentes versiones de la aplicacion con el que se sienta agusto.

1. Pasos para gestionar la aplicacion.
- Primero tenemos que gestionar los packetes o dependencias del proyecto para realizar 
un correcto versionado de la aplicacion, estos nos ayudaran en dicha tarea.

*instalaciones importantes*: 
	- Microsoft.ApsNetCore.Mvc.Versioning
	- Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer.

Se tiene que modulizar las versiones en la carpeta de los controladores para consumir las diferentes versiones.

Para poder hacer las pruebas tenemosque usar una api externa llamada https://reandomuser.me/api && https://dummyapi/docs

- Para pasar de una version a la siguiente deben haber cambios importantes que se hay cambio en la configuacion o en la estructura de la aplicacion.
- Versiones pequenas o `micro` generalmente son cambios pequenios que no modifican el codigo o la estructura genral de la aplicacion.


## Introduccion a los conceptos de `Logs`
- Este es un forma de notificar errores o controles que se originan en la ejecucion de la aplicacion `en tiempo de ejecucion`.
- Es una forma de persistir, esun proceso de registrar eventos de los que sucese en la aplicacion en tiempo de ejecucion
- Estos `logs` se pueden persistir en una base de datos para uqe se puedan consultar
- `tracing` es una forma de `seguir` los logs o trazar los logs que ocurren los errores en la aplicacion
- Este es el flujo que siguen los procesos o el camino por donde siguien los procesos de ejecucion, de tal manera que se pueda
ver en donde ocurrio el error durante su ejecucion.
- `Tracing` y `logs` ya vienen por defecto en el framewok que se pueda usar para verificar los fallos o lo errores que se registran en la ejecucion del programa.

### Proceso de Logs
- Podemos registrar los resultados de las funciones que se han ejecutado
- Se puede registrar los resultados de las funciones que devuelvan valores que no se esperabn
- Errores en tiemo de ejecucion o compilacion
- Controlar el resultado de las informacion de una funcion para poder controlarlo y resolverlo
- Se puedeintentrar rastrear la llamada de la funciones y lainstancia de los objto para poder averigurar y poder tener unmayor control de la ejecucion de los procesos.
- Se tienen que logear los `errores` que se lanzandurante el proceso de ejecucion.
- Comprobar los erroes enel servicio
- Comprobar los argumentos de una funcion 
- Nota ✅⚠️. No es recomendable llenar con registros toda una aplicacion, es recomendable `loggear` solo lo errores criticos y con mensajes que ayuden deducir el error
para poder controlarlo. Siempre es necesaro utilizar los logs cuando es solo necesario, solo aquella informacio critirca que permita localirzar
los errores parapoder solucionarlo y resolverlo.
- Cada Log, va a tener una nivel de importancia durante su ejecucion, pueden ser criticos,informativos, warnings.
- `Crash`, cualquier caida o culquier error de la aplicacion
- Se debe registrar y `personalizar` los errores que suceden en la aplicacion para poder trararlos y solucionarlos.
- Esto es una forma de localizar los errores y `bugs` de manera sencilla y facil sin tener que buscar o cenntrarnos demasiado en error que ocurre.
- La personalizacion de los errores es muy importante para espicificar con mayor detalle el error que se origino para que el `maintenir` o quine lee el codigo pueda verles el origen y poder resolverlo facilmente.
- Podemos registrar los `logs` en archivos de texto plano o en muchos de los casos en la base de datos para su consulta.

### Donde alojar los logs ?
- Se puede alojar los `logs` en un visor de la aplicaicon
- `En una base de datos`.
- `Elastic search`, permite encontrar y gestionar los logs facilmente y agil

### Base de datos
- Se puede alojar en un `repositorio` especializado para los `logs`.
- Se debe vigilar o tener control el tamanio del almacenamiento de los `logs` de manera que no sea excesivo.

Este proceso de `logs` se aplican a cualquier marco de trabajo o para cualquier tipo de tecnologia que se usa y se desarrolla.

Se debe tener en cuanta los diferentes `niveles` de los erroes que se generan.

### Niveles 
1. `tracing`: solo se usa en un entorno de produccion.
1. `debug`: Ese se usa son en un enterno de deserrallo dado que puede mostrar informacio sensible que no se quiere
1. `logs`: Estos son los mas usuales en el entonrno de produccion ya que estan personalizdos y permite un mayor control en el `tracing` de los errores.
1. `warning`
1. `error`
1. `critico`: Perdida de datos, error de ejecuion, error a nivel de ejecucion de la aplicacion
1. `none`: No se usa, y no es recomendable en lo proyectos.


### Serilog
- Este es una herramienta que se usa para el registro y gestion de los `logs`.
- Se instala mediante `Nuget`.

*Instalaciones:*


1. Serilog
1. Serilog.AspNetCore.
1. Serilog.Sinks.File (escribir eventos en archivos planos o JSON)
1. Sinks.Console. (escribir logs directamente al terminal)
1. Sinks.Debug (escribir eventos en la ventana de debug de la app)
1. Sinks.msqlServer (permite guardar eventos dentro de la base de datos sqserverl)


Es recomendable el uso de `loggers` en vez del uso de `console.writeline()`.



## Asincronia con .NET
- La asincronia se basa en realizar tareas en paralelo y en sedungo plano.
- C#, se basa en realizar los procesos de forma asincrona. Es decir que las `tareas` o procesos no se realizan en un solo hilo de forma `sincrona`, sino de forma asincrona  en paralelo o `secuencial`.

*Sincrono*

*Asincrono*
- Para la programacion _asincrona_ se usa palabras reservadas como `Tasks`, `awiat, async`, etc.
- Esto mejora notablemente los tiempos de ejecucion general en el programa con la `programacion asyncrona`.
- 


## Nota : ⚠️⚠️
La implementacion de estos tipo de funciones complejas con Linqs lo vamos a tener que implementar dentro de una 
carpeta `services`. Esas implementaciones lo tendran que usar los `Controllers` mediante la inyeccion de dependencias.Este 
tip de proceso permite delegar la tareas a otros modulos y mas limpio el codigo.
