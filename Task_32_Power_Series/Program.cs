using System;

namespace Task_32_Power_Series
{
	class Main_32
	{
		static double eps;

		public static void Main(string[] args)
		{
			eps = 1.0E-20;
			double a = 2.0, b = 4.0, x = 2.0, x2 = 5.0;
            //double a = 4.0, b = 2.0, x = 1.0, x2 = 6.0;
            double func = (Math.Cos(a * x) /
									 (Math.Sqrt(Math.PI) - Math.Sin(b * x) / b / Math.Sqrt(2.0)));
			Console.WriteLine(F(5));
			Console.WriteLine(Func(a, b, x));
			Console.WriteLine(Func(a, b, x2));
			Console.ReadLine();
		}

		static double Func(double a, double b, double x)
		{
            double func = Math.Cos(a * x) / 
			                         Math.Sqrt(Math.PI) - Math.Sin(b * x) / b / Math.Sqrt(2.0);
            double pk =   Math.Cos(a * x) /
									 Math.Sqrt(Math.PI) - Math.Sin(b * x) / b / Math.Sqrt(2.0);
			for (int k = 1; Math.Abs(pk) > eps; k++)
			{
				pk = (Math.Pow(-1.0, (double)k) * Math.Pow(x, 2.0 * k) /
				      (double)F(k) / (2.0 * k + 1.0)) * (Math.Cos(a * x) /
				                                                 (k * x * x + Math.Sqrt(Math.PI)) -
				                                                 (Math.Sin(b * x) / Math.Sqrt(2.0) /
				                                                  (k * x + b)));
				func += pk;
			}
			return func;
		}

		static double F(int n)
		{
			double k = 1.0;
			for (int i = 1; i <= n; i++)
				k *= i;
			return k;
		}
	}
}
