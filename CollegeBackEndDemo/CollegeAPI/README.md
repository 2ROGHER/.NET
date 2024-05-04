## Comandos utiles para las migraciones  y actualizaciones
Esta es una estrategia de primero crear los modelos y luegomediante las `migraciones` crear la base de datos y la entidades.

1. `Add-Migration "Create Users Table"`
2. `Udpate-Database -Verbose` 
3. ``

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
- 
## Nota : ⚠️⚠️
La implementacion de estos tipo de funciones complejas con Linqs lo vamos a tener que implementar dentro de una 
carpeta `services`. Esas implementaciones lo tendran que usar los `Controllers` mediante la inyeccion de dependencias.Este 
tip de proceso permite delegar la tareas a otros modulos y mas limpio el codigo.
