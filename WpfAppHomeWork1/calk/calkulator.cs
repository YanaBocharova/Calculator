using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calk
{
    public class calkulator
    {
      public StringBuilder numsBuilder = new StringBuilder();
      public StringBuilder mathBuider = new StringBuilder();
      public StringBuilder mathBuiderSymb = new StringBuilder();
      public string[] number = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
      public string[] mathOperation = new string[] { "*", "-", "+", "/", "=" };
      public double numMath1;
      public double numMath2;
      public double result;
      public string action;
      public int count = 0;
      public int countAction = 0;
      public string state = string.Empty;
      public string btnSymbPoit = ".";

        public string BtnNumber_Click(string btnSymb)
        {

            if (number.Contains(btnSymb))
            {
                var n = number.FirstOrDefault(num => num == btnSymb);
                numsBuilder.Append(n);
                state = numsBuilder.ToString();
                numMath2 = double.Parse(numsBuilder.ToString());

               return numsBuilder.ToString();
            }
            return "";
        }
        public (string ,string) BtnClick_Operation(string btnSymb , string textCalk ,string viewOperation)
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
        public string BtnClick_Point(string point)
        {
            if (btnSymbPoit == point && numsBuilder[0].ToString() != "" && !(numsBuilder.ToString().Contains(",")))
            {
                numsBuilder.Append(",");
                state = numsBuilder.ToString();
                return numsBuilder.ToString();
            }
            return numsBuilder.ToString();

        }
        public double СalculationRun(string action)
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
