using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;

namespace RemGRE
{
    class ChoiceAnalyzer
    {
        public static ArrayList Analyze(String cmd)
        {
            try
            {
                ArrayList choices = new ArrayList();
                String[] elements = cmd.Split(';');
                foreach (String element in elements)
                {
                    if (!element.Contains("-"))
                    {
                        if (!choices.Contains(element))
                            choices.Add(element);
                    }
                    else
                    {
                        String[] range = element.Split('-');
                        int begin = Convert.ToInt32(range[0]);
                        int end = Convert.ToInt32(range[1]);
                        AddContinuousLists(begin, end, choices);
                    }
                }
                return choices;
            }
            catch (FormatException fe)
            {
                return null;
            }

        }
        private static void AddContinuousLists(int begin, int end, ArrayList list)
        {
            for (int i = begin; i <= end; i++)
            {
                if (!list.Contains(i.ToString()))
                    list.Add(i.ToString());
            }
        }
    }
}
