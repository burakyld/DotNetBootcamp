using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patikaWeek1.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class MovieController : Controller
    {
        private static List<Movie> MovieList = new List<Movie>();


        // Tüm listeyi getirme.
        [HttpGet]
        public List<Movie> GetAllMovies()
        {
            var movieList = MovieList.OrderBy(fu => fu.name).ToList();

            return movieList;
        }


        // Film ismini aratıp listeden getirme.
        [HttpGet("{name}")]
        public Movie GetMovieById(string name)
        {
            var movie = MovieList.Where(fu=>fu.name == name.ToUpper()).OrderBy(fu => fu.name).FirstOrDefault();

            return movie;
        }


        // Fİlm listesine film ekleme.
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie m)
        {
            var movie = MovieList.Where(fu =>fu.name == m.name.ToUpper()).ToList();

            if (movie.Count>0)
                return BadRequest("Eklemeye çalıştığınız isimde film bulunuyor.");

            m.name = m.name.ToUpper();
            MovieList.Add(m);

            return Ok("Ekleme işlemi başarılı.");
        }


        // Film listesindeki parametreden ismi gelen filme güncelleme işlemi.
        [HttpPut("{name}")]
        public IActionResult UpdateMovie(string name,[FromBody] Movie m)
        {
            var movie = MovieList.Where(fu => fu.name == name.ToUpper()).OrderBy(fu => fu.name).FirstOrDefault();

            if (movie == null)
                return BadRequest("Girilen isimde film bulunmamaktadır.");

            movie.name = m.name;
            movie.date = m.date;
            movie.imdb = m.imdb;
            movie.subject = m.subject;



            return Ok("Güncelleme başarılı.");
        }


        // Film silme işlemi için kullanılan metod.
        [HttpDelete]
        public IActionResult DeleteMovie(string name)
        {
            // Listede parametreden gelen isimli filmi arıyor.
            var movie = MovieList.Where(fu => fu.name == name.ToUpper()).FirstOrDefault();

            // listede yoksa geri mesaj döndürüyor.
            if (movie == null)
                return BadRequest("Silmeye çalıştığınız isimde film bulunuyor.");


            // Listede varsa listeden çıkarıyor ve mesaj döndürüyor.
            MovieList.Remove(movie);

            return Ok("Silme işlemi başarılı.");
        }

    }
}
