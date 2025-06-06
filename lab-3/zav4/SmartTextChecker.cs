using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zav4
{
    class SmartTextChecker : SmartTextReader
    {
        private SmartTextReader reader = new SmartTextReader();

        public override char[][] ReadFile(string path)
        {
            Console.WriteLine($"[INFO] Opening file: {path}");

            char[][] result;
            try
            {
                result = reader.ReadFile(path);
                Console.WriteLine($"[INFO] Successfully read file: {path}");
                Console.WriteLine($"[INFO] Lines: {result.Length}");
                int totalChars = 0;
                foreach (var line in result)
                    totalChars += line.Length;
                Console.WriteLine($"[INFO] Total characters: {totalChars}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to read file: {ex.Message}");
                throw;
            }
            finally
            {
                Console.WriteLine($"[INFO] File closed: {path}");
            }

            return result;
        }
    }
}
