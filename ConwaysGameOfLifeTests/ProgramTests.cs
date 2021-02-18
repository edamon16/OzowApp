using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife.Tests
{
    [TestClass()]
    public class ProgramTests : Facade
    {
        public Facade Facade { get; private set; }
        public static int Rows { get; set; }

        public static int Columns { get; set; }



        static readonly Random random = new Random();
        [TestMethod()]
        public void MainTest()
        {
            Process.Start("ConwaysGameOfLife.exe");
            Console.WriteLine("10");
            Console.WriteLine("25");
            Console.WriteLine("3");



        }


        [TestMethod]
        public void CreateGridTest()
        {
            var result = InitalizeGrid();

            Program.Rows = 10;
            Program.Columns = 25;
            var resultGrid = CreateGrid(result);

            Assert.IsTrue(resultGrid);
        
        }

        private Status[,] InitalizeGrid()
        {

            Process.Start("ConwaysGameOfLife.exe");

            Rows = 10;
            Columns = 25;
            var grid = new Status[Rows, Columns];
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    grid[row, column] = (Status)random.Next(0, 2);
                }
            }

            return grid;
        }
    }
}