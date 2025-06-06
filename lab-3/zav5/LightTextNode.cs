﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zav5
{
    public class LightTextNode : LightNode
    {
        public string Text { get; }

        public LightTextNode(string text)
        {
            Text = text;
        }

        public override string OuterHTML => Text;
        public override string InnerHTML => Text;

        protected override void OnTextRendered()
        {
            Console.WriteLine($"Text was rendered: {Text}");
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitTextNode(this);
        }

    }
}
