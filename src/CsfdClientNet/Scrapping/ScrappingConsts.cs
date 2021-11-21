using System.Data;

namespace CsfdClientNet.Scrapping
{

    internal static class ScrappingConsts
    {
        public const string CsfdUrl = "https://www.csfd.cz";
        public const string QueryUrl = $"{CsfdUrl}/hledat/?";

        public const string QueryParamName = "q";
        public const string QueryMoviePath = "//h3[a/@class='film-title-name']";
        public const string QueryMovieTitlePath = "./a[@class='film-title-name']";
        public const string QueryMovieYearPath = "//span[@class='info']";

        public const string QueryCreatorPath = "//h3//a[starts-with(@href,'/tvurce/')]";

        public const string MovieDetailUrl = CsfdUrl + "{0}";
        public const string MovieDetailProfessionsPath = "//div[@class='creators']/div";
        public const string MovieDetailProfessionNamePath = "./h4";
        public const string MovieDetailProfessionCreatorsPath = "./span//a[starts-with(@href,'/tvurce/')]";
        public static readonly char[] MovieDetailProfessionNameTrimChars = new[] { ' ', ':' };

        public const string MovieDetailRatingAveragePath = "//meta[@itemprop='ratingValue']";
        public const string MovieDetailRatingCountPath = "//meta[@itemprop='ratingCount']";
        public const string MovieDetailPlotPath = "//div[contains(@class,'plot-full')]/p";
        public const string MovieDetailGenresPath = "//div[@class='genres']";
        public const char MovieDetailGenresSeparator = '/';
        public const string MovieDetailOriginPath = "//div[@class='origin']";
        public const string MovieDetailDatePath = "//div[@class='origin']/span[@itemprop='dateCreated']";


        public const string CreatorDetailUrl = CsfdUrl + "{0}" + "biografie/";

        public const string CreatorDetailBiographyPath =
            "//section[normalize-space(header/h2/text())='Biografie']//article/div/p[not(@class)]";

        public const string CreatorDetailFilmographyPath = "//div[@class='creator-filmography']/section";
        public const string CreatorDetailFilmographyNamePath = "./header/h2";
        public const string CreatorDetailFilmographyMoviePath = "./div/table/tbody/tr";
        public const string CreatorDetailFilmographyMovieYearPath = "./td[@class='year']";
        public const string CreatorDetailFilmographyMovieNamePath = "./td[@class='name' or @class='episode']//a[@class='film-title-name']";
    }
}