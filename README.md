
# BATALLA DE PROVINCIAS

## Presentacion
 Es un juego donde de las 23 provincias obtenemos 8 de manera aleatorias, 2 ya estan precreadas (CABA y La Pampa) ya que perderan automaticamente mostrando un mensaje en particular, el juego sigue las consignas del proyecto. Eliminando de la lista a cada personaje una vez que sea derrotado y agregarndo al victorioso en el historial (salvo que se trate de la cpu). El sistema de combate es el mismo que el propuesto, salvo por una leve variacion en el rango de aleatoriedad de la efectividad llevandola del intervalo (1,100) a (40,100) para poder tener asi combates mas cortos.

## API

La api utilizada "https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre" que me brinda dos clases, una clase "pronvica" con el nombre e id y la clase principal "argentApi" que contiene el total de provincias y una lista de la clase anteriormente nombrada. La utilice de forma de poder obtener todos los personajes del juego de una manera mucho mas sencilla y eficaz ya que me da la lista de pronvicas, con un id unico para cada una de ellas lo que me permitio hacer personalizaciones en el codigo (como los easter egg).
La clase pronvicas fue modificada, se le agrego propiedad de la clase "caracteristicas" para darle a cada pronvicia los stats. Tambien se modificaron los nombres de las clases dada por la API, por ejemplo "Root" es "argentApi".

 ## Funcionamiento de combate

 El sistema de combate que se implemento fue el dado por la catedra, con unica modificacion en el rango de aleatoriedad de efectivdad, modificado a 40-100 para obtener batallas mas cortas. 
 El sistema de combate se basa en 10 personajes (provincias) y en cada batalla se mostrata en pantalla el daño realizado y recibido por cada uno de los personajes participantes de la pelea.
 En el modo un jugador, el usuario seleccionara un personaje con el que intentara derrotar a las 9 restantes, al derrotar a una batalla se la eliminara de la lista hasta que quede solo la provincia seleccionada  por el jugador. Si lo logra su nombre estara en el historial. Las provicias contricantes apareceran en un orden aleatorio, mostrando la lista restante de pronvicias al finalizar cada batalla.
En el modo dos jugadores ambos usuarios seleccionaran un personaje por cada batalla (el codigo controla que sean personajes validos y unicos, es decir, jugador 1 y jugador 2 no podran seleccionar el mismo personaje en una misma batalla) se eliminara al perderor de la lista, hasta reducir en dos personajes la lista final, en la que jugador 1 y jugador 2 deberan seleccionar nuevamente sus personajes. El ganador de esta ultima ronda sera quien se quede con la victoria definitiva, a modo de "batalla de oro".

## opciones de borrado

se añadieron las opciones de borrado de los archivos json en el menu. Borrado de historial, borrara el archivo json del historial, mientras que Reinciar juego borrara el archivo json del historial y de las provincias.
### easter egg y extras

El juego contiene dos easter eggs, las pronvicas de La Pampa y Ciudad Autonoma de Buenos Aires, seran dadas por perdedoras de manera automatica, mostrando asi un mensaje personalizado para cada una "error 404 provincia not found" para La Pampa y "perdiste por porteño, nada eso" para CABA. 
El juego tambien mostrata un mensaje particular para cada personaje perdedor de cada batalla, de un arreglo de strings, se selecciona de manera aleatoria una palabra que sera utilizada para mostrar en dicho mesnaje.

El codigo esta realizado con las herramientas brindadas a lo largo de la cursada de la materia TALLER DE LENGUAJES I, se usaron varias clases para la escritura del codigo para tratar de modularizar el mismo de la mejor manera.
