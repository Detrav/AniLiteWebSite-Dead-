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

        public MvcHtmlString FormGroup(string label, string content,string with_js)
        {
            if (label == null)
            {
                return new MvcHtmlString(String.Format(
                    "<div class=\"form-group js-for-{5}\"><div class=\"col-sm-offset-{1} col-md-offset-{2} col-sm-{3} col-md-{4}\">{0}</div></div>",
                    content, sm, md, 12 - sm, 12 - md,with_js));
            }
            else
            {
                return new MvcHtmlString(String.Format(
                    "<div class=\"form-group js-for-{4}\">{0}<div class=\"col-sm-{2} col-md-{3}\">{1}</div></div>",
                    label, content, 12 - sm, 12 - md,with_js));
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

        public string TextBoxList(string _for, IEnumerable<string> __value = null, string _placeholder = "")
        {
            var sb = new StringBuilder();
            try
            {
                var _value = __value.ToArray();
                if (_value != null)
                {
                    for (int i = 0; i < _value.Count(); i++)
                    {
                        sb.Append("<div class=\"input-group\">");
                        sb.Append(TextBox(String.Format("{0}[{1}]", _for, i), _value[i], _placeholder));
                        sb.Append("<span class=\"input-group-btn\">");
                        sb.Append(Button("Delete" + _for, "Удалить", "BSFGDelete('" + _for + "','" + i.ToString() + "')", "btn btn-danger"));
                        sb.Append("</span>");
                        sb.Append("</div>");
                    }
                }
            }
            catch { }
            sb.Append(Button("Add" + _for, "Добавить", "BSFGAdd('" + _for + "','" + _placeholder + "')", "btn btn-success"));
            return sb.ToString();
        }

        public string Button(string _for,string _value ="Кнопка",string _onclick ="", string _class ="btn")
        {
            return String.Format(
                "<a id=\"{0}\" name=\"{0}\" onclick=\"{2}\" class =\"{3}\" >{1}</a>",
                _for, _value, _onclick, _class);
        }

        public string ButtonOnMouseDown(string _for, string _value = "Кнопка", string _onclick = "", string _class = "btn")
        {
            return String.Format(
                "<a id=\"{0}\" name=\"{0}\" onmousedown=\"{2}\" class =\"{3}\" >{1}</a>",
                _for, _value, _onclick, _class);
        }

        public string TextArea(string _for,int row = 4, string _value = "", string _placeholder = "")
        {
            return String.Format(
                "<textarea class=\"form-control\" name=\"{0}\" rows = \"{1}\" placeholder=\"{2}\">{3}</textarea>",
                _for,row,_placeholder,_value);
        }

        public string ImageArea(string _for,string _value ="",string _placeholder = "Ссылка на картинку")
        {
            var sb = new StringBuilder();
            sb.Append("<div class=\"input-group\">");
            sb.Append(TextBox(_for, _value, _placeholder));
            sb.Append("<span class=\"input-group-btn\">");
            sb.Append(Button("Test" + _for, "Проверить", "BSFGTestImg('" + _for + "')", "btn btn-default"));
            sb.Append("</span>");
            sb.Append("</div>");
            sb.Append("<img class='test-image-for-" + _for + "'>");
            return sb.ToString();
        }

        public string CheckBox(string _for, bool _value = false)
        {
            
            return String.Format(
                "<input class=\"form-control\" id=\"{0}\" name=\"{0}\"  type=\"checkbox\" {1}>",
                _for, (_value ? "checked=\"checked\"" : ""));
        }

        public string DateBox(string _for, DateTime _value)
        {
           var sb = new StringBuilder();
            sb.Append("<div class=\"input-group\">");
            sb.Append(String.Format(
                 "<input class=\"form-control datepicker\" id=\"{0}\" name=\"{0}\" type=\"text\" value=\"{1}\">",
            _for, _value.ToShortDateString()));
            sb.Append("</div>");
            return sb.ToString();
        }
        
        public string NumericalBox(string _for, int _value)
        {
            var sb = new StringBuilder();
            sb.Append("<div class=\"input-group\">");
            sb.Append(TextBox(_for, _value.ToString()));
            sb.Append("<span class=\"input-group-btn\">");
            sb.Append(Button("Minus" + _for, "<span class=\"glyphicon glyphicon-minus\"></span>", "BSFGMinus('" + _for + "')", "btn btn-danger"));
            sb.Append(Button("Plus" + _for, "<span class=\"glyphicon glyphicon-plus\"></span>", "BSFGPlus('" + _for + "')", "btn btn-success"));
            sb.Append("</span>");
            sb.Append("</div>");
            return sb.ToString();
        }

        public string DropDownListBox(string _for, string value, IEnumerable<string> list)
        {
            var sb = new StringBuilder();
            sb.Append(String.Format("<select name =\"{0}\" class=\"form-control\" >",_for));
            sb.Append("<option value=\"\">Нету</value>");
            foreach(var it in list)
            {
                sb.Append(String.Format(
                    "<option value=\"{0}\" {1}>{0}</options>",
                    it,(it == value ? "selected":"")));
            }
            sb.Append("</select>");
            return sb.ToString();
        }

        public string SelectListBox(string _for, IEnumerable<string> _value, IEnumerable<string> list)
        {
            try
            {
                List<string> value;
                if (_value != null) { value = _value.ToList(); }
                else { value = new List<string>(); }
                var sb = new StringBuilder();
                sb.Append(String.Format("<select name =\"{0}\" multiple class=\"form-control\" size=\"7\" >", _for));
                foreach (var it in list)
                {
                    sb.Append(String.Format(
                        "<option value=\"{0}\" {1}>{0}</options>",
                        it, (value.IndexOf(it) >= 0 ? "selected" : "")));
                }
                sb.Append("</select>");
                return sb.ToString();
            }
            catch {return "";}
        }


        public MvcHtmlString End()
        {
            return new MvcHtmlString("</form>");
        }

        public void Dispose() { }
    }
}