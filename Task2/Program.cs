using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        private static int num1,num2,num3;

        static void Main(string[] args)
        {
            string money;
            while (true)
            {
                Console.WriteLine("Enter your money sum and I convert it to words :", ConsoleColor.Yellow);
                money = Console.ReadLine();
                money = Convert(money);
                Console.WriteLine($"You have : {money}", ConsoleColor.Green);
            }
        }

        //Main method which controll all convertation functions
        private static string Convert(string money)
        {
            int temp =0;
            string result = "";

            string[] moneyArray = money.Replace('.', ',').Split(',');

            if (moneyArray[0] == "0")
            {
                return "Zero dollars";
            }

            try
            {
                for (int i = 0; i < moneyArray[0].Length / 3 + 1; i++)
                {
                    temp = (int)(int.Parse(moneyArray[0]) % (Math.Pow((double)1000, (double)i + 1)) / Math.Pow((double)1000, (double)i));
                    result = DollarsToWords(temp, i) + result;
                }

                if (result != "one")
                {
                    result += " dollars ";
                }
                else
                {
                    result += " dollar ";
                }

                if (moneyArray.Length == 2)
                {
                    result += CentsToText(moneyArray[1]);
                }

                return result;
            }
            catch (Exception)
            {
                return "Ups !! Something wrong!";
            }
        }

        //Convertation after point number part
        private static string CentsToText(string cents)
        {

            if (cents == "") return "";

            string result = "";



            num1 = int.Parse(cents) % 100 / 10;
            num2 = int.Parse(cents) % 10;

            if (num1 != 0)
            {
                if (num1 != 1)
                {
                    result += $"{ConvertToTextDec(num1)}-";
                }
                else
                {
                    result += $" {ConvertToTextDec(num1 * 10 + num2)}";
                    result += " cents";
                    return result;
                }
            }
            if (num2 != 0)
            {
                result += $"{ConvertToText(num2)}";
                result += " cents";
            }

            return result;
        }
       
        //If we have number above 10
        private static string ConvertToText(int number)
        {
            switch (number)
            {
                case 1: { return "one"; }
                case 2: { return "two"; }
                case 3: { return "three"; }
                case 4: { return "four"; }
                case 5: { return "five"; }
                case 6: { return "six"; }
                case 7: { return "seven"; }
                case 8: { return "eight"; }
                case 9: { return "nine"; }
                
                default:
                    return null;
            }
        }

        //If we have 10+ number
        private static string ConvertToTextDec(int number)
        {
            switch (number)
            {
                case 10: { return "ten"; }
                case 11: { return "eleven"; }
                case 12: { return "twelve"; }
                case 13: { return "thirteen"; }
                case 14: { return "fourteen"; }
                case 15: { return "fifteen"; }
                case 16: { return "sixteen"; }
                case 17: { return "seventeen"; }
                case 18: { return "eighteen"; }
                case 19: { return "nineteen"; }
                case 2: { return "twenty"; }
                case 3: { return "thirty"; }
                case 4: { return "forty"; }
                case 5: { return "fifty"; }
                case 6: { return "sixty"; }
                case 7: { return "seventy"; }
                case 8: { return "eighty"; }
                case 9: { return "ninety"; }
                default:
                    return null;
            }
        }

        //Convertation before point number part
        private static string DollarsToWords(int money, int rosters)
        {
            string result = "";
            num1 = money % 1000 / 100;
            num2 = money % 100 / 10;
            num3 = money % 10;

            if (num1 != 0)
            {
                result+=$" {ConvertToText(num1)} hundred";
            }
            if (num2 != 0)
            {
                if (num2 != 1)
                {
                    result+=$" {ConvertToTextDec(num2)}-";
                }
                else
                {
                    result+=$" {ConvertToTextDec(num2 * 10 + num3)}";
                    return result;
                }
            }
            if (num3 != 0)
            {
                if (rosters != 0)
                {
                    result += $"{ConvertToText(num3)} {(Rosters)rosters}";
                }
                else
                {
                    result += $"{ConvertToText(num3)}";
                }
            }
            return result;
        }

        
        public enum Rosters
        {
            thousand = 1,
            million = 2,
            billion = 3,

        }
    }
}
