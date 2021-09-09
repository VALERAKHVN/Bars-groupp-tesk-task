using System;
using System.Collections.Generic;
using System.Linq;

//Реализовать класс 
//Отрезок(Начальная точка, конечная точка, длина отрезка (квадратный корень из ((x2-x1)^2+(y2-y1)^2))). 
//Создать список отрезков и отсортировать по возрастанию длины.
//Реализовать фильтрацию списка по длине отрезка.
namespace Segment
{
	class Program
	{
		static List<(int, int, int, int, int)> SegmList = new List<(int, int, int, int, int)>(); //список отрезков(х1,у1,х2,у2,длинна)
		static void Main(string[] args)
		{
			
			SampleTest();
		}
		public static void SampleTest()
		{
			Random r = new Random();
			Segment s = new Segment();
			int iterations = r.Next(10,30);
			for(int i=0;i<iterations; i++)
			{
				
				Point p1 = new Point(r.Next(-50, 50), r.Next(-50, 50)); //начальная точка
				Point p2 = new Point(r.Next(-50, 50), r.Next(-50, 50)); // конечная точка
				int l = s.SegmentLength(p1, p2); //вычисление длинны
				SegmList.Add((p1.x, p1.y, p2.x, p2.y, l));
			}
			SegmList = s.SortAsc(SegmList);
			foreach(var i in SegmList)
			{ Console.WriteLine($"({i.Item1};{i.Item2}), ({i.Item3};{i.Item4}) : Length = {i.Item5}"); }
			Console.Write("\n");
			SegmList = s.SortDesc(SegmList);
			foreach (var i in SegmList)
			{ Console.WriteLine($"({i.Item1};{i.Item2}), ({i.Item3};{i.Item4}) : Length = {i.Item5}"); }
			Console.ReadKey();
		}
	}
	class Point
	{
		public int x, y;
		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
	class Segment //класс отрезок
	{
		Point Startpoint, EndPoint;
		public Point start
		{
			get => Startpoint;
			set => Startpoint = value;
		}
		public Point end
		{
			get => EndPoint;
			set => EndPoint = value;
		}
		public int SegmentLength(Point start, Point end)
		{
			int length = (int)Math.Sqrt((int)Math.Pow((start.x - end.x), 2) + (int)Math.Pow((start.y - end.y), 2));
			return length;
		}
		public List<(int,int,int,int,int)> SortDesc(List<(int,int,int,int,int)> list) //сортировка по убыванию
		{
			list = list.OrderByDescending(i => i.Item5).ToList();
			return list;
		}
		public List<(int, int, int, int, int)> SortAsc(List<(int, int, int, int, int)> list) //сортировку по возрастанию
		{
			list = list.OrderBy(i => i.Item5).ToList();
			return list;
		}
	}
}
