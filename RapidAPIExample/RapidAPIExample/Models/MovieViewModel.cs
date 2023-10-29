using System;
namespace RapidAPIExample.Models
{
	public class MovieViewModel
	{
        public class MovieResult
        {
            public string title { get; set; }
            public string year { get; set; }
            public string imdb_id { get; set; }
        }

            public List<MovieResult> movie_results { get; set; }     

    }
}

