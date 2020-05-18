using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using movies_oguzkose.Entities;
using movies_oguzkose.Models;
using movies_oguzkose.Services;

namespace movies_oguzkose.Controllers
{ 
    public class MovieController : Controller
    {
        private readonly MovieService _movieService ;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

     
        public IActionResult Index()
        {
            var movieEntities = _movieService.GetMovies();
            var movieVievModelList = new List<MovieViewModel>();
            foreach (var entity in movieEntities)
            {
                movieVievModelList.Add(new MovieViewModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Director = entity.Director,
                    Cast = entity.Cast,
                    ReleaseYear = entity.ReleaseYear,
                    Writer = entity.Writer,
                    Category = entity.Category,
                    ImdbUrl = entity.ImdbUrl,
                    Score = entity.Score,
                    Review = entity.Review
                });
            }
            return View(movieVievModelList);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieEntity = _movieService.Get(id);
            var model=new MovieViewModel
            {
                Id=movieEntity.Id,
                Name=movieEntity.Name,
                Director=movieEntity.Director,
                Cast=movieEntity.Cast,
                ReleaseYear=movieEntity.ReleaseYear,
                Writer=movieEntity.Writer,
                Category=movieEntity.Category,
                ImdbUrl=movieEntity.ImdbUrl,
                Score=movieEntity.Score,
                Review=movieEntity.Review
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(MovieViewModel model)
        {
            var movieEntity = new MovieEntity
            {
                Id = model.Id,
                Name = model.Name,
                Director = model.Director,
                Cast = model.Cast,
                ReleaseYear = model.ReleaseYear,
                Writer = model.Writer,
                Category = model.Category,
                ImdbUrl = model.ImdbUrl,
                Score = model.Score,
                Review = model.Review
            };
            _movieService.Edit(movieEntity);
            var updatedEntity = _movieService.Get(model.Id);

            return View(new MovieViewModel
            {
                Id = updatedEntity.Id,
                Name = updatedEntity.Name,
                Director = updatedEntity.Director,
                Cast = updatedEntity.Cast,
                ReleaseYear = updatedEntity.ReleaseYear,
                Writer = updatedEntity.Writer,
                Category = updatedEntity.Category,
                ImdbUrl = updatedEntity.ImdbUrl,
                Score = updatedEntity.Score,
                Review = updatedEntity.Review
            });
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return RedirectToAction(nameof(Index), "Movie");
        }
        public IActionResult Add()
        {
            var model = new MovieViewModel();
            SelectListItem[] categoryList = new SelectListItem[]
            {
                new SelectListItem(){ Text="Seçiniz"},
                new SelectListItem(){Text="Dram", Value="Drama"},
                new SelectListItem(){Text="Macera",Value="Adventure"},
                new SelectListItem(){Text="Biyografi",Value="Biography"}
            };
            model.CategorySelectList = categoryList;
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(MovieViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                SelectListItem[] categoryList = new SelectListItem[]
                  {
                    new SelectListItem(){ Text="Seçiniz"},
                new SelectListItem(){Text="Dram", Value="Drama"},
                new SelectListItem(){Text="Macera",Value="Adventure"},
                new SelectListItem(){Text="Biyografi",Value="Biography"}
                  };
                model.CategorySelectList = categoryList;
                return View(model);
            }
            MovieEntity entity = new MovieEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Director = model.Director,
                Cast = model.Cast,
                ReleaseYear = model.ReleaseYear,
                Writer = model.Writer,
                Category = model.Category,
                ImdbUrl = model.ImdbUrl,
                Score = model.Score,
                Review = model.Review
            };
            _movieService.Add(entity);

            return RedirectToAction(nameof(Index), "Movie");
        }
    }
}