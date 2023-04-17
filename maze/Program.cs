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
        }
        
    }

    public class CreateMaze
    {
        public int length;//定义迷宫长度
        public char[,] maze;//创造迷宫结点
        Random rand=new Random();//随机数
        public CreateMaze(int len)
        {
            length = len;
            maze = new char[length,length];
        }//迷宫类的初始化
        
        public void Create()//创造迷宫
        {
            Console.WriteLine(length);
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    if ((x == 0 && y == 0)||(x==length-1&&y==length-1))//避免首尾出现障碍
                        continue;
                    if (rand.Next(-10, 25) < 0)
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
            char direction='d';
            bool t = true;
            while (t)
            {
                MazePoint nextPoint = new MazePoint();
                //direction=Convert.ToChar(Console.Read());
                //if (point.x == length - 1 && point.y == length - 1)
                    //return true;
                switch (direction)
                {
                    case 'd':
                        nextPoint.x = point.x+1;
                        nextPoint.y = point.y;
                        if (maze[nextPoint.y,nextPoint.x]==0)
                        {
                            Console.Write("YES");
                            Console.WriteLine($"[{nextPoint.x},{nextPoint.y}]\t");
                            Console.Read();
                            point.x=nextPoint.x ;
                            point.y=nextPoint.y ;
                        }
                        else
                        {
                            Console.Write("NO");
                            Console.WriteLine($"[{nextPoint.x},{nextPoint.y}]\t");
                            direction = 's';
                            Console.Read ();
                            
                        }
                        break;
                    case 'a':
                        nextPoint.x = point.x -1;
                        nextPoint.y = point.y;
                        if (maze[nextPoint.y, nextPoint.x] == 0)
                        {
                            Console.Write("YES");
                            Console.WriteLine($"[{nextPoint.x},{nextPoint.y}]\t");
                            Console.Read();
                            point.x = nextPoint.x;
                            point.y = nextPoint.y;
                        }
                        else
                        {
                            Console.Write("NO");
                            Console.WriteLine($"[{nextPoint.x},{nextPoint.y}]\t");
                            direction = 'w';
                            Console.Read();
                        }
                        break;
                    case 'w':
                        nextPoint.x = point.x ;
                        nextPoint.y = point.y-1;
                        if (maze[nextPoint.y, nextPoint.x] == 0)
                        {
                            Console.Write("YES");
                            Console.WriteLine($"[{nextPoint.x},{nextPoint.y}]\t");
                            Console.Read();
                            point.x = nextPoint.x;
                            point.y = nextPoint.y;
                        }
                        else
                        {
                            Console.Write("NO");
                            Console.WriteLine($"[{nextPoint.x},{nextPoint.y}]\t");
                            direction = 'd';
                            Console.Read();
                        }
                        break;
                    case 's':
                        nextPoint.x = point.x ;
                        nextPoint.y = point.y+1;
                        if (maze[nextPoint.y, nextPoint.x] == 0)
                        {
                            Console.Write("YES");
                            Console.WriteLine($"[{nextPoint.x},{nextPoint.y}]\t");
                            Console.Read();
                            point.x = nextPoint.x;
                            point.y = nextPoint.y;
                        }
                        else
                        {
                            Console.Write("NO");
                            Console.WriteLine($"[{nextPoint.x},{nextPoint.y}]\t");
                            direction = 'a';
                            Console.Read();
                        }
                        break;
                    default:
                        t = false; 
                        break;
                        //return t;

                }
            }
        }
        public void DispFind() { }//输出
    }
    public class MazePoint
    {
        public int x;
        public int y;
        public int num;
        public void Start()
        {
            num = 0;
            x = 0;
            y = 0;
        }
    }
    public class MazeList
    {
        public int front, rear;
        public int MaxSize=100;
        public MazePoint[] data;
        public MazeList()
        {
            front = -1;
            rear = -1;
            data=new MazePoint[MaxSize];
        }
        public bool Push(MazePoint mazepoint)
        {
            if (rear == MaxSize - 1)
                return false;
            rear++;
            data[rear] = mazepoint;
            return true;
        }
        public bool Pop(ref MazePoint mazePoint)
        {
            if(front == MaxSize - 1) return false;
            front++;
            mazePoint = data[front];
            return true;
        }
    }
}
