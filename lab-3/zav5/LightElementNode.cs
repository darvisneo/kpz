using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zav5
{
    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public DisplayType Display { get; }
        public TagType TagType { get; }
        public List<string> CssClasses { get; }
        public List<LightNode> Children { get; }

        public LightElementNode(string tagName, DisplayType display, TagType tagType)
        {
            TagName = tagName;
            Display = display;
            TagType = tagType;
            CssClasses = new List<string>();
            Children = new List<LightNode>();
        }

        public void AddClass(string className) => CssClasses.Add(className);

        public void AddChild(LightNode child)
        {
            if (TagType == TagType.SelfClosing)
                throw new InvalidOperationException("Selfclosing tags can`t have children.");
            Children.Add(child);
        }

        public override string InnerHTML
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var child in Children)
                {
                    sb.Append(child.OuterHTML);
                }
                return sb.ToString();
            }
        }

        public override string OuterHTML
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append('<').Append(TagName);
                if (CssClasses.Count > 0)
                {
                    sb.Append(" class=\"").Append(string.Join(" ", CssClasses)).Append('"');
                }

                if (TagType == TagType.SelfClosing)
                {
                    sb.Append(" />");
                }
                else
                {
                    sb.Append('>').Append(InnerHTML).Append("</").Append(TagName).Append('>');
                }

                return sb.ToString();
            }
        }
    }
}
