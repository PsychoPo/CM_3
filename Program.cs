using System;

namespace lab3VAR25

{
	class Program
	{
		static double f(double x)
		{
			return 1 - x * Math.Log(x) + 0.3 * Math.Sqrt(x);
		}
		static double f1(double x)
		{
			return -Math.Log(x) - 1 + 0.15 / Math.Sqrt(x);
		}
		static double f2(double x)
		{
			return -1 / x - 0.075 / Math.Pow(x, 3 / 2);
		}
		static void Main(string[] args)
		{
			Console.Clear();
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			int i = 0;
			double a = 1.1, b = 3, xn, eps = 0.01;
			double x0 = (a + b) / 2;

			if (f(a) * f(b) > 0)
			{
				Console.WriteLine("\nКорней нет!\n");
			}
			else
			{
				Console.WriteLine($"\nf(a) = {f(a)};\nf(b) = {f(b)};\nf(a)*f(b) = {f(a) * f(b)} < 0.");
				Console.WriteLine($"\nx = {x0}\nf'(x) = {f1(x0)} != 0;\nf''(x) = {f2(x0)} != 0.\n");
				Console.WriteLine($"\nf(x0) = {f(x0)};\nf''(x0) = {f2(x0)};\nf(x0)*f''(x0) = {f(x0) * f2(x0)} > 0.\n");
				if (f(x0) * f2(x0) > 0)
				{
					x0 = a;
				}
				else
				{
					x0 = b;
				}
			}
			xn = x0 - f(x0) / f1(x0);

			Console.WriteLine($"Итерация №{++i} - xk = {Math.Round(xn, 4)}\n");

			while (Math.Abs(x0 - xn) > eps)
			{
				x0 = xn;
				xn = x0 - f(x0) / f1(x0);
				Console.WriteLine($"Итерация №{++i} - xk = {Math.Round(xn, 4)}\n");

			}

			Console.WriteLine($"Корень = {Math.Round(xn, 4)}");
		}
	}
}
