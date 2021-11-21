using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HtmlAgilityPack;
[assembly: InternalsVisibleTo("CsfdClientNet.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")] 
namespace CsfdClientNet.Scrapping
{
    internal interface IWebDataReader
    {
        Task<HtmlDocument> ReadData(string url);
    }

    internal class WebDataReader : IWebDataReader
    {

        private readonly HtmlWeb _htmlWeb;


        public WebDataReader()
        {
            _htmlWeb = new HtmlWeb();
        }

        public Task<HtmlDocument> ReadData(string url)
        {

            return _htmlWeb.LoadFromWebAsync(url);

        }    
        
    }
}