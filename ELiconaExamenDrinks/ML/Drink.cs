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
        public List<Drink> drinks { get; set; }
        public List<StrIngredient> StrIngredient { get; set; }
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public string strIngredient5 { get; set; }
        public string strIngredient6 { get; set; }
        public string strIngredient7 { get; set; }
        public string strIngredient8 { get; set; }
        public string strIngredient9 { get; set; }
        public string strIngredient10 { get; set; }



        public List<StrMeasure> StrMeasure { get; set; }

        public string strMeasure1 { set; get; }
        public string strMeasure2 { set; get; }
        public string strMeasure3 { set; get; }
        public string strMeasure4 { set; get; }
        public string strMeasure5 { set; get; }
        public string strMeasure6 { set; get; }
        public string strMeasure7 { set; get; }
        public string strMeasure8 { set; get; }
        public string strMeasure9 { set; get; }
        public string strMeasure10 { set; get; }


        public object strDrinkAlternate { get; set; }
        public string strIBA { get; set; }
        public string strAlcoholic { get; set; }
        public string strGlass { get; set; }
        public string strTags { get; set; }
        public string strDrinkThumb { get; set; }


    }
}
