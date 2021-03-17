using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
    public static class Calk
    {
        public static StringBuilder numsBuilder = new StringBuilder();
        public static StringBuilder mathBuider = new StringBuilder();
        public static StringBuilder mathBuiderSymb = new StringBuilder();
        public static string[] number = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public static string[] mathOperation = new string[] { "*", "-", "+", "/", "=" };
        public static double numMath1;
        public static double numMath2;
        public static double result;
        public static string action;
        public static int count = 0;
        public static int countAction = 0;
        public static string state = string.Empty;
        public static string btnSymbPoit = ".";

        public static void ClearExtention()
        {
            numMath1 = 0;
            numMath2 = 0;
            result = 0;
            action = string.Empty;
            count = 0;
            countAction = 0;
            numsBuilder.Clear();
            mathBuider.Clear();
            mathBuiderSymb.Clear();
        }
        public static string BtnNumber_Click(string btnSymb)
        {

            if (number.Contains(btnSymb))
            {
                var n = number.FirstOrDefault(num => num == btnSymb);
                 var lenth=numsBuilder.Length;

                if (numsBuilder.Length == 1)
                {
                    if (( numsBuilder[lenth-1].ToString() == ","  && numsBuilder[lenth - 2].ToString() == "0" ) ||
                       (numsBuilder[0].ToString() == "0" && btnSymb !="0" )
                       || (numsBuilder[0].ToString()!="0"))
                    {
                        numsBuilder.Append(n);
                        state = numsBuilder.ToString();
                        numMath2 = double.Parse(numsBuilder.ToString());
                        return numsBuilder.ToString();
                    }
                }
                else
                {
                    numsBuilder.Append(n);
                    state = numsBuilder.ToString();
                    numMath2 = double.Parse(numsBuilder.ToString());

                    return numsBuilder.ToString();
                }
            }
            return "";
        }
        public static (string, string) BtnClick_Operation(string btnSymb, string textCalk, string viewOperation)
        {

            if (count == 0)
            {
                numMath1 = numMath2;
            }

            if (mathOperation.Contains(btnSymb))
            {
                mathBuider.Append(state);
                textCalk = string.Empty;
                numsBuilder.Clear();
                var n = mathOperation.FirstOrDefault(num => num == btnSymb);
                mathBuider.Append(n);
                mathBuiderSymb.Append(n);
                action = n;
                viewOperation = mathBuider.ToString();
            }

            if (mathOperation.Contains(action))
            {
                if (count > 0)
                {
                    var tmpAction = mathBuiderSymb[countAction - 1].ToString();
                    result = СalculationRun(tmpAction);
                    numMath1 = result;
                    textCalk = result.ToString();
                    state = textCalk;
                    numMath2 = 0;
                }
                countAction++;
                count++;

            }
            return (textCalk, viewOperation);
        }
        public static string BtnClick_Point(string point)
        {
            if (btnSymbPoit == point && numsBuilder[0].ToString() != "" && !(numsBuilder.ToString().Contains(",")))
            {
                numsBuilder.Append(",");
                state = numsBuilder.ToString();
                return numsBuilder.ToString();
            }
            return numsBuilder.ToString();

        }
        public static double СalculationRun(string action)
        {
            switch (action)
            {
                case "*":
                    result = numMath1 * numMath2;
                    break;
                case "/":
                    if (numMath2 != 0)
                    {
                        result = numMath1 / numMath2;
                    }

                    break;
                case "-":
                    result = numMath1 - numMath2;

                    break;
                case "+":
                    result = numMath1 + numMath2;
                    break;
                case "=":
                    return result;
                    break;
            }

            return result;
        }
    }
}
