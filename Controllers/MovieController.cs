using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        #region Base Methods
        [HttpGet]
        public ActionResult<List<Movie>> Get() => _movieService.Get();

        [HttpGet("{id:int}", Name = "GetMovie")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = _movieService.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]
        public ActionResult<Movie> Create(Movie movie)
        {
            _movieService.Create(movie);

            return CreatedAtRoute("GetMovie", new { id = movie.Id }, movie);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Movie m)
        {
            var movie = _movieService.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            _movieService.Update(id, m);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var movie = _movieService.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            _movieService.Remove(movie);

            return NoContent();
        }
        public IActionResult Index()
        {
            return View(_movieService.Get());
        }
        #endregion

        #region Add/Remove/Update
        [HttpGet]
        public ActionResult<List<Movie>> Add()
        {
            var movie = new Movie()
            {
                Id = "movie:93",
                Title = "Test",
                Year = 2021,
                Country = "IR"
            };
            Create(movie);
            return _movieService.Get();
        }

        [HttpGet]
        public ActionResult<List<Movie>> Remove()
        {
            Delete(93);
            return _movieService.Get();
        }

        [HttpGet]
        public ActionResult<List<Movie>> Update()
        {
            var movie = _movieService.Get(93);

            if (movie == null)
            {
                return null;
            }

            var m = new Movie()
            {
                Id = "movie:93",
                Title = "Test Update",
                Year = 2100,
                Country = "US"
            };

            _movieService.Update(93, m);

            return _movieService.Get();
        }
        #endregion

        #region Queries

        [HttpGet]
        public ActionResult<List<Movie>> Q1()
        {
            var filter = Builders<Movie>.Filter.Eq("country", "USA");
            return _movieService.GetByFilter(filter);
        }

        [HttpGet]
        public ActionResult<List<Movie>> Q2()
        {
            var filter = Builders<Movie>.Filter.Gt("year", 2000);
            return _movieService.GetByFilter(filter);
        }

        [HttpGet]
        public ActionResult<List<Movie>> Q3()
        {
            return _movieService.Get();
        }

        [HttpGet]
        public ActionResult<List<Movie>> Q5()
        {
            var filter = Builders<Movie>.Filter.Eq("country", "FR");
            return _movieService.GetByFilter(filter, 3);
        }

        [HttpGet]
        public ActionResult<List<Movie>> Q6()
        {
            var filter = Builders<Movie>.Filter.Where(movie => movie.Country == "USA" && movie.Year > 2000);
            var result = _movieService.GetByFilter(filter);

            return _movieService.GetByFilter(filter);
        }

        [HttpGet]
        public ActionResult<List<Movie>> Q7()
        {
            var filter = Builders<Movie>.Filter.Where(movie => movie.Title.StartsWith("T"));
            return _movieService.GetByFilter(filter);
        }

        [HttpGet]
        public ActionResult<bool> Q8()
        {
            var filter = Builders<Movie>.Filter.Where(movie => string.IsNullOrEmpty(movie.Director.BirthDate));
            return _movieService.GetByFilter(filter).Any();
        }

        [HttpGet]
        public ActionResult<List<Movie>> Q9()
        {
            var filter = Builders<Movie>.Filter.Where(movie => movie.Director.FirstName == "Steven");
            return _movieService.GetByFilter(filter);
        }

        #endregion
    }
}
