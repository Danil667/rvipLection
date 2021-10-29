using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rvipLection
{
	public class LogicalClock
	{
		private int max1(int a, int b)
		{
			if (a > b)
				return a;
			else
				return b;
		}

		private void display(int e1, int e2, int[] p1, int[] p2)
		{
			int i;
			Console.WriteLine();
			Console.Write("Временные метки событий в P1:");

			for (i = 0; i < e1; i++)
			{
				Console.Write(p1[i] + " ");
			}

			Console.WriteLine();
			Console.Write("Временные метки событий в P2:");

			for (i = 0; i < e2; i++)
				Console.Write(p2[i] + " ");
		}

		private void lamportLogicalClock(int e1, int e2, int[,] m)
		{
			int i, j, k;
			int[] p1 = new int[e1];
			int[] p2 = new int[e2];

			for (i = 0; i < e1; i++)
				p1[i] = i + 1;

			for (i = 0; i < e2; i++)
				p2[i] = i + 1;

			for (i = 0; i < e2; i++)
				Console.Write(" e2" + (i + 1));

			Console.WriteLine();
			for (i = 0; i < e1; i++)
			{

				Console.Write("e1" + (i + 1) + " ");

				for (j = 0; j < e2; j++)
					Console.Write(" " + m[i, j]);

				Console.WriteLine();
			}

			for (i = 0; i < e1; i++)
			{
				for (j = 0; j < e2; j++)
				{

					if (m[i, j] == 1)
					{
						p2[j] = max1(p2[j], p1[i] + 1);
						for (k = j + 1; k < e2; k++)
							p2[k] = p2[k - 1] + 1;
					}

					if (m[i, j] == -1)
					{
						p1[i] = max1(p1[i], p2[j] + 1);
						for (k = i + 1; k < e1; k++)
							p1[k] = p1[k - 1] + 1;
					}
				}
			}

			display(e1, e2, p1, p2);
		}

		public void start()
		{
			int e1 = 5;
			int e2 = 3;
			int[,] m = new int[e1, e2];

			m[0, 0] = 0;
			m[0, 1] = 0;
			m[0, 2] = 0;
			m[1, 0] = 0;
			m[1, 1] = 0;
			m[1, 2] = 1;//если сообщение отправлено от e1 до e2
			m[2, 0] = 0;
			m[2, 1] = 0;
			m[2, 2] = 0;
			m[3, 0] = 0;
			m[3, 1] = 0;
			m[3, 2] = 0;
			m[4, 0] = 0;
			m[4, 1] = -1;//если получено сообщение по e4 от e1
			m[4, 2] = 0;

			lamportLogicalClock(e1, e2, m);

		}
	}
}
