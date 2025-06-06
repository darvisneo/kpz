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

    public abstract class LightNode
    {
        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }
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
