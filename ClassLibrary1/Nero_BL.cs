using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Nero_BL_namespace
{
    public interface INero_BL{
        bool CheckFile(string filePath , ref int errorLine);
        bool SaveFile(string filePath);

    }

    public class Nero_BL : INero_BL
    {
        public bool CheckFile(string filePath, ref int errorLine)
        {
            errorLine = 0;
            try
            {
                if (!File.Exists(filePath)) { return false; }

                string[] content = File.ReadAllLines(filePath);

                foreach (string i in content)
                {
                    errorLine++;
                    int t = 0;
                    if (i == "") { return true; }
                    for (int j = 0; j < i.Length; j++)
                    {
                        if ('\t' == i[j]) { t++; }
                    }
                    if (t != 4) { return false; }
                }
            }
            catch (Exception ex){ return false; }

            return true;
        }

        public bool SaveFile(string filePath)
        {
            throw new NotImplementedException();
        }

        //private string[] content  = new string[];
        

    }



}
