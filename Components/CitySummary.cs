using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebApp.Models;

namespace WebApp.Components
{
    public class CitySummary : ViewComponent
    {

        private CitiesData _data;

        public CitySummary(CitiesData data)
        {
            _data = data;
        }

        public IViewComponentResult Invoke(string themeName = "succes")
        {
            ViewBag.Theme = themeName ;
                return View(new CityViewModel
                {
                    Cities = _data.Cities.Count(),
                    Population = _data.Cities.Sum(x => x.Population)
                });

            //return new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string</i></h3>"));
            //if (RouteData.Values["Controller"] != null)
            //{
            //    return "Controller used";
            //}
            //else
            //{
            //    return "Razor Page Used";
            //}
        }

    }
}
