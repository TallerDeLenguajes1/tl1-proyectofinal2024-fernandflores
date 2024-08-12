
# BATALLA DE PROVINCIAS

# Es un juego donde de las 23 provincias obtenemos 8 de manera aleatorias, 2 ya estan precreadas (CABA y La Pampa) ya que perderan automaticamente mostrando un mensaje en particular, el juego sigue las consignas del proyecto. Eliminando de la lista a cada personaje una vez que sea derrotado y agregarndo al victorioso en el historial (salvo que se trate de la cpu). 

# el proposito de la api utilizada en este codigo es la obtencion de los personajes. La api utilizada retorna una clase que contiene una lista con las 23 provincias y sus respectivos nombres.

## Opciones de menu:

# 1 un jugador: un solo jugador elegira un personaje con el que ira hasta la victoria o la muerte. 

# 2 dos Jugadores: dos jugadores se turnaran para elegir una provincia en cada pelea hasta que solo quede una. Al terminar una pelea tendran la libertad de volver a elegir una provincia.

# 3 historial: Al jugador ganador, se le pedira un nombre para guardarlo en el historial, junto a sus provincias elegidas (en el caso de dos jugadores) o su provincia selecta (en el caso de un jugador). Tambien se guardara el listado de provincias a las que derroto.

# 4 mostrar personajes, mostrara los personajes, previamente realizando una verificacion en la existencia del json correspondiente 

# 5 eliminar historial: elimina el archivo historial.json 

# 6 resetear juego: elimina los archivos json de historial y de personajes. Volviendo asi, al jugar nuevamente, a generar 10 personajes aleatorios


## El codigo esta realizado con las herramientas brindadas a lo largo de la cursada de la materia TALLER DE LENGUAJES I, se usaron varias clases para la escritura del codigo para tratar de modularizar el mismo de la mejor manera.
