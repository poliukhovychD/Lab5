using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Lab5
{
    internal class Program
    {
        static float FormulaBernoulli(int m, int n, float prob)
        {
            float result = FindC(m, n) * (float)Math.Pow(prob, m) * (float)Math.Pow((1 - prob), n - m);
            return result;
        }
        static float Task2(int asked, int all, float prob)
        {
            float first_case = FormulaBernoulli(all - asked, all, prob);
            float second_case = FormulaBernoulli(all - asked + 1, all, prob);
            float third_case = FormulaBernoulli(all - asked + 2, all, prob);

            return 1 - (first_case + second_case + third_case);
        }

        static float MuavraLaplasa(float p, float n, float m)
        {
            float q = 1 - p;
            float Prob = (1 / (float)(Math.Sqrt(n * p * q))) * DeltaX(m,n,q,p);
            return Prob;
        }

        static float IntegrationFunction(float p, float n, float m1, float m2)
        {
            float q = 1 - p;
            float x1 = DeltaX(m1, n, q, p);
            float x2 = DeltaX(m2, n, q, p);
            return x2 - (-x1);
        }  

        static float DeltaX(float m, float n, float q, float p)
        {
            float x;

            float np =  n * p;
            x = (m - np) / (float)Math.Sqrt(n * p * q);

            return LaplasTable(x);
        }


        private static long Fact(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * Fact(n - 1);
        }

        static float FindC(int m, int n)
        {
            float C;
            C = Fact(n) / (Fact(m) * Fact(n - m));
            return C;
        }

        static float LaplasTable(float x)
        {
            switch (x)
            {
                case 0:
                    return 0.3989f;
                case 0.8068716f:
                    return 0.2897f;
                case 1:
                    return 0.3413f;
                case 2.1234448f:
                    return 0.0508f;
                case 4.42741f:
                    return 0.499997f;
                case 18:
                    return 0;
                case -12.9099455f:
                    return 0.4984f;
                case -1.581218f:
                    return 0.1145f;
                case -1:
                    return 0.3413f;
                default:
                    break;
            }
            return 0;
        }

        static int Task6_10(float p,float n)
        {
            float q = 1 - p;
            float m1 = (n * p) - q;
            float m2 = (n * p) + p;
            float b = (m2 - m1) / 2;
            return (int)Math.Round((m1 + b));
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            float prob1 = FormulaBernoulli(3, 5, 0.2f);
            Console.WriteLine("Probability for task #1 is: " + prob1 + " or " + prob1 * 100 + "%");

            float prob2 = FormulaBernoulli(4, 5, 0.8f);
            Console.WriteLine("\nProbability for task #2(rivno 4 razi) is: " + prob2 + " or " + prob2 * 100 + "%");
            float prob2_2 = Task2(4,5,0.8f);
            Console.WriteLine("Probability for task #2(not less than 4 razi) ≈ " + prob2_2 + " or " + prob2_2 * 100 + "%");
            
            float prob3 = MuavraLaplasa(0.2f, 400, 80);
            Console.WriteLine("\nProbability for task #3 is: " + prob3 + " or " + prob3 * 100 + "%");

            float prob4 = MuavraLaplasa(0.0001f, 100000, 5);
            Console.WriteLine("\nProbability for task #4 is ≈ " + prob4 + " or " + prob4 * 100 + "%");

            float prob5 = IntegrationFunction(0.4f, 600, 228, 252);
            Console.WriteLine("\nProbability for task #5 is ≈ " + prob5 + " or " + prob5 * 100 + "%");

            float prob6 = Task6_10(0.4f, 100);
            Console.WriteLine("\nProbability number for task #6 is: " + prob6);

            float prob7 = IntegrationFunction(0.04f, 4000, 0, 170);
            Console.WriteLine("\nProbability for task #7 is: " + prob7 + " or " + prob7 * 100 + "%");

            float prob8 = MuavraLaplasa(0.5f, 10000, 5000);
            Console.WriteLine("\nProbability for task #8 is: " + prob8 + " or " + prob8* 100 + "%");

            float prob9 = MuavraLaplasa(0.002f, 1000, 5);
            Console.WriteLine("\nProbability for task #9 is ≈ " + prob9 + " or " + prob9 * 100 + "%");

            float prob10 = Task6_10(0.03f, 150);
            Console.WriteLine("\nProbability number for task #10 is: " + prob10);

            Console.ReadLine();
        }
    }
}
