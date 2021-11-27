using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/fast-and-furious-9-poster-1580411801.jpeg?crop=1xw:1xh;center,top&resize=980:*", "Dom Toretto tiene una vida tranquila fuera del radar, con Letty y su hijo, el pequeño Brian, pero saben que el peligro siempre acecha en su horizonte pacífico.", "Rápidos y furiosos 9", "https://www.youtube.com/watch?v=t3DpuQrBivU&ab_channel=TrailersInSpanish" },
                    { 20, "https://www.multiplex.com.ar/wp-content/uploads/2021/09/venom-carnage-liberado.jpg", "Regresa Eddie Brock y su Venom. Que en esta oportunidad se reencontrará con Cletus Cassady,el enemigo más sangriento de la historia de Spiderman a quién se lo conoce como “Carnage”.", "Venom: Carnage Liberado", "https://www.youtube.com/watch?v=F4Ygcigj0Gk&ab_channel=SonyPicturesArgentina" },
                    { 19, "https://static.cinemarkhoyts.com.ar/Images/Posters/1fa377f4d4d78239363a228dd91ea241.jpg?v=01112021", "Chernobyl es el primer largometraje ruso importante sobre las consecuencias de la explosión en la central nuclear de Chernobyl, cuando cientos de personas sacrificaron sus vidas para limpiar el lugar de la catástrofe.", "Chernóbil: La Película", "https://www.youtube.com/watch?v=9DkXQM3eR8I&ab_channel=TrailersInSpanish" },
                    { 18, "https://images.clarin.com/2021/04/16/el-primer-afiche-que-se___8xbNrbH6m_720x0__1.jpg", "Los Eternos son una raza de seres inmortales con poderes sobrehumanos que han vivido en secreto en la Tierra durante miles de años. Aunque nunca han intervenido, ahora una amenaza se cierne sobre la humanidad.", "Eternals", "https://www.youtube.com/watch?v=v1EkoQV4g5c&ab_channel=MarvelLatinoam%C3%A9ricaOficial" },
                    { 17, "https://image.tmdb.org/t/p/original//hKZHk6I1p58ZeXbwjQok7DSWfZ.jpg", "Argentina, años setenta. Una joven desesperada recurre a una clínica que hace abortos clandestinos.", "El Apego", "https://www.youtube.com/watch?v=80P35D4vyHg&ab_channel=EL%C3%9ALTIMOBLOGALAIZQUIERDA" },
                    { 16, "https://pics.filmaffinity.com/cato-646607409-large.jpg", "Cato, un joven del conurbano bonaerense, está a punto de convertirse en estrella de trap cuando una tragedia familiar parece poner fin a todos sus sueños y ambiciones.", "Cato", "https://www.youtube.com/watch?v=GDR_scpOHMI&ab_channel=Patagonik" },
                    { 15, "https://pics.filmaffinity.com/the_unholy-403969644-large.jpg", "Un periodista en horas bajas descubre una serie de aparentes milagros de una joven que dice haber sido visitada por la Virgen María, milagros acaecidos en un pequeño pueblo de Nueva Inglaterra.", "Ruega por nosotros", "https://www.youtube.com/watch?v=a_BYIlWcbVg&ab_channel=SonyPicturesEspa%C3%B1a" },
                    { 14, "https://pics.filmaffinity.com/nobody-390795243-large.jpg", "Hutch Mansell (Bob Odenkirk) es un hombre de familia corriente. Una noche unos ladrones entran a su casa y él renuncia a defenderse y defender a su familia con el fin de evitar complicaciones.", "Nadie", "https://www.youtube.com/watch?v=Mzrib73dVbc&ab_channel=UniversalSpain" },
                    { 13, "https://pics.filmaffinity.com/paw_patrol_the_movie-626479283-large.jpg", "La Patrulla Canina está en racha. Cuando Humdinger, su mayor rival, se convierte en alcalde de la cercana Ciudad Aventura y empieza a causar estragos, Ryder y los heroicos cachorros se ponen en marcha para enfrentarse a este nuevo desafío.", "La Patrulla Canina: La película", "https://www.youtube.com/watch?v=ABjdw_caRsQ&ab_channel=PARAMOUNTPICTURESM%C3%89XICO" },
                    { 11, "https://pics.filmaffinity.com/godzilla_vs_kong-370227109-large.jpg", "Godzilla y Kong, dos de las fuerzas más poderosas de un planeta habitado por todo tipo de aterradoras criaturas, se enfrentan en un espectacular combate que sacude los cimientos de la humanidad.", "Godzilla vs. Kong", "https://www.youtube.com/watch?v=Kqg8zLgESyQ&ab_channel=WarnerBros.PicturesLatinoam%C3%A9rica" },
                    { 12, "https://static.wikia.nocookie.net/doblaje/images/5/53/E3XjApsWQAo7LrH.jpeg/revision/latest?cb=20210623234126&path-prefix=es", "Durante un viaje a los estudios de Warner Bros., la superestrella de la NBA LeBron James y su hijo Dom quedan atrapados accidentalmente en un mundo que contiene todas las historias y personajes de Warner", "Space Jam: una nueva era", "https://www.youtube.com/watch?v=8GltZA7F7-M&ab_channel=WarnerBros.PicturesLatinoam%C3%A9rica" },
                    { 9, "http://www.mubis.es/media/users/3724/287276/matrix-resurrection-nuevo-poster-original.jpg", "Plagado de extraños recuerdos, la vida de Neo da un giro inesperado cuando se encuentra de nuevo dentro de Matrix.", "Matrix 4", "https://www.youtube.com/watch?v=9ix7TUGVYIo&ab_channel=WarnerBros.Pictures" },
                    { 8, "https://imagenes.gatotv.com/categorias/peliculas/posters/infinite_2021.jpg", "Acosado por los recuerdos de lugares que nunca ha visitado, un hombre une fuerzas con un grupo de guerreros renacidos para evitar que un loco destruya el ciclo interminable de la vida y la reencarnación.", "Infinite", "https://www.youtube.com/watch?v=_WWEOCQGxSw&ab_channel=ONEMedia" },
                    { 7, "https://www.imdb.com/title/tt6341832/mediaviewer/rm198951681/", "Una mujer se despierta en una cámara criogénica sin recordar cómo llegó allí, y debe encontrar una salida antes de quedarse sin aire.", "Oxygen", "https://www.youtube.com/watch?v=8IqXgZd-P98&ab_channel=Netflix" },
                    { 6, "https://es.web.img3.acsta.net/r_1920_1080/pictures/20/12/28/10/26/5942577.jpg", "Jim es un ex infante de marina que vive una vida solitaria como ranchero a lo largo de la frontera entre Arizona y México. Pero su existencia pacífica pronto se derrumba cuando intenta proteger a un niño que huye de los miembros de un cartel vicioso.", "The marksman", "https://www.youtube.com/watch?v=lEBPNi4bEbc&ab_channel=MovieclipsTrailers" },
                    { 5, "https://static.wikia.nocookie.net/disney/images/c/cc/Luca_poster.jpg/revision/latest/scale-to-width-down/1000?cb=20210428135001&path-prefix=es", "Ambientada en una hermosa ciudad costera en la Riviera italiana, la película animada original es una historia sobre la mayoría de edad sobre un niño que experimenta un verano inolvidable lleno de helados, pasta e interminables paseos en scooter.", "Luca", "https://www.youtube.com/watch?v=EJk_Z-OasXc&ab_channel=SensaCineTRAILERS" },
                    { 4, "https://pics.filmaffinity.com/sonic_the_hedgehog-730493692-large.jpg", "El mundo necesitaba un héroe, tenía un erizo. Impulsado con una velocidad increíble, Sonic abraza su nuevo hogar en la Tierra.", "Sonic the hedgehog", "https://www.youtube.com/watch?v=Xb3E8eWZ1mk&ab_channel=SensaCineTRAILERS" },
                    { 3, "https://es.web.img3.acsta.net/r_1920_1080/pictures/21/02/25/18/01/0475358.jpg", "La identidad de Spider-Man se revela a todos, y ya no puede separar su vida normal de su vida de superhéroe.", "Spiderman: No way home", "https://www.youtube.com/watch?v=rt-2cxAiPJk&ab_channel=SonyPicturesEntertainment" },
                    { 2, "https://m.media-amazon.com/images/I/71niXI3lxlL._AC_SL1183_.jpg", "A la deriva en el espacio sin comida ni agua, Tony Stark envía un mensaje a Pepper Potts cuando su suministro de oxígeno comienza a disminuir.", "Avengers EndGame", "https://www.youtube.com/watch?v=TcMBFSGVi1c&ab_channel=MarvelEntertainment" },
                    { 10, "https://pics.filmaffinity.com/tom_and_jerry-740894888-large.jpg", "Una rivalidad legendaria resurge cuando Jerry se muda al mejor hotel de la ciudad de Nueva York en vísperas de la boda del siglo, lo que obliga al desesperado planificador de eventos a contratar a Tom para deshacerse de él.", "Tom y jerry", "https://www.youtube.com/watch?v=ZJVb-IR1Jnw&ab_channel=WBKidsLatino" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad" },
                values: new object[,]
                {
                    { 2, 15 },
                    { 1, 5 },
                    { 3, 35 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Salas",
                keyColumn: "SalaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Salas",
                keyColumn: "SalaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Salas",
                keyColumn: "SalaId",
                keyValue: 3);
        }
    }
}
