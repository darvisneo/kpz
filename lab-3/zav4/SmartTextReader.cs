using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zav4
{
    class SmartTextReader
    {
        public virtual char[][] ReadFile(string path)
        {
            var lines = File.ReadAllLines(path);
            var result = new List<char[]>();

            foreach (var line in lines)
            {
                result.Add(line.ToCharArray());
            }

            return result.ToArray();
        }
    }
}
