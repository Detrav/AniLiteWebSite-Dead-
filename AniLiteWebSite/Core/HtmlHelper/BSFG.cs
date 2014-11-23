using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AniLiteWebSite.Core.HtmlHelper
{
    public class BSFG : IDisposable
    {
        private string action;
        private string method;
        private string fclass;
        private int md;
        private int sm;
        public BSFG(string Action,string Method,string FClass,int Md,int Sm)
        {
            action = Action;
            method = Method;
            fclass = FClass;
            md = Md;
            sm = Sm;
        }

        public MvcHtmlString Begin()
        {
            return new MvcHtmlString(String.Format(
                "<form action=\"{0}\" class = \"{1}\" method=\"{2}\" role=\"form\"",
                action,
                fclass,
                method));
        }


        public MvcHtmlString FormGroup(string label, string content)
        {
            if (label == null)
            {
                return new MvcHtmlString(String.Format(
                    "<div class=\"form-group\"><div class=\"col-sm-offset-{1} col-md-offset-{2} col-sm-{3} col-md-{4}\">{0}</div></div>",
                    content,sm,md, 12 - sm, 12 - md));
            }
            else
            {
                return new MvcHtmlString(String.Format(
                    "<div class=\"form-group\">{0}<div class=\"col-sm-{2} col-md-{3}\">{1}</div></div>",
                    label, content, 12 - sm, 12 - md));
            }
        }

        public string Label(string _for, string _value)
        {
            return String.Format(
                "<label class=\"col-sm-{0} col-md-{1} control-label\" for=\"{2}\">{3}</label>",
                sm,md,_for,_value);
        }

        public string TextBox(string _for, string _value = "", string _placeholder = "")
        {
             return String.Format(
                 "<input class=\"form-control\" id=\"{0}\" name=\"{0}\" placeholder=\"{1}\" type=\"text\" value=\"{2}\">",
            _for, _placeholder, _value);
        }

        public string TextBoxList(string _for, string[] _value = null, string _placeholder = "")
        {
            var sb = new StringBuilder();
            if (_value != null)
            {
                for(int i = 0;i<_value.Count();i++)
                {
                sb.Append("<div class=\"input-group\">");
                sb.Append(TextBox(String.Format("{0}[{1}]",_for,i),_value[i],_placeholder));
                sb.Append("<span class=\"input-group-btn\">");
                sb.Append(Button("Delete" + _for, "Удалить", "", "btn btn-danger"));
                sb.Append("</span>");
                sb.Append("</div>");
                }
            }
            sb.Append(Button("Add"+_for,"Добавить","","btn btn-success"));
            return sb.ToString();
        }

        public string Button(string _for,string _value ="Кнопка",string _onclick ="", string _class ="btn")
        {
            return String.Format(
                "<input type=\"button\" name=\"{0}\" value = \"{1}\" onclick=\"{2}\" class =\"{3}\" >",
                _for, _value, _onclick, _class);
        }

        public string TextArea(string _for,int row = 4, string _value = "", string _placeholder = "")
        {
            return String.Format(
                "<textarea class=\"form-control\" name=\"{0}\" rows = \"{1}\" placeholder=\"{2}\">{3}</textarea>",
                _for,row,_placeholder,_value);
        }

        public MvcHtmlString End()
        {
            return new MvcHtmlString("</form>");
        }

        public void Dispose() { }
    }
}