using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class BoardFactory
    {
        public enum GameOfLifePatterns
        {
            OscilatorBlinker,
            OscilatorToad,
            OscilatorBeacon,

            SpaceShipGlider,

            CellularAutomationGosperGliderGun
        }

        public static List<String> PatterbBoard(GameOfLifePatterns pattern)
        {
            // https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life
            List<String> resultPattern = null;

            switch (pattern)
            {
                case GameOfLifePatterns.OscilatorBlinker:
                    resultPattern = new List<String>
                    {
                        "",
                        "",
                        ".***."
                    };
                    break;
                case GameOfLifePatterns.OscilatorToad:
                    resultPattern = new List<String>
                    {
                        "",
                        "",
                        "..***.",
                        ".***.."
                    };
                    break;
                case GameOfLifePatterns.OscilatorBeacon:
                    resultPattern = new List<String>
                    {
                        "",
                        ".**...",
                        ".**...",
                        "...**.",
                        "...**."
                    };
                    break;
                case GameOfLifePatterns.SpaceShipGlider:
                    resultPattern = new List<String>
                    {
                        "",
                        "..*.",
                        "...*.",
                        ".***.",
                    };
                    break;
                case GameOfLifePatterns.CellularAutomationGosperGliderGun:
                    // https://en.wikipedia.org/wiki/Gun_(cellular_automaton)#/media/File:Game_of_life_glider_gun.svg
                    resultPattern = new List<String>
                    {
                        "",
                        ".........................*............",
                        ".......................*.*............",
                        ".............**......**............**.",
                        "............*...*....**............**.",
                        ".**........*.....*...**...............",
                        ".**........*...*.**....*.*............",
                        "...........*.....*.......*............",
                        "............*...*.....................",
                        ".............**.......................",
                    };
                    break;
                default:
                    break;
            }
            return resultPattern;
        }
    }
}
