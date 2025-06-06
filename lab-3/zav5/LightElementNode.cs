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
        private IVisibilityState _visibilityState;
        public IVisibilityState VisibilityState
        {
            get => _visibilityState;
            set
            {
                _visibilityState = value;
                Console.WriteLine($"Visibility state changed for {TagName}");
            }
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitElementNode(this);
            foreach (var child in Children)
            {
                child.Accept(visitor);
            }
        }

        public LightElementNode(string tagName, DisplayType display, TagType tagType)
        {
            TagName = tagName;
            Display = display;
            TagType = tagType;
            CssClasses = new List<string>();
            Children = new List<LightNode>();
            _visibilityState = new VisibleState();
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
        protected override void OnCreated()
        {
            Console.WriteLine($"Element {TagName} was created");
        }

        protected override void OnClassListApplied()
        {
            if (CssClasses.Count > 0)
            {
                Console.WriteLine($"Classes applied to {TagName}: {string.Join(", ", CssClasses)}");
            }
        }
        public override string OuterHTML
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append('<').Append(TagName);
                sb.Append(" style=\"").Append(_visibilityState.ApplyStyle()).Append("\"");
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
