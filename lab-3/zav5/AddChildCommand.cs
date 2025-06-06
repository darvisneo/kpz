using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zav5
{
    public class AddChildCommand : ICommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;
        private int _index;

        public AddChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public void Execute()
        {
            _index = _parent.Children.Count;
            _parent.AddChild(_child);
        }

        public void Undo()
        {
            if (_index < _parent.Children.Count && _parent.Children[_index] == _child)
            {
                _parent.Children.RemoveAt(_index);
            }
        }
    }

}
