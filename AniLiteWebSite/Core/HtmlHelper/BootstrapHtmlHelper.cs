using AniLiteWebSite.Core.DataBase.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AniLiteWebSite.Core.HtmlHelper
{
    public static class BootstrapExtension
    {
        public static MvcHtmlString BSFGForTextBox<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            int col_sm,
            string PlaceHolder)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"form-group\">");
            sb.AppendLine(LabelExtensions
                .LabelFor(html, expression, new { @class = String.Format("col-sm-{0} control-label", 12 - col_sm) }).ToHtmlString());
            sb.AppendLine(String.Format("<div class=\"col-sm-{0}\">", col_sm));
            sb.AppendLine(InputExtensions
                .TextBoxFor(html, expression, new { @class = "form-control", placeholder = PlaceHolder }).ToHtmlString());
            sb.AppendLine(ValidationExtensions
                .ValidationMessageFor(html, expression).ToHtmlString());
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString BSFGForTextArea<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            int col_sm,
            string PlaceHolder)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"form-group\">");
            sb.AppendLine(LabelExtensions
                .LabelFor(html, expression, new { @class = String.Format("col-sm-{0} control-label", 12 - col_sm) }).ToHtmlString());
            sb.AppendLine(String.Format("<div class=\"col-sm-{0}\">", col_sm));
            sb.AppendLine(TextAreaExtensions
                .TextAreaFor(html, expression, 4, 1, new { @class = "form-control", placeholder = PlaceHolder }).ToHtmlString());
            sb.AppendLine(ValidationExtensions
                .ValidationMessageFor(html, expression).ToHtmlString());
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString BSFGSubmitSuccess<TModel>(
            this HtmlHelper<TModel> html,
            string Name,
            int col_sm,
            string Value)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"form-group\">");
            sb.AppendLine(String.Format(
                "<input type=\"submit\" name=\"{0}\" value=\"{1}\" class=\"col-sm-offset-{2} col-sm-{3} btn btn-success\" />",
                Name, Value, 12 - col_sm, col_sm));
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString BSFGLabel<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            int col_sm)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"form-group\">");
            sb.AppendLine(LabelExtensions
                .LabelFor(html, expression, new { @class = String.Format("col-sm-{0} control-label", 12 - col_sm) }).ToHtmlString());
            sb.AppendLine(String.Format("<div class=\"col-sm-{0}\">", col_sm));
            string value;
            try { value = expression.Compile()(html.ViewData.Model).ToString(); }
            catch { value = ""; }
            sb.AppendLine(LabelExtensions
                .Label(html, value, new { @class = "form-control"}).ToHtmlString());
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString BSFGForListTextBox<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            int col_sm,
            string PlaceHolder)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"form-group\">");
            sb.AppendLine(LabelExtensions
                .LabelFor(html, expression, new { @class = String.Format("col-sm-{0} control-label",12-col_sm) }).ToHtmlString());
                      
            string name = (expression.Body as MemberExpression).Member.Name;

            sb.AppendLine(String.Format("<div class=\"col-sm-{0} js-for-{1}\">", col_sm,name));
            IEnumerable<object> list = expression.Compile()(html.ViewData.Model) as IEnumerable<object>;
            int i = 0;if(list!=null)
            foreach(var it in list)
            {
                sb.AppendLine("<div class=\"input-group\">");
                sb.AppendLine(InputExtensions
                    .TextBox(html, String.Format("{0}[{1}]", name, i), it,
                    new { @class = "form-control", placeholder = PlaceHolder }
                    ).ToHtmlString());
                sb.AppendLine("<span class=\"input-group-btn\">");
                sb.AppendLine(String.Format(
                "<input type=\"button\" value=\"Удалить\" class=\"btn btn-danger\" onclick=\"BSFGRemove('{0}','{1}')\">", name, i));
                sb.AppendLine("</span>");
                sb.AppendLine("</div>");
                i++;
            }
            
            
            sb.AppendLine(String.Format(
                "<input type=\"button\" value=\"Добавить\" class=\"form-control btn btn-xs btn-success\" onclick=\"BSFGAdd('{0}')\" >", name));
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString BSFGForCheckBox<TModel>(
           this HtmlHelper<TModel> html,
           Expression<Func<TModel, bool>> expression,
           int col_sm)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"form-group\">");
            sb.AppendLine(LabelExtensions
                .LabelFor(html, expression, new { @class = String.Format("col-sm-{0} control-label", 12 - col_sm) }).ToHtmlString());
            sb.AppendLine(String.Format("<div class=\"col-sm-{0}\">", col_sm));
            sb.AppendLine(InputExtensions
                .CheckBoxFor(html, expression, new { @class = "form-control"}).ToHtmlString());
            sb.AppendLine(ValidationExtensions
                .ValidationMessageFor(html, expression).ToHtmlString());
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString BSFGForCalendar<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            int col_sm)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"form-group\">");
            sb.AppendLine(LabelExtensions
                .LabelFor(html, expression, new { @class = String.Format("col-sm-{0} control-label", 12 - col_sm) }).ToHtmlString());
            sb.AppendLine(String.Format("<div class=\"col-sm-{0}\">", col_sm));
            sb.AppendLine(InputExtensions
                .TextBoxFor(html, expression, new { @class = "form-control" }).ToHtmlString());
            sb.AppendLine(ValidationExtensions
                .ValidationMessageFor(html, expression).ToHtmlString());
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString BSFGForNumericBox<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            int col_sm)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"form-group\">");
            sb.AppendLine(LabelExtensions
                .LabelFor(html, expression, new { @class = String.Format("col-sm-{0} control-label", 12 - col_sm) }).ToHtmlString());
            sb.AppendLine(String.Format("<div class=\"col-sm-{0}\">", col_sm));
            sb.AppendLine(InputExtensions
                .TextBoxFor(html, expression, new { @class = "form-control" }).ToHtmlString());
            sb.AppendLine(ValidationExtensions
                .ValidationMessageFor(html, expression).ToHtmlString());
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString BSFGForEnumDDL<TModel>(
         this HtmlHelper<TModel> html,
            Type MyEnum,
            string ValName,
            string label,
            int col_sm,
            string btn_value,
            string btn_name,
            string defaultvalue)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"form-group\">");
            sb.AppendLine(LabelExtensions
                .Label(html, ValName,label, new { @class = String.Format("col-sm-{0} control-label", 12 - col_sm) }).ToHtmlString());
            sb.AppendLine(String.Format("<div class=\"col-sm-{0}\">", col_sm));
            sb.AppendLine("<div class=\"input-group\">");
            sb.Append(String.Format("<select name=\"{0}\" class=\"form-control\">", ValName));
            foreach(var iten in Enum.GetValues(MyEnum))
            {
                var value = iten.ToString();
                var name = (MyEnum.GetMember(iten.ToString()).First().GetCustomAttributes(typeof(DisplayAttribute), true).First() as DisplayAttribute).Name;
                //var da = iten.GetCustomAttributes(typeof(DisplayAttribute),true);
                if (value == defaultvalue)
                {
                    sb.Append(String.Format("<option selected value=\"{0}\">", value));
                }
                else
                {
                    sb.Append(String.Format("<option value=\"{0}\">", value));
                }
                sb.Append(name);
                sb.Append("</option>");

            }
            sb.Append("</select>");
            sb.AppendLine("<span class=\"input-group-btn\">");
            sb.AppendLine(String.Format(
            "<input name =\"{0}\" type=\"submit\" value=\"{1}\" class=\"btn btn-success\">",
            btn_name,btn_value));
            sb.AppendLine("</span>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString BSFGForMetaData<TModel>(
            this HtmlHelper<TModel> html,
            MetaProduct meta, int num, 
            int col_sm)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"form-group\">");
            var name = (typeof(TypeOfMetaProduct).GetMember(meta.Type.ToString()).First().GetCustomAttributes(typeof(DisplayAttribute),true).First() as DisplayAttribute).Name;
            sb.AppendLine(LabelExtensions
                .Label(html, name, new { @class = String.Format("col-sm-{0} control-label", 12 - col_sm) }).ToHtmlString());
            
            sb.AppendLine(String.Format("<div class=\"col-sm-{0}\">", col_sm));
            sb.AppendLine("<div class=\"input-group\">");
            sb.AppendLine(InputExtensions
                .Hidden(html, String
                .Format("MetaData[{0}].Type", num), meta.Type.ToString()).ToHtmlString());
            switch(meta.Type)
            {
                case TypeOfMetaProduct.Author:
                case TypeOfMetaProduct.Country:
                case TypeOfMetaProduct.Director:
                case TypeOfMetaProduct.FromURI:
                case TypeOfMetaProduct.Genre:
                case TypeOfMetaProduct.InRole:
                case TypeOfMetaProduct.Name:
                case TypeOfMetaProduct.PosterFromURI:
                case TypeOfMetaProduct.Type:
                case TypeOfMetaProduct.View:
                case TypeOfMetaProduct.NumberOfEpisode:
                    sb.AppendLine(InputExtensions
                        .TextBox(html, String
                        .Format("MetaData[{0}].String", num), meta.String, new { @class = "form-control" }).ToHtmlString());
                    break;
                case TypeOfMetaProduct.Begin:
                case TypeOfMetaProduct.End:
                    sb.AppendLine(InputExtensions
                        .TextBox(html, String
                        .Format("MetaData[{0}].DateTime", num), meta.Date.ToShortDateString(), new { @class = "form-control" }).ToHtmlString());
                    break;
                case TypeOfMetaProduct.Ended:
                    sb.AppendLine(InputExtensions
                        .CheckBox(html, String
                        .Format("MetaData[{0}].Bool", num), meta.Bool, new { @class = "form-control" }).ToHtmlString());
                    break;
            }
            sb.AppendLine("<span class=\"input-group-btn\">");
            sb.AppendLine(String.Format(
            "<input name =\"MetaData[{0}].String\" type=\"submit\" value=\"Удалить\" class=\"btn btn-success\">",num));
            sb.AppendLine("</span>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }        
    }
}
