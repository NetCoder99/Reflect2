using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Reflect2.HtmlHelpers
{
    public static class ProductEditRow
    {
        //public static object GetValue<T>(T model_dict, string field_name) where T : ViewDataDictionary
        //{
        //    object model_obj = model_dict.Model;
        //    List<PropertyInfo> model_props = model_obj.GetType().GetProperties().OrderBy(o => o.Name).ToList();
        //    PropertyInfo model_prop = model_props.Find(f => f.Name == field_name);
        //    return model_prop.GetValue(model_obj, null);
        //}

        //public static MvcHtmlString ProductLabel<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expr)
        //{
        //    var memberExpr = expr.Body as MemberExpression;
        //    ViewDataDictionary model_data = helper.ViewData as ViewDataDictionary;
        //    var model_name = memberExpr.Member.Name;
        //    var model_value = GetValue(model_data, model_name);
        //    string html_str = "<label class='control-label col-md-2' for='Name'>" + model_name + "</label>";
        //    MvcHtmlString rtn_html = new MvcHtmlString(html_str);
        //    return rtn_html;
        //}
        //public static MvcHtmlString ProductTextbox<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expr)
        //{
        //    var memberExpr = expr.Body as MemberExpression;
        //    ViewDataDictionary model_data = helper.ViewData as ViewDataDictionary;
        //    var model_name = memberExpr.Member.Name;
        //    var model_value = GetValue(model_data, model_name);
        //    string html_str = "";
        //    if (model_value != null)
        //    { html_str = "<label class='control-label col-md-2' for='Name'>" + model_value.ToString() + "</label>"; }
        //    else
        //    { html_str = "<label class='control-label col-md-2' for='Name'>" + "" + "</label>"; }
        //    var propertyType = typeof(TModel).GetProperties().Where(x => x.Name == model_name).First(); //.PropertyType;
        //    var attributes = propertyType.GetCustomAttributes(true); //.OfType<ValidationAttribute>();
        //    MvcHtmlString rtn_html = new MvcHtmlString(html_str);
        //    return rtn_html;
        //}



    }
}