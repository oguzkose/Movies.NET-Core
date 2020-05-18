using movies_oguzkose.Context;
using movies_oguzkose.Entities;
using movies_oguzkose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_oguzkose.Services
{
    public class MovieService
    {
        private readonly MovieContext _movieContext;
        public MovieService(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public List<MovieEntity> GetMovies()//tüm filmleri getiren metot
        {
            return _movieContext.Movies;
        }
        public MovieEntity Get(int id)//id ye göre filmi getiren metot
        {
            return _movieContext.Movies.FirstOrDefault(x => x.Id == id);
        }
        public void Edit (MovieEntity movieEntity)//filmleri düzenleyen metot
        {
            var entity = _movieContext.Movies.FirstOrDefault(x => x.Id == movieEntity.Id);
            _movieContext.Movies.Remove(entity);
            _movieContext.Movies.Add(movieEntity);

        }
        internal void Delete(int id)//filmleri silen metot
        {
            var entity = _movieContext.Movies.FirstOrDefault(x => x.Id == id);
            _movieContext.Movies.Remove(entity);
        }
        public void Add(MovieEntity entity)//film ekleyen metot
        {
            _movieContext.Movies.Add(entity);
        }
    
         
    }
}
