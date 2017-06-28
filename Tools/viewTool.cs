using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wtime.Tools
{
    public class viewTool
    {
        public static IEnumerable<SelectListItem> DropdownOre()
        {
            List<SelectListItem> retVal = new List<SelectListItem>();
            
            for(int i=0; i<24; i++)
            {
                retVal.Add(new SelectListItem { Value = i.ToString(),
                    Text = ( i < 10 ? "0" + i.ToString() : i.ToString()) });
            }

            return retVal;
        }


        public static IEnumerable<SelectListItem> DropdownMinuti()
        {
            List<SelectListItem> retVal = new List<SelectListItem>();
            retVal.Add(new SelectListItem { Value = "0", Text = "00"});
            retVal.Add(new SelectListItem { Value = "30", Text = "30" });

            return retVal;
        }

    }
}