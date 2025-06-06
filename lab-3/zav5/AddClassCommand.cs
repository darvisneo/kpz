using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zav5
{
    public class AddClassCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly string _className;
        private bool _wasAdded;

        public AddClassCommand(LightElementNode element, string className)
        {
            _element = element;
            _className = className;
        }

        public void Execute()
        {
            if (!_element.CssClasses.Contains(_className))
            {
                _element.AddClass(_className);
                _wasAdded = true;
            }
        }

        public void Undo()
        {
            if (_wasAdded)
            {
                _element.CssClasses.Remove(_className);
            }
        }
    }

}
