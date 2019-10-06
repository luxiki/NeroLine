using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace Nero_BL_namespace
{
    public interface INero_BL
    {
        string CheckFile(string filePath, ref bool isopen);
        string SaveFile(string filePath);
        string AddSmd(string filePath, string addNameSmd, string addRotation);
    }

    

    public class Nero_BL : INero_BL
    {
        public string CheckFile(string filePath, ref bool isopen)
        {
            int errorLine = 0;
            try
            {
                if (!File.Exists(filePath)) { return "Не возможно открыть фаил"; }

                content = File.ReadAllLines(filePath);

                foreach (string i in content)
                {
                    errorLine++;
                    int t = 0;
                    if (i != "")
                    {
                        for (int j = 0; j < i.Length; j++)
                        {
                            if ('\t' == i[j]) { t++; }
                        }
                        if (t != 4) { return "Фаил повреждён в строке" + errorLine; }

                    }
                }
            }
            catch (Exception ex) { return "Не возможно открыть фаил"+ex.Message; }
            string[] temp = filePath.Split('\\');
            openFileName = temp[temp.Length-1];
            openFilePath = filePath;
            isopen = true;
            return "Фаил открыт. Выберите линию и схраните фаил!";
         }

        public string SaveFile(string filePath)
        {
            int errorLine = 1;
            try
            {
                if (!File.Exists(filePath+".ini")) { return "Фаил линии не найден!!!"; }
                Dictionary<string, int> map = new Dictionary<string, int>();
                string[] strLine = File.ReadAllLines(filePath + ".ini");
                string[] strSplitLine;
                int itemp;
               
                for (int i = 1; i < strLine.Length; i++)
                {
                    errorLine++;
                    if (strLine[i] != "")
                    {
                        strSplitLine = strLine[i].Split(':');
                        if (strSplitLine.Length == 2)
                        {
                            map.Add(strSplitLine[0], int.Parse(strSplitLine[1]));
                        }
                        else return "Фаил линии повреждён в строке " + errorLine + " !!!";
                    }
                }

                
                for (int i = 0; i < content.Length; i++)
                {
                    if (content[i] != "")
                    {
                        strSplitLine = content[i].Split('\t');

                        if (map.ContainsKey(strSplitLine[1]))
                        {
                            itemp = map[strSplitLine[1]];
                            itemp += int.Parse(strSplitLine[4]);
                            if (itemp >= 180) { itemp -= 360; }
                            if (itemp <= -180) { itemp += 360; }
                            strSplitLine[4] = Convert.ToString(itemp);
                        }


                        if (strSplitLine[0][0] == 'R' || strSplitLine[0][0] == 'C' || strSplitLine[0][0] == 'L' || strSplitLine[0][0] == 'S')
                        {
                            itemp = int.Parse(strSplitLine[4]);
                            if (itemp > 90) { strSplitLine[4] = Convert.ToString(itemp - 180); }
                            if (itemp < -90) { strSplitLine[4] = Convert.ToString(itemp + 180); }
                        }


                        content[i] = strSplitLine[0] + '\t' + strSplitLine[1] + '\t' + strSplitLine[2] + '\t' + strSplitLine[3] + '\t' + strSplitLine[4];

                    }

                }

                string fls;
                if (Directory.Exists(strLine[0])) { fls = strLine[0]  + openFileName; }
                else { fls = openFilePath + ".txt"; }

                File.WriteAllLines(fls, content);
                errorLine = 0;
                return "Фаил сохранён в " + fls;
            }
            catch (Exception ex) { return "Ошибка в файле!!!" + ex.Message; }
        }

        public string AddSmd(string filePath, string addNameSmd , string addRotation)
        {
            try
            {
                int r = Convert.ToInt32(addRotation);
                string[] strLine;
                string[] strSplitLine;

                if (File.Exists(filePath+".ini"))
                {
                    strLine = File.ReadAllLines(filePath + ".ini");
                }
                else return "Фаил линии не найден";

                for (int i = 1; i < strLine.Length; i++)
                {
                    strSplitLine = strLine[i].Split(':');
                    if (addNameSmd==strSplitLine[0])
                    {
                        return "Такой компонент уже существует";
                    }
                }
                string[] str = new string[1];
                str[0] = string.Format("{0}:{1}",addNameSmd,addRotation);
                
                File.AppendAllLines(filePath + ".ini" , str);

                
            }
            catch (Exception ex)
            {
                return "Error " + ex.Message;
            }

            
            return "Компонент успешно добавлен!";
        }


        private string[] content;
        private string openFilePath;
        private string openFileName;

    }




}
