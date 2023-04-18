using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            int len = 8;
            CreateMaze createMaze=new CreateMaze(len);
            createMaze.Create();
            createMaze.Disp();
            createMaze.Find();
            createMaze.DispFind();
            createMaze.Disp();
        }
        
    }

    public class CreateMaze
    {
        public int length;//定义迷宫长度
        public char[,] maze;//创造迷宫结点
        public int[,] found;
        public int final;
        Random rand=new Random();//随机数
        public CreateMaze(int len)
        {
            length = len;
            maze = new char[length,length];
            found = new int[length, length];
        }//迷宫类的初始化
        Queue<MazePoint> Mazelist = new Queue<MazePoint>();
        Queue<MazePoint> Mazelisted = new Queue<MazePoint>();
        Stack<MazePoint> Mazelisted1 = new Stack<MazePoint>();
        public void Create()//创造迷宫
        {
            Console.WriteLine(length);
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    if ((x == 0 && y == 0)||(x==length-1&&y==length-1))//避免首尾出现障碍
                        continue;
                    if (rand.Next(-10, 20) < 0)
                    {
                        maze[y, x] = '*';
                    }
                }
                
            }
        }
        public void Disp()//输出迷宫
        {
            for(int i=-2; i < length; i++)
                Console.Write("* ");//输出第一行边界
            Console.WriteLine();
            for(int i = 0; i < length; i++)
            {
                Console.Write("* ");
                for(int j = 0; j < length; j++)
                {
                    Console.Write(maze[i, j]+" ");
                }
                Console.Write("*\n");
                
            }
            for (int i = -2; i < length ; i++)
                Console.Write("* ");//输出最后一行边界
            Console.WriteLine();
        }
        public void Find()//查找
        {
            MazePoint point = new MazePoint();
            point.Start();
            found[point.y, point.x] = 1;
            /*Queue<MazePoint> Mazelist = new Queue<MazePoint>();
            Queue<MazePoint> Mazelisted = new Queue<MazePoint>();*/
            int num=1;
            Mazelist.Enqueue(point);
            while (true)
            {
                
                if(Mazelist.Count > 0&&num!=0)
                {
                    point = Mazelist.Dequeue();
                    if(point.x == length - 1 && point.y == length - 1)
                    {
                        final = point.num;
                        Mazelisted1.Push(point);
                        Console.WriteLine("!");
                        break;
                    }
                }
                    
                
                MazePoint nextPoint = new MazePoint();

                nextPoint.x = point.x + 1;
                nextPoint.y = point.y;
                if ((nextPoint.y >= 0 && nextPoint.y <= length - 1) && (nextPoint.x >= 0 && nextPoint.x <= length - 1) && maze[nextPoint.y, nextPoint.x] == '\0' && found[nextPoint.y, nextPoint.x]!=1)
                {
                    nextPoint.pre = point.num;
                    nextPoint.num = num++;
                    Mazelist.Enqueue(nextPoint);
                    found[nextPoint.y, nextPoint.x] = 1;
                }
                nextPoint = new MazePoint();
                nextPoint.x = point.x - 1;
                nextPoint.y = point.y;
                if ((nextPoint.y >= 0 && nextPoint.y <= length - 1) && (nextPoint.x >= 0 && nextPoint.x <= length - 1) && maze[nextPoint.y, nextPoint.x] == '\0' && found[nextPoint.y, nextPoint.x] != 1)
                {
                    nextPoint.pre = point.num;
                    nextPoint.num = num++;
                    Mazelist.Enqueue(nextPoint);
                    found[nextPoint.y, nextPoint.x] = 1;
                }
                nextPoint = new MazePoint();
                nextPoint.x = point.x;
                nextPoint.y = point.y + 1;
                if ((nextPoint.y >= 0 && nextPoint.y <= length - 1) && (nextPoint.x >= 0 && nextPoint.x <= length - 1) && maze[nextPoint.y, nextPoint.x] == '\0' && found[nextPoint.y, nextPoint.x] != 1)
                {
                    nextPoint.pre = point.num;
                    nextPoint.num = num++;
                    Mazelist.Enqueue(nextPoint);
                    found[nextPoint.y, nextPoint.x] = 1;
                }
                nextPoint = new MazePoint();
                nextPoint.x = point.x;
                nextPoint.y = point.y - 1;
                if ((nextPoint.y >= 0 && nextPoint.y <= length - 1) && (nextPoint.x >= 0 && nextPoint.x <= length - 1) && maze[nextPoint.y, nextPoint.x] == '\0' && found[nextPoint.y, nextPoint.x] != 1)
                {
                    nextPoint.pre = point.num;
                    nextPoint.num = num++;
                    Mazelist.Enqueue(nextPoint);
                    found[nextPoint.y, nextPoint.x] = 1;
                }
                //Mazelisted.Enqueue(Mazelist.Dequeue());
                Mazelisted1.Push(point);
                if (Mazelist.Count == 0)
                {
                    break;
                }
                //Console.WriteLine("YES");
            }
            Console.WriteLine("END");


        }
        public void DispFind()
        {
            int numed= final;
            while (Mazelisted1.Count!=0)
            {
                MazePoint point = Mazelisted1.Pop();
                if (point.num == final)
                {
                    Console.Write($"[{point.y},{point.x}]");
                    maze[point.y, point.x] = '^';
                    final= point.pre;
                }

            }
            Console.WriteLine("\n");
        }
    }
    public class MazePoint
    {
        public int x;
        public int y;
        public int num;
        public int pre;
        public void Start()
        {
            num = 0;
            pre = 0;
            x = 0;
            y = 0;
        }
    }
}
