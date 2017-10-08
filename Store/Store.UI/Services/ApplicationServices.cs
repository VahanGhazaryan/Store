using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.UI.Services
{
    public class ApplicationServices
    {
        public static List<SelectListItem> GetDropdownList(string currSelection)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = null, Text = null});
            if (currSelection == "Gender")
            {
                list.Add(new SelectListItem { Value = "Male", Text = "Male" });
                list.Add(new SelectListItem { Value = "Female", Text = "Female" });
            }
            else
                if (currSelection == "Country")
                {
                    list.AddRange(CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                                    .Select(x => new SelectListItem
                                        {  Value = new RegionInfo(x.LCID).Name, Text = new RegionInfo(x.LCID).EnglishName
                                        })
                                    .GroupBy(c => c.Value)
                                    .Select(c => c.First())
                                    .OrderBy(x => x.Text).ToList());
                }
            return list;
        }
    }
}