using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class SearchParameters
    {
        public double ApsimokymoGreitis { get; private set; }
        public string OptimizavimoMetodas { get; private set; }
        public string Svoriai { get; private set; }
        public bool YraPagrindinis { get; private set; }

        public SearchParameters(double ApsimokymoGreitis, string OptimizavimoMetodas, string Svoriai, bool YraPagrindinis)
        {
            this.ApsimokymoGreitis = ApsimokymoGreitis > 0 ? ApsimokymoGreitis : -1;
            this.OptimizavimoMetodas = OptimizavimoMetodas ?? "undefined";
            this.Svoriai = Svoriai ?? "undefined";
            this.YraPagrindinis = YraPagrindinis;
        }

        public void update(double newApsimokymoGreitis, string newOptimizavimoMetodas, string newSvoriai, bool newYraPagrindinis)
        {
            ApsimokymoGreitis = newApsimokymoGreitis > 0 ? newApsimokymoGreitis : -1;
            OptimizavimoMetodas = newOptimizavimoMetodas ?? "undefined";
            Svoriai = newSvoriai ?? "undefined";
            YraPagrindinis = newYraPagrindinis;
        }
    }
}
