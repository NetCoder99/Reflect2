//============================================================================
// John Dugger
// 03/14/2019
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// This method will accept up to 4 parms...
// 1) the first is the model object passed from an MVC controller, this 
//    contains the user input, updated fields, etc.
// 2) the second is the corresponding entity from the EF db context that
//    supports access to the database.
// 3) an optional list of fields to exclude from the update process, 
//    something like a key field.
// 4) an optional list of fields to include in the update process, if 
//    you pass this only the fields listed in it will be updated. the 
//    exclude list will override this, anything to be excluded will 
//    always be excluded.
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// Using reflection it will iterate over the model fields, find the matching
// db entity fields and update the db entity from the MVC model. There are 
// some EF built in's that do much the same but they did not seem to work with 
// the ASP.NET Identity Framework security. Also, this will accept a list of 
// fields to include in the update process, restricts what the user can 
// update.
//============================================================================
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Reflect2.Classes
{

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    // as we iterate over the properties of the form model we will add entries to 
    // to a list of these, pass this back so the caller can easily track changes 
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    public class ModelUpdates
    {
        public string field_name { get; set; }
        public object old_value { get; set; }
        public object new_value { get; set; }
    }

    public class GetModelUpdates
    {

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        // overloads that will let us call the update function with different parameters
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public static List<ModelUpdates> GetUpdates<T>(T form_model, T db_model) where T : class
        { return GetUpdates(form_model, db_model, null, null); }

        public static List<ModelUpdates> GetUpdates<T>(T form_model, T db_model, List<string> exclude_flds) where T : class
        { return GetUpdates(form_model, db_model, exclude_flds, null); }


        public static List<ModelUpdates> GetUpdates<T>(T view_model, T db_model, List<string> exclude_flds, List<string> include_flds) where T : class
        {
            if (exclude_flds == null) { exclude_flds = new List<string>(); }
            if (include_flds == null) { include_flds = new List<string>(); }

            List<ModelUpdates> rtn_list = new List<ModelUpdates>();
            List<PropertyInfo> form_props = view_model.GetType().GetProperties().OrderBy(o => o.Name).ToList();
            List<PropertyInfo> db_props = db_model.GetType().GetProperties().OrderBy(o => o.Name).ToList();

            foreach (PropertyInfo f_prop in form_props)
            {
                if (f_prop.Name == "Class" || f_prop.Name == "Weight")
                {
                    //string t1 = "Break here";
                }
                if (exclude_flds.Contains(f_prop.Name)) { continue; }
                if (include_flds.Count() == 0 || include_flds.Contains(f_prop.Name))
                {
                    var f_obj = f_prop.GetValue(view_model, null);
                    PropertyInfo d_prop = db_props.Find(f => f.Name == f_prop.Name);
                    var d_obj = d_prop.GetValue(db_model, null);

                    if (f_obj != d_obj)
                    {
                        d_prop.SetValue(db_model, f_obj);
                        ModelUpdates tmp_update = new ModelUpdates();
                        tmp_update.field_name = f_prop.Name;
                        tmp_update.field_name = f_prop.Name;
                        tmp_update.old_value = d_obj;
                        tmp_update.new_value = f_obj;
                        rtn_list.Add(tmp_update);
                    }

                }
            }
            return rtn_list;
        }
    }
}