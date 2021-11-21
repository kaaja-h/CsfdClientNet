using System;
using System.IO;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace CsfdClientNet.Test.Utils
{
    public class LoaderConfig
    {
        public string TargetPath { get; set; }
        public LoaderConfigItem[] Items { get; set; }
    }

    public class LoaderConfigItem
    {
        public string Url { get; set; }
        public string File { get; set; }
    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var c = new ConfigurationBuilder();
            c
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                ;
            var root = c.Build();
            LoaderConfig conf = new LoaderConfig();
            root.GetSection(nameof(LoaderConfig)).Bind(conf);

            HtmlWeb web = new HtmlWeb();
            foreach (var item in conf.Items)
            {
                var document = await web.LoadFromWebAsync(item.Url);
                await File.WriteAllTextAsync(Path.Combine(conf.TargetPath,item.File),document.Text);
                
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}