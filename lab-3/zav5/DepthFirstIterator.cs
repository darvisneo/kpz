using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zav5
{
    public class DepthFirstIterator : ILightNodeIterator
    {
        private readonly LightNode _root;

        public DepthFirstIterator(LightNode root)
        {
            _root = root;
        }

        public IEnumerable<LightNode> Traverse()
        {
            var stack = new Stack<LightNode>();
            stack.Push(_root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;

                if (current is LightElementNode elementNode)
                {
                    for (int i = elementNode.Children.Count - 1; i >= 0; i--)
                    {
                        stack.Push(elementNode.Children[i]);
                    }
                }
            }
        }
    }

}
