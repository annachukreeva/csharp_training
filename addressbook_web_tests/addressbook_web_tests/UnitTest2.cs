using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void IfElse()
        {
            double total = 1500;
            if (total>1000)
            {
                total = total * 0.9;
                System.Console.Out.Write("Скидка 10%, общая сумма " + total);
            }
            else
            {
                System.Console.Out.Write("Скидки нет, общая сумма " + total);
            }
        }
    }
}
