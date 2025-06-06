using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace zav4
{
    class SmartTextReaderLocker : SmartTextReader
    {
        private SmartTextReader reader = new SmartTextReader();
        private Regex denyPattern;

        public SmartTextReaderLocker(string regexPattern)
        {
            denyPattern = new Regex(regexPattern, RegexOptions.IgnoreCase);
        }

        public override char[][] ReadFile(string path)
        {
            if (denyPattern.IsMatch(path))
            {
                Console.WriteLine("[ACCESS DENIED] Access to this file is blocked.");
                return Array.Empty<char[]>();
            }

            return reader.ReadFile(path);
        }
    }
}
