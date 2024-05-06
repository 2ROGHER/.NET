### Notes
Una aplicacion `sincrona` es muy perjudicial dado que si no se gestion o controla el tiempo que tarda en completarse puedo bloquear la ejecucion del resto de las tareas.

Eso implica que las aplicacones que se ejecutan, se van a bloquear el proceso que continua enla pila o la cola del proceso de la aplicacion.

Por ello es importante el uso de de `tareas` y un correcto gestion de tiempo para que alguno procesos se puedan realizar en paralelo y que no bloquen el flujo normal de la aplicacion.

