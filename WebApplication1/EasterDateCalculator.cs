using System;

namespace WebApplication1
{
    public class EasterDateCalculator
    {
        public EasterDateCalculator()
        { }

        public DateTime TranslateToNewStyle(DateTime oldDate)
        {
            return oldDate.AddDays(13);
        }

        public DateTime CalculateEasterDate(int year)
        {
            DateTime easterDate = new DateTime(year, 3, 1);
            
            int a = (19 * (year % 19) + 15) % 30;
            int b = (2 * (year % 4) + 4 * (year %  7) + 6 * a + 6) % 7;

            if (a + b > 9)
            {
                easterDate = easterDate.AddDays(a + b - 10);
                easterDate = easterDate.AddMonths(1);
            }
            else
            {
                easterDate = easterDate.AddDays(22 + a + b);
            }

            return TranslateToNewStyle(easterDate);
        }
    }
}
