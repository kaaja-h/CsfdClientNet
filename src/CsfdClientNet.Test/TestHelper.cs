using System.Reflection;
using System.Runtime.CompilerServices;
using CsfdClientNet.Scrapping;
using HtmlAgilityPack;
using Moq;

namespace CsfdClientNet.Test
{
    internal static class TestHelper
    {
        public static IWebDataReader PrepareReader(string filename)
        {
            var stream = Assembly.GetAssembly(typeof(TestHelper))
                .GetManifestResourceStream("CsfdClientNet.Test.TestPages." + filename);
            HtmlDocument d = new HtmlDocument();
            d.Load(stream);
            var m = new Mock<IWebDataReader>();
            m.Setup(d => d.ReadData(It.IsAny<string>()))
                .ReturnsAsync(d
                );
            
            return m.Object;
        }
    }
}