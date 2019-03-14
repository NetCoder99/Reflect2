//============================================================================
// John Dugger
// 03/14/2019
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// It was 'nice to have' a dictionary object that I could easily iterate 
// over to review the errors in the MVC ModelState object. This method 
// acheives that goal, not sure the Generic T was needed but it lets me pass 
// any object that inherits from the ModelStateDictionary, so that's what I 
// did.
//============================================================================
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reflect2.Classes
{
    public class GetModelErrors
    {

        public static Dictionary<String, String> GetErrors<T>(T modelState) where T : System.Web.Mvc.ModelStateDictionary
        {
            Dictionary<String, String> rtn_dict = new Dictionary<string, string>();
            foreach (var model_entry in modelState)
            {
                if (model_entry.Value.Errors.Count() > 0)
                { rtn_dict.Add(model_entry.Key, model_entry.Value.Errors[0].ErrorMessage); }
            }
            return rtn_dict;
        }

    }
}