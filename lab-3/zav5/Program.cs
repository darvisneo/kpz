using System;
using System.Collections.Generic;
using System.Text;
using zav5;

namespace zav5
{

    public enum DisplayType
    {
        Block,
        Inline
    }

    public enum TagType
    {
        Paired,
        SelfClosing
    }
    public interface ILightNodeIterator
    {
        IEnumerable<LightNode> Traverse();
    }
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public interface IVisibilityState
    {
        string ApplyStyle();
    }
    public class VisibleState : IVisibilityState
    {
        public string ApplyStyle()
        {
            return "display: block;";
        }
    }

    public class HiddenState : IVisibilityState
    {
        public string ApplyStyle()
        {
            return "display: none;";
        }
    }
    public abstract class LightNode
    {
        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }
        public void Render()
        {
            OnCreated();
            OnStylesApplied();
            OnClassListApplied();
            OnTextRendered();
            OnInserted();
        }

        protected virtual void OnCreated() { }
        protected virtual void OnStylesApplied() { }
        protected virtual void OnClassListApplied() { }
        protected virtual void OnTextRendered() { }
        protected virtual void OnInserted() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ul = new LightElementNode("ul", DisplayType.Block, TagType.Paired);
            ul.AddClass("spisok");

            var li1 = new LightElementNode("li", DisplayType.Block, TagType.Paired);
            li1.AddChild(new LightTextNode("Firs element"));

            var li2 = new LightElementNode("li", DisplayType.Block, TagType.Paired);
            li2.AddChild(new LightTextNode("Second elemet"));

            ul.AddChild(li1);
            ul.AddChild(li2);

            Console.WriteLine("OuterHTML");
            Console.WriteLine(ul.OuterHTML);

            Console.WriteLine("\nInnerHTML");
            Console.WriteLine(ul.InnerHTML);
        }
    }
}
