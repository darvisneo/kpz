using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zav5
{
    public class BreadthFirstIterator : ILightNodeIterator
    {
        private readonly LightNode _root;

        public BreadthFirstIterator(LightNode root)
        {
            _root = root;
        }

        public IEnumerable<LightNode> Traverse()
        {
            var queue = new Queue<LightNode>();
            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                yield return current;

                if (current is LightElementNode elementNode)
                {
                    foreach (var child in elementNode.Children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }
        }
    }

}
