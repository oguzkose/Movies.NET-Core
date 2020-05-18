using movies_oguzkose.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace movies_oguzkose.Context
{
    public class MovieContext
    {
        public List<MovieEntity> Movies { get; set; }
        public MovieContext()
        {
            Movies = new List<MovieEntity>
            {
                new MovieEntity
                {
                    Id = 1,
                    Name = "The Imitation Game: Enigma",
                    Director = "Morten Tyldum",
                    Cast = "Benedict Cumberbatch, Keira Knightley, Matthew Goode",
                    ReleaseYear = 2015,
                    Writer = "Graham Moore, Andrew Hodges",
                    Category = "Biyografi",
                    ImdbUrl = "https://www.imdb.com/title/tt0108052/?ref_=adv_li_tt",
                    Score = 8.0m,
                    Review = 150
                },


                new MovieEntity
                {
                    Id = 2,
                    Name = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Cast = " Tim Robbins, Morgan Freeman, Bob Gunton",
                    ReleaseYear = 1994,
                    Writer = "Stephen King, Frank Darabont",
                    Category = "Drama",
                    ImdbUrl = "www.imdb.com/title/tt0111161",
                    Score = 9.3m,
                    Review = 2224843
                }


            };

        }
    }
}