using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class Facade
    {
        public static Status[,] NextGeneration(Status[,] currentGrid)
        {
            var nextGeneration = new Status[Program.Rows, Program.Columns];

            // Loop through every cell 
            for (var row = 1; row < Program.Rows - 1; row++)
            {
                for (var column = 1; column < Program.Columns - 1; column++)
                {
                    // find  alive neighbors
                    var aliveNeighbors = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            aliveNeighbors += currentGrid[row + i, column + j] == Status.Alive ? 1 : 0;
                        }
                    }

                    GameRules(currentGrid, row, column, aliveNeighbors, nextGeneration);
                }
            }

            return nextGeneration;
        }

        public static void GameRules(Status[,] currentGrid, int row, int column, int aliveNeighbors, Status[,] nextGeneration)
        {
            var currentCell = currentGrid[row, column];

            // The cell needs to be subtracted 
            // from its neighbors as it was counted before 
            aliveNeighbors -= currentCell == Status.Alive ? 1 : 0;

            // Implementing the Rules of Life 

            // Cell is lonely and dies 
            if (currentCell == Status.Alive && aliveNeighbors < 2)
            {
                nextGeneration[row, column] = Status.Dead;
            }

            // Cell dies due to over population 
            else if (currentCell == Status.Alive && aliveNeighbors > 3)
            {
                nextGeneration[row, column] = Status.Dead;
            }

            // A new cell is born 
            else if (currentCell == Status.Dead && aliveNeighbors == 3)
            {
                nextGeneration[row, column] = Status.Alive;
            }
            // stays the same
            else
            {
                nextGeneration[row, column] = currentCell;
            }
        }

        public static bool CreateGrid(Status[,] future, int timeout = 500)
        {
            var stringBuilder = new StringBuilder();
            for (var row = 0; row < Program.Rows; row++)
            {
                for (var column = 0; column < Program.Columns; column++)
                {
                    var cell = future[row, column];
                    stringBuilder.Append(cell == Status.Alive ? "A" : "D");
                }
                stringBuilder.Append("\n");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(stringBuilder.ToString());
            Thread.Sleep(timeout);

            return true;
            
        }
    }

    public class Program
    {
        public static int Rows;

        public static int Columns;
        private static int NumberOfGeneration;

        static bool runSimulation = true;
        static readonly Random random = new Random();

        public static void Main(params string[] args)
        {

            Console.WriteLine("please enter height than press enter");
            Rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter width than press enter");
            Columns = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter the number of generations to create than press enter");
            NumberOfGeneration = Convert.ToInt32(Console.ReadLine());
            var grid = new Status[Rows, Columns];

            // randomly initialize our grid
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    grid[row, column] = (Status)random.Next(0, 2);
                }
            }


            Console.Clear();

            // Displaying the grid 
            //Set generation
            int i = 0;
            while (i < NumberOfGeneration)
            {
                Facade.CreateGrid(grid);
                grid = Facade.NextGeneration(grid);
                i++;
            }


        }

        //Create random grid with A and D
    }

    public enum Status
    {
        Dead,
        Alive,
    }

}
