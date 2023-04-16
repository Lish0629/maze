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
            int len = 32;
            CreateMaze createMaze=new CreateMaze(len);
            createMaze.Create();
            createMaze.Disp();
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
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if ((i == 0 && j == 0)||(i==length-1&&j==length-1))//避免首尾出现障碍
                        continue;
                    if (rand.Next(-10, 25) < 0)
                    {
                        maze[i, j] = '*';
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
        public void Find()
        {

        }
        public void DispFind() { }//输出
    }
    public class MazeList
    {
        public int front, rear;
        public int MaxSize=100;
        public string[] data;
        public MazeList()
        {
            front = 0;
            rear = 0;
            data=new string[MaxSize];
        }
        public bool Push(string e)
        {
            if (rear == MaxSize - 1)
                return false;
            rear++;
            data[rear]=

        }
    }
}
