using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zav5
{
    public class StatsVisitor : IVisitor
    {
        public int ElementCount { get; private set; }
        public int TextCount { get; private set; }
        public int TotalClasses { get; private set; }

        public void VisitElementNode(LightElementNode node)
        {
            ElementCount++;
            TotalClasses += node.CssClasses.Count;
        }

        public void VisitTextNode(LightTextNode node)
        {
            TextCount++;
        }
    }

}
