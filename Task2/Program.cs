using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var encoding = Encoding.GetEncoding("windows-1251");
            char[] alphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й' };
            var k = "3456789012";

            List<string> fileStr = ReadFile("E:\\ProjectsC#\\Task2\\input.txt", encoding);
            WriteFile(EncriptionList(fileStr,alphabet,k), "E:\\ProjectsC#\\Task2\\output.txt",encoding);
        }

        static List<string> EncriptionList(List<string> fileStr,char[] alphabet,string k)
        {
            var encListStr = new List<string>();
            var kLength = k.Length;
            foreach (var str in fileStr)
            {
                char[] encChar = new char[str.Length];
                for (int i = 0; i < str.Length; i++)
                {

                    if (Char.IsLetter(str[i]))
                    {
                        if (Char.IsLower(str[i]))
                            encChar[i] = Char.ToLower(alphabet[k[i % kLength] - '0']);
                        else
                            encChar[i] = Char.ToUpper(alphabet[k[i % kLength] - '0']);

                    }
                    else
                        encChar[i] = str[i];
                }
                encListStr.Add(new string(encChar));
            }
            return encListStr;
        }

        static void WriteFile(List<string> encListStr, string path, Encoding encoding)
        {
            using (var sw = new StreamWriter(path, append: false, encoding: encoding))
            {
                foreach (var str in encListStr)
                {
                    sw.WriteLine(str);
                }
            }
        }

        static List<string> ReadFile(string path,Encoding encoding)
        {
            string line;
            var fileStr = new List<string>();
            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path, encoding: encoding))
                {
                    line = sr.ReadLine();

                    while (line != null)
                    {
                        fileStr.Add(line);
                        line = sr.ReadLine();
                    }

                }
            }
            return fileStr;
        }
    }
}
