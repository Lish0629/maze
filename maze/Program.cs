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
        public int length;
        public char[,] maze;
        Random rand=new Random();
        public CreateMaze(int len)
        {
            length = len;
            maze = new char[length,length];
        }
        public void Create()
        {
            Console.WriteLine(length);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if ((i == 0 && j == 0)||(i==length-1&&j==length-1))
                        continue;
                    if (rand.Next(-1, 3) < 0)
                    {
                        maze[i, j] = '*';
                    }
                }
                
            }
        }
        public void Disp()
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
    }
}
