using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class search_parameter
    {
        public double ApsimokymoGreitis { get; private set; }
        public string OptimizavimoMetodas { get; private set; }
        public string Svoriai { get; private set; }
        public bool YraPagrindinis { get; private set; }

        public void update(double ApsimokymoGreitis, string OptimizavimoMetodas, string Svoriai, bool YraPagrindinis)
        {
            this.ApsimokymoGreitis = ApsimokymoGreitis > 0 ? ApsimokymoGreitis : -1;
            this.OptimizavimoMetodas = OptimizavimoMetodas ?? "undefined";
            this.Svoriai = Svoriai ?? "undefined";
            this.YraPagrindinis = YraPagrindinis;
        }      
    }
}
