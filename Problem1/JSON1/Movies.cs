﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON1
{
    class Movies
    {
        public int movie_Id { get; set; }
        public string genres        {get; set;}
        public string actor_1_name  {get; set;}
        public int num_voted_users  {get; set;}
        public double imdb_score    {get; set;}
        public string movie_title   {get; set;}
        public string director_name { get; set; }
    }
}
