using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class CoreLogicTests
    {
        [TestMethod]
        public void ADead_ECellWith_F_H_ICellsAliveBecomesAlive()
        {
            /*
             ........
             ...E*...
             ...**...
             ........
             */
            var gameOfLife = new GameOfLifeCoreLogic();
            gameOfLife.InitializeBoard(4, 8);
            gameOfLife.SetLivingCells(new List<Point>
                    {
                        new Point(1, 4),
                        new Point(2, 3), new Point(2, 4)
                    });

            gameOfLife.NextGeneration();

            bool eCellIsAlive = gameOfLife.IsAlive(1, 3);

            Assert.IsTrue(eCellIsAlive);
        }

        [TestMethod]
        public void ALiving_BCellWithOnly_DCellAliveDies()
        {
            /*
             .....B..
             ...**...
             ...**...
             ........
             */
            var gameOfLife = new GameOfLifeCoreLogic();
            gameOfLife.InitializeBoard(4, 8);
            gameOfLife.SetLivingCells(new List<Point>
                    {
                        new Point(0, 5),
                        new Point(1, 3), new Point(1, 4),
                        new Point(2, 3), new Point(2, 4)
                    });

            gameOfLife.NextGeneration();

            bool eCellIsDead = gameOfLife.IsDead(0, 5);

            Assert.IsTrue(eCellIsDead);
        }

        [TestMethod]
        public void ALiving_ECellWith_C_D_G_HCellsAliveDies()
        {
            /*
             .....*..
             ...*E...
             ...**...
             ........
             */
            var gameOfLife = new GameOfLifeCoreLogic();
            gameOfLife.InitializeBoard(4, 8);
            gameOfLife.SetLivingCells(new List<Point>
                    {
                        new Point(0, 5),
                        new Point(1, 3), new Point(1, 4),
                        new Point(2, 3), new Point(2, 4)
                    });

            gameOfLife.NextGeneration();

            bool eCellIsDead = gameOfLife.IsDead(1, 4);

            Assert.IsTrue(eCellIsDead);
        }

        [TestMethod]
        public void ALiving_ECellWith_D_G_H_HCellsAliveStaysAlive()
        {
            /*
             ........
             ...*E...
             ...**...
             ........
             */
            var gameOfLife = new GameOfLifeCoreLogic();
            gameOfLife.InitializeBoard(4, 8);
            gameOfLife.SetLivingCells(new List<Point>
                    {
                        new Point(1, 3), new Point(1, 4),
                        new Point(2, 3), new Point(2, 4)
                    });

            gameOfLife.NextGeneration();

            bool eCellIsDead = gameOfLife.IsAlive(1, 4);

            Assert.IsTrue(eCellIsDead);
        }


        [TestMethod]
        public void SetRowsWithOnlyFirstCellAliveReturnsCorrectPattern()
        {
            /*
             *.......
             ........
             ........
             ........
             */
            var gameOfLife = new GameOfLifeCoreLogic();
            gameOfLife.InitializeBoard(4, 8);
            gameOfLife.SetRows(new List<string>() { "*" });

            bool firstCellIsAlive = gameOfLife.IsAlive(0,0);

            Assert.IsTrue(firstCellIsAlive);
        }
    }
}
