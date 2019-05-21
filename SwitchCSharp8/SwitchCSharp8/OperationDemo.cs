using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchCSharp8
{
    class OperationDemo
    {
        public void Run()
        {
            var expression = new Expression()
            {
                Arg1 = 10,
                Arg2 = 5,
                Operator = "/"
            };

            CSharp1(expression);
            CSharp7(expression);
            CSharp8(expression);
            CSharp8Property(expression);
        }

        void CSharp1(Expression ex)
        {
            int result = 0;

            switch (ex.Operator)
            {
                case "+":
                    result = ex.Arg1 + ex.Arg2;
                    break;
                case "/":
                    if (ex.Arg2 == 0)
                    {
                        throw new ArgumentException("Arg2 cannot be 0");
                    }
                    result = ex.Arg1 / ex.Arg2;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            Console.WriteLine($"{ex} = {result}");
        }

        void CSharp7(object o)
        {
            int result = 0;

            switch (o)
            {
                case Expression ex when ex.Operator == "+":
                    result = ex.Arg1 + ex.Arg2;
                    break;
                case Expression ex when ex.Operator == "/" && ex.Arg2 == 0:
                    throw new ArgumentException("Arg2 cannot be 0");
                case Expression ex when ex.Operator == "/":
                    result = ex.Arg1 / ex.Arg2;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            Console.WriteLine($"{o} = {result}");
        }

        void CSharp8(object o)
        {
            int result = o switch
            {
                Expression ex when ex.Operator == "+" => ex.Arg1 + ex.Arg2,
                Expression ex when ex.Operator == "/" && ex.Arg2 == 0 => throw new ArgumentException("Arg2 cannot be 0"),
                Expression ex when ex.Operator == "/" => ex.Arg1 / ex.Arg2,
                _ => throw new InvalidOperationException()
            };

            Console.WriteLine($"{o} = {result}");
        }

        void CSharp8Property(object o)
        {
            int result = o switch
            {
                Expression { Operator: "+" } ex => ex.Arg1 + ex.Arg2,
                Expression { Operator: "/", Arg2: 0 } ex => throw new ArgumentException("Arg2 cannot be 0"),
                Expression { Operator: "/" } ex => ex.Arg1 / ex.Arg2,
                _ => throw new InvalidOperationException()
            };

            Console.WriteLine($"{o} = {result}");
        }

        void CSharp8Property(Expression ex)
        {
            int result = ex switch
            {
                { Operator: "+" } => ex.Arg1 + ex.Arg2,
                { Operator: "/", Arg2: 0 } => throw new ArgumentException("Arg2 cannot be 0"),
                { Operator: "/" } => ex.Arg1 / ex.Arg2,
                _ => throw new InvalidOperationException()
            };

            Console.WriteLine($"{ex} = {result}");
        }
    }

    public class Expression
    {
        public string Operator { get; set; }

        public int Arg1 { get; set; }

        public int Arg2 { get; set; }

        public override string ToString()
        {
            return $"{Arg1} {Operator} {Arg2}";
        }
    }
}
