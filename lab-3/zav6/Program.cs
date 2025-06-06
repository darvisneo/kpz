using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zav5
{
    public class LightElementFactory
    {
        private readonly Dictionary<string, LightElementNode> cache = new();

        public LightElementNode GetElement(string tagName)
        {
            if (cache.ContainsKey(tagName))
                return cache[tagName];

            var element = new LightElementNode(tagName, DisplayType.Block, TagType.Paired);
            cache[tagName] = element;
            return element;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("pg1513.txt");
            var root = new LightElementNode("div", DisplayType.Block, TagType.Paired);

            var factory = new LightElementFactory();

            long beforeMemory = GC.GetTotalMemory(true);

            bool firstLine = true;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string tag = firstLine ? "h1" :
                             line.Length < 20 ? "h2" :
                             line.StartsWith(" ") ? "blockquote" : "p";

                firstLine = false;

                var baseElement = factory.GetElement(tag);

                var element = new LightElementNode(baseElement.TagName, baseElement.Display, baseElement.TagType);
                element.AddChild(new LightTextNode(line));

                root.AddChild(element);
            }

            long afterMemory = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory usage: {(afterMemory - beforeMemory) / 1024.0:F2} KB");

            Console.WriteLine("\nHTML-First 1000\n");
            Console.WriteLine(root.OuterHTML[..1000]);
        }
    }
}
