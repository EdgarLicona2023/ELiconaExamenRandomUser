using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Drink
    {
        public string idDrink { set; get; }
        public string strDrink { set; get; }
        public StrIngredient strIngredient { set; get; }
        public StrMeasure strMeasure { set; get; }
        public string strCategory { set; get; }
        public string strInstructions { set; get; }
        public List<object> Drinks { get; set; }


        public object strDrinkAlternate { get; set; }
        public string strIBA { get; set; }
        public string strAlcoholic { get; set; }
        public string strGlass { get; set; }
        public string strTags { get; set; }
        public string strImageSource { get; set; }

    }
}
