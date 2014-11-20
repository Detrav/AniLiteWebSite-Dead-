using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AniLiteWebSite.Core.HtmlHelper
{
    public static class BootstrapExtension
    {
        public static MvcHtmlString BSFromGroupForTextBox<TModel, TProperty>(
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

        public static MvcHtmlString BSFromGroupForTextArea<TModel, TProperty>(
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

        public static MvcHtmlString BSFromGroupSubmitSuccess<TModel>(
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

        public static MvcHtmlString BSFromGroupLabel<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            int col_sm)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"form-group\">");
            sb.AppendLine(LabelExtensions
                .LabelFor(html, expression, new { @class = String.Format("col-sm-{0} control-label", 12 - col_sm) }).ToHtmlString());
            sb.AppendLine(String.Format("<div class=\"col-sm-{0}\">", col_sm));
            sb.AppendLine(LabelExtensions
                .Label(html, expression.Compile()(html.ViewData.Model).ToString(), new { @class = "form-control"}).ToHtmlString());
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString BSFromGroupForCollectionTextBox<TModel, TProperty>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression,
            int col_sm,
            string PlaceHolder)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"form-group\">");
            sb.AppendLine(LabelExtensions
                .LabelFor(html, expression, new { @class = String.Format("col-sm-{0} control-label", 12 - col_sm) }).ToHtmlString());
            sb.AppendLine(String
                .Format("<div class=\"col-sm-{0}\">", 12 - col_sm));
            ////////////////////////////////////////////////buttons
            sb.AppendLine("</div>");
            //For
            
                sb.AppendLine(String.Format("<div class=\"col-sm-{0}\">", col_sm));
                sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }
    }
}
