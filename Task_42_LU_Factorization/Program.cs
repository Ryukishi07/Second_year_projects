using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CLM = Task_41_Matrix_Algebra.Class_Matrix;

namespace Problem_42
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			/*double[,] A, U, L; int n; double det_A;
			StreamWriter sw = new StreamWriter("result.txt");
			CLM.Read_Matrix_A("Test_41_A.txt", out A, out n);
			CLM.LU_Factorization(A, out L, out U, out det_A);
			sw.WriteLine(CLM.Print_A(L, true, 1, 2, "Матрица L"));
			sw.WriteLine(CLM.Print_A(U, true, 1, 2, "Матрица U"));
			sw.WriteLine(CLM.Print_A(A, true, 1, 2, "Матрица А"));
			CLM.Matrix_mult(L, U, out A);
			sw.WriteLine(CLM.Print_A(A, true, 1, 2, "Матрица L*U"));
			sw.WriteLine("  Determinant_JO(A) = {0:F3}", CLM.Determinant_JO_JO(A));
			sw.Close();*/
			double r, R, Woa, e, AC;
			double B = 4*Math.PI / 9, C = 7*Math.PI / 36;
			Console.Write("r = ");
			r = Convert.ToDouble(Console.ReadLine());
			Console.Write("R = ");
			R = Convert.ToDouble(Console.ReadLine());
			Console.Write("w = ");
			Woa = Convert.ToDouble(Console.ReadLine());
			Console.Write("AC = ");
			AC = Convert.ToDouble(Console.ReadLine());
			Console.Write("e = ");
			e = Convert.ToDouble(Console.ReadLine());
			double w = (R + r) * Woa / R;
			double Vb = R * Math.Sqrt(2 * (1 + Math.Cos(B))) * w;
			double Vc = Math.Sqrt(R * R + AC * AC - 2 * R * AC * Math.Cos(C)) * w;
			double Wa = Math.Sqrt(e * e * (R + r) * (R + r) + (R + r) * (R + r) * Math.Pow(Woa, 4));
			double E = e * (R + r) / R;
			double wx = e * (R + r) * Math.Cos(B) - (R + r) * Woa * Woa * Math.Sin(B) + R * E;
			double wy = e * (R + r) * Math.Sin(B) + (R + r) * Woa * Woa * Math.Cos(B) + R * Woa * Woa * (R + r) * (R + r) / R / R;
			double Wb = Math.Sqrt(wx * wx + wy * wy);
			double wxx = (R + r) * Woa * Woa * Math.Sin(C) - e * (R + r) * Math.Cos(C) + E * AC;
			double wyy = AC * Woa * Woa * (R + r) * (R + r) / R / R - (R + r) * Woa * Woa * Math.Cos(C) - e * (R + r) * Math.Sin(C);
			double Wc = Math.Sqrt(wxx * wxx + wyy * wyy);
			Console.WriteLine(w);
			Console.WriteLine(Vb);
			Console.WriteLine(Vc);
			Console.WriteLine(Wa);
			Console.WriteLine(E);
			Console.WriteLine(Wb);
			Console.WriteLine(Wc);
			Console.ReadLine();
		}
	}
}
