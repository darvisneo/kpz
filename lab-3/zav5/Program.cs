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
    public interface IVisitor
    {
        void VisitElementNode(LightElementNode node);
        void VisitTextNode(LightTextNode node);
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
        public abstract void Accept(IVisitor visitor);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ul = new LightElementNode("ul", DisplayType.Block, TagType.Paired);
            ul.AddClass("spisok");
            ul.Render();

            var li1 = new LightElementNode("li", DisplayType.Block, TagType.Paired);
            li1.AddChild(new LightTextNode("First element"));

            var li2 = new LightElementNode("li", DisplayType.Block, TagType.Paired);
            li2.AddChild(new LightTextNode("Second element"));

            ul.AddChild(li1);
            ul.AddChild(li2);

            Console.WriteLine("OuterHTML");
            Console.WriteLine(ul.OuterHTML);

            Console.WriteLine("\nInnerHTML");
            Console.WriteLine(ul.InnerHTML);

            var addLi1Command = new AddChildCommand(ul, li1);
            addLi1Command.Execute();

            var addLi2Command = new AddChildCommand(ul, li2);
            addLi2Command.Execute();

            li1.VisibilityState = new HiddenState();

            Console.WriteLine("\nDepth first traversal:");
            var depthFirstIterator = new DepthFirstIterator(ul);
            foreach (var node in depthFirstIterator.Traverse())
            {
                Console.WriteLine(node.GetType().Name);
            }

            var statsVisitor = new StatsVisitor();
            ul.Accept(statsVisitor);
            Console.WriteLine($"\nstats: Elements={statsVisitor.ElementCount}, " +
                             $"Text nodes={statsVisitor.TextCount}, " +
                             $"Total classes={statsVisitor.TotalClasses}");
        }
    }
}
