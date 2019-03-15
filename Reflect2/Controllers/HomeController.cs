using Reflect2.Classes;
using Reflect2.DataConnections;
using Reflect2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reflect2.Controllers
{
    public class HomeController : Controller
    {
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        // Stub: to be filled in later
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public ActionResult Index()
        {
            return View();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        // Stub: to be filled in later
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public ActionResult Sales()
        {
            return View();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        // for demostration only, a standard controller action, accepts the model from the view,
        // checks for errors, updates the allowed fields on the db entity, updates the databases
        // and returns the updated values to the view.
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        //[OutputCache(Duration = 0)]
        [HttpGet]
        public ActionResult Product(Product model)
        {
            System.Threading.Thread.Sleep(1500);
            using ( AdWorksDB adWorkCtx = new AdWorksDB())
            {
                if (model.ProductID == 0)
                {
                    model = adWorkCtx.products.FirstOrDefault();
                    model.PageNo = 1;
                    return View(model);
                }

                Dictionary<String, String> modelErrors = GetModelErrors.GetErrors(ModelState);
                if (modelErrors.Count() != 0)
                { return View(model); }

                Product db_entity = adWorkCtx.products.Where(w => w.ProductID == model.ProductID).FirstOrDefault();
                List<ModelUpdates> updates = GetModelUpdates.GetUpdates(model, db_entity, GetExcludeFields(), GetIncludeFields());
                db_entity.ModifiedDate = DateTime.Now;
                adWorkCtx.SaveChanges();
                ModelState.Clear();
                return View(db_entity);
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        // for demostration, prevent changes to these fields, normally set them to 
        // readonly on the display but this is a demo, so we'll do it like this
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        private List<string> GetExcludeFields()
        {
            List<string> rtn_list = new List<string>() { "ProductID", "ProductNumber", "rowguid"};
            return rtn_list;
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        // for demostration, allow changes to these fields, normally any things displayed 
        // as an update field will get passed to the database but this is a demo, so we'll 
        // do it like this
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        private List<string> GetIncludeFields()
        {
            List<string> rtn_list = new List<string>() { "Color" };
            rtn_list.Add("PageNo");
            rtn_list.Add("Class");
            rtn_list.Add("Style");
            rtn_list.Add("Weight");
            rtn_list.Add("SellStartDate");
            rtn_list.Add("SellEndDate");
            rtn_list.Add("DiscontinuedDate");
            return rtn_list;
        }


    }
}