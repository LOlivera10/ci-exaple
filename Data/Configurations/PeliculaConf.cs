using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class PeliculaConf
    {
        EntityTypeBuilder<Pelicula> peliculaBuilder;

        public PeliculaConf(EntityTypeBuilder<Pelicula> entityBuilder)
        {
            peliculaBuilder = entityBuilder;
            peliculaBuilder.HasKey(x => x.PeliculaId);

            entityBuilder.HasKey(x => x.PeliculaId);
            entityBuilder.Property(x => x.Titulo).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.Poster).HasMaxLength(255).IsRequired();
            entityBuilder.Property(x => x.Sinopsis).HasMaxLength(255).IsRequired();
            entityBuilder.Property(x => x.Trailer).HasMaxLength(255).IsRequired();

            CrearPelicula.LlenarPeliculas(peliculaBuilder, 1, "Rápidos y furiosos 9", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/fast-and-furious-9-poster-1580411801.jpeg?crop=1xw:1xh;center,top&resize=980:*", "Dom Toretto tiene una vida tranquila fuera del radar, con Letty y su hijo, el pequeño Brian, pero saben que el peligro siempre acecha en su horizonte pacífico.", "https://www.youtube.com/watch?v=t3DpuQrBivU&ab_channel=TrailersInSpanish");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 2, "Avengers EndGame", "https://m.media-amazon.com/images/I/71niXI3lxlL._AC_SL1183_.jpg", "A la deriva en el espacio sin comida ni agua, Tony Stark envía un mensaje a Pepper Potts cuando su suministro de oxígeno comienza a disminuir.", "https://www.youtube.com/watch?v=TcMBFSGVi1c&ab_channel=MarvelEntertainment");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 3, "Spiderman: No way home", "https://es.web.img3.acsta.net/r_1920_1080/pictures/21/02/25/18/01/0475358.jpg", "La identidad de Spider-Man se revela a todos, y ya no puede separar su vida normal de su vida de superhéroe.", "https://www.youtube.com/watch?v=rt-2cxAiPJk&ab_channel=SonyPicturesEntertainment");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 4, "Sonic the hedgehog", "https://pics.filmaffinity.com/sonic_the_hedgehog-730493692-large.jpg", "El mundo necesitaba un héroe, tenía un erizo. Impulsado con una velocidad increíble, Sonic abraza su nuevo hogar en la Tierra.", "https://www.youtube.com/watch?v=Xb3E8eWZ1mk&ab_channel=SensaCineTRAILERS");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 5, "Luca", "https://static.wikia.nocookie.net/disney/images/c/cc/Luca_poster.jpg/revision/latest/scale-to-width-down/1000?cb=20210428135001&path-prefix=es", "Ambientada en una hermosa ciudad costera en la Riviera italiana, la película animada original es una historia sobre la mayoría de edad sobre un niño que experimenta un verano inolvidable lleno de helados, pasta e interminables paseos en scooter.", "https://www.youtube.com/watch?v=EJk_Z-OasXc&ab_channel=SensaCineTRAILERS");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 6, "The marksman", "https://es.web.img3.acsta.net/r_1920_1080/pictures/20/12/28/10/26/5942577.jpg", "Jim es un ex infante de marina que vive una vida solitaria como ranchero a lo largo de la frontera entre Arizona y México. Pero su existencia pacífica pronto se derrumba cuando intenta proteger a un niño que huye de los miembros de un cartel vicioso.", "https://www.youtube.com/watch?v=lEBPNi4bEbc&ab_channel=MovieclipsTrailers");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 7, "Oxygen", "https://www.imdb.com/title/tt6341832/mediaviewer/rm198951681/", "Una mujer se despierta en una cámara criogénica sin recordar cómo llegó allí, y debe encontrar una salida antes de quedarse sin aire.", "https://www.youtube.com/watch?v=8IqXgZd-P98&ab_channel=Netflix");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 8, "Infinite", "https://imagenes.gatotv.com/categorias/peliculas/posters/infinite_2021.jpg", "Acosado por los recuerdos de lugares que nunca ha visitado, un hombre une fuerzas con un grupo de guerreros renacidos para evitar que un loco destruya el ciclo interminable de la vida y la reencarnación.", "https://www.youtube.com/watch?v=_WWEOCQGxSw&ab_channel=ONEMedia");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 9, "Matrix 4", "http://www.mubis.es/media/users/3724/287276/matrix-resurrection-nuevo-poster-original.jpg", "Plagado de extraños recuerdos, la vida de Neo da un giro inesperado cuando se encuentra de nuevo dentro de Matrix.", "https://www.youtube.com/watch?v=9ix7TUGVYIo&ab_channel=WarnerBros.Pictures");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 10, "Tom y jerry", "https://pics.filmaffinity.com/tom_and_jerry-740894888-large.jpg", "Una rivalidad legendaria resurge cuando Jerry se muda al mejor hotel de la ciudad de Nueva York en vísperas de la boda del siglo, lo que obliga al desesperado planificador de eventos a contratar a Tom para deshacerse de él.", "https://www.youtube.com/watch?v=ZJVb-IR1Jnw&ab_channel=WBKidsLatino");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 11, "Godzilla vs. Kong", "https://pics.filmaffinity.com/godzilla_vs_kong-370227109-large.jpg", "Godzilla y Kong, dos de las fuerzas más poderosas de un planeta habitado por todo tipo de aterradoras criaturas, se enfrentan en un espectacular combate que sacude los cimientos de la humanidad.", "https://www.youtube.com/watch?v=Kqg8zLgESyQ&ab_channel=WarnerBros.PicturesLatinoam%C3%A9rica");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 12, "Space Jam: una nueva era", "https://static.wikia.nocookie.net/doblaje/images/5/53/E3XjApsWQAo7LrH.jpeg/revision/latest?cb=20210623234126&path-prefix=es", "Durante un viaje a los estudios de Warner Bros., la superestrella de la NBA LeBron James y su hijo Dom quedan atrapados accidentalmente en un mundo que contiene todas las historias y personajes de Warner", "https://www.youtube.com/watch?v=8GltZA7F7-M&ab_channel=WarnerBros.PicturesLatinoam%C3%A9rica");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 13, "La Patrulla Canina: La película", "https://pics.filmaffinity.com/paw_patrol_the_movie-626479283-large.jpg", "La Patrulla Canina está en racha. Cuando Humdinger, su mayor rival, se convierte en alcalde de la cercana Ciudad Aventura y empieza a causar estragos, Ryder y los heroicos cachorros se ponen en marcha para enfrentarse a este nuevo desafío.", "https://www.youtube.com/watch?v=ABjdw_caRsQ&ab_channel=PARAMOUNTPICTURESM%C3%89XICO");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 14, "Nadie", "https://pics.filmaffinity.com/nobody-390795243-large.jpg", "Hutch Mansell (Bob Odenkirk) es un hombre de familia corriente. Una noche unos ladrones entran a su casa y él renuncia a defenderse y defender a su familia con el fin de evitar complicaciones.", "https://www.youtube.com/watch?v=Mzrib73dVbc&ab_channel=UniversalSpain");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 15, "Ruega por nosotros", "https://pics.filmaffinity.com/the_unholy-403969644-large.jpg", "Un periodista en horas bajas descubre una serie de aparentes milagros de una joven que dice haber sido visitada por la Virgen María, milagros acaecidos en un pequeño pueblo de Nueva Inglaterra.", "https://www.youtube.com/watch?v=a_BYIlWcbVg&ab_channel=SonyPicturesEspa%C3%B1a");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 16, "Cato", "https://pics.filmaffinity.com/cato-646607409-large.jpg", "Cato, un joven del conurbano bonaerense, está a punto de convertirse en estrella de trap cuando una tragedia familiar parece poner fin a todos sus sueños y ambiciones.", "https://www.youtube.com/watch?v=GDR_scpOHMI&ab_channel=Patagonik");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 17, "El Apego", "https://image.tmdb.org/t/p/original//hKZHk6I1p58ZeXbwjQok7DSWfZ.jpg", "Argentina, años setenta. Una joven desesperada recurre a una clínica que hace abortos clandestinos.", "https://www.youtube.com/watch?v=80P35D4vyHg&ab_channel=EL%C3%9ALTIMOBLOGALAIZQUIERDA");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 18, "Eternals", "https://images.clarin.com/2021/04/16/el-primer-afiche-que-se___8xbNrbH6m_720x0__1.jpg", "Los Eternos son una raza de seres inmortales con poderes sobrehumanos que han vivido en secreto en la Tierra durante miles de años. Aunque nunca han intervenido, ahora una amenaza se cierne sobre la humanidad.", "https://www.youtube.com/watch?v=v1EkoQV4g5c&ab_channel=MarvelLatinoam%C3%A9ricaOficial");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 19, "Chernóbil: La Película", "https://static.cinemarkhoyts.com.ar/Images/Posters/1fa377f4d4d78239363a228dd91ea241.jpg?v=01112021", "Chernobyl es el primer largometraje ruso importante sobre las consecuencias de la explosión en la central nuclear de Chernobyl, cuando cientos de personas sacrificaron sus vidas para limpiar el lugar de la catástrofe.", "https://www.youtube.com/watch?v=9DkXQM3eR8I&ab_channel=TrailersInSpanish");
            CrearPelicula.LlenarPeliculas(peliculaBuilder, 20, "Venom: Carnage Liberado", "https://www.multiplex.com.ar/wp-content/uploads/2021/09/venom-carnage-liberado.jpg", "Regresa Eddie Brock y su Venom. Que en esta oportunidad se reencontrará con Cletus Cassady,el enemigo más sangriento de la historia de Spiderman a quién se lo conoce como “Carnage”.", "https://www.youtube.com/watch?v=F4Ygcigj0Gk&ab_channel=SonyPicturesArgentina");
        }
    }

    public class CrearPelicula
    {
        public static void LlenarPeliculas(EntityTypeBuilder<Pelicula> builder, int peliculaId, string titulo, string poster, string sinopsis, string trailer)
        {
            builder.HasData(new Pelicula
            {
                PeliculaId = peliculaId,
                Titulo = titulo,
                Poster = poster,
                Sinopsis = sinopsis,
                Trailer = trailer
            });
        }
    }

}
