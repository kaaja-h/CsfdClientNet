using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CsfdClientNet.Cache;
using CsfdClientNet.Data;
using HtmlAgilityPack;
[assembly: InternalsVisibleTo("CsfdClientNet.Test")]

namespace CsfdClientNet.Scrapping
{

    internal class MovieDetailReader : ScrapperQueueItem<MovieDetail?>
    {
        private readonly Movie _movie;

        public MovieDetailReader(Movie movie, bool useCache, IWebDataReader webDataReader) : base(useCache,webDataReader)
        {
            _movie = movie;
        }

        protected override async Task<MovieDetail?> ProcessInternal(ICsfdClientCache cache, CancellationToken token)
        {
            var web = new HtmlWeb();
            var url = string.Format(ScrappingConsts.MovieDetailUrl, _movie.Id);
            var document = await web.LoadFromWebAsync(url, token);

            var res = new MovieDetail(_movie);

            var professions = document.DocumentNode.SelectNodes(ScrappingConsts.MovieDetailProfessionsPath);
            foreach (var profession in professions)
            {
                var name = profession.SelectSingleNode(ScrappingConsts.MovieDetailProfessionNamePath).InnerText
                    .Trim(ScrappingConsts.MovieDetailProfessionNameTrimChars);
                var creators = profession.SelectNodes(ScrappingConsts.MovieDetailProfessionCreatorsPath)
                    .Where(d => d.Attributes.Contains("href"))
                    .Select(d => new Creator(d.Attributes["href"].Value, d.InnerText))
                    .ToList();
                foreach (var creator in creators)
                {
                    await cache.SaveCreator(creator, token);
                }

                res.Professions[name] = creators;
            }

            var ratingNode = document.DocumentNode.SelectSingleNode(ScrappingConsts.MovieDetailRatingAveragePath);
            if (ratingNode != null && decimal.TryParse(ratingNode.Attributes["content"].Value, NumberStyles.Float,
                CultureInfo.InvariantCulture, out var rating))
                res.RatingAverage = rating;
            var ratingCountNode = document.DocumentNode.SelectSingleNode(ScrappingConsts.MovieDetailRatingCountPath);
            if (ratingCountNode != null && int.TryParse(ratingCountNode.Attributes["content"].Value, out var count))
                res.RatingCount = count;

            var plots = document.DocumentNode.SelectNodes(ScrappingConsts.MovieDetailPlotPath);
            if (plots != null)
            {
                var pp = new List<string>();
                foreach (var plot in plots)
                {
                    pp.Add(plot.InnerText);
                }

                res.Plots = pp;
            }

            var genres = document.DocumentNode.SelectSingleNode(ScrappingConsts.MovieDetailGenresPath);
            if (genres != null)
            {
                res.Genres = genres.InnerText.Trim().Split(ScrappingConsts.MovieDetailGenresSeparator)
                    .Select(d => d.Trim()).ToList()
                ;
            }

            var created = document.DocumentNode.SelectSingleNode(ScrappingConsts.MovieDetailDatePath);
            if (created != null)
                res.DateCreated = created.InnerText;

            var origin = document.DocumentNode.SelectSingleNode(ScrappingConsts.MovieDetailOriginPath);
            if (origin != null)
            {
                res.Origin = origin.ChildNodes?.FirstOrDefault()?.InnerText.Trim().Trim(new char[] { ',' });
                if (origin.ChildNodes != null && origin.ChildNodes.Count() == 3)
                {
                    res.Length = origin.ChildNodes?.Last()?.InnerText.Trim().Trim(new char[] { ',', ' ' });
                }

            }

            return res;
        }

        protected override async Task<MovieDetail?> CheckCache(ICsfdClientCache cache, CancellationToken token)
        {
            return await cache.GetMovieDetail(_movie.Id, token);
        }
    }
}