﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            
            int[,] matrix = new int[matrixSize,matrixSize];
            FillingUpTheMatrix(matrix);
            string[] bombsCoordinates = Console.ReadLine().Split();

            List<Bombs> bombsInfo = new List<Bombs>();

            for (int i = 0; i < bombsCoordinates.Length; i++)
            {
                GetAndMarkBombCoordinates(matrix, bombsCoordinates, bombsInfo, i);
            }

            foreach (var currentBomb in bombsInfo)
            {
                int currentBombRow = currentBomb.BombRow;
                int currentBombCol = currentBomb.BombCol;

                if (matrix[currentBombRow, currentBombCol] > 0)
                {
                    currentBomb.BombPower = matrix[currentBombRow, currentBombCol];
                }
                else
                {
                    continue;
                }

                // Горен над бомбата ред

                CalculateTopOfTheBombCell(matrix, currentBomb);

                // Среден на бомбата ред

                CalculateMiddleOfTheBombCell(matrix, currentBomb);

                // Долен на бомбата ред

                CalculateBottomOfTheBombCell(matrix, currentBomb);

                matrix[currentBombRow, currentBombCol] = 0;
            }

            int liveCellSum = 0;
            int liveCellCounter = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        liveCellSum += matrix[row, col];
                        liveCellCounter++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {liveCellCounter}");
            Console.WriteLine($"Sum: {liveCellSum}");

            //for (int row = 0; row < matrixSize; row++)
            //{
            //    for (int col = 0; col < matrixSize; col++)
            //    {
            //        Console.Write(matrix[row, col] + " ");
            //    }

            //    Console.WriteLine();
            //}
            PrintMatrix(matrix);

        }
        private static void CalculateBottomOfTheBombCell(int[,] matrix, Bombs currentBomb)
        {
            if (currentBomb.BombCol >= 1 && currentBomb.BombRow < matrix.GetLength(0) - 1) // Проверка за долу в ляво
            {
                if (matrix[currentBomb.BombRow + 1, currentBomb.BombCol - 1] > 0)
                {
                    matrix[currentBomb.BombRow + 1, currentBomb.BombCol - 1] -= currentBomb.BombPower;
                }
            }

            if (currentBomb.BombRow < matrix.GetLength(0) - 1) // Проверка за долу в средата
            {
                if (matrix[currentBomb.BombRow + 1, currentBomb.BombCol] > 0)
                {
                    matrix[currentBomb.BombRow + 1, currentBomb.BombCol] -= currentBomb.BombPower;
                }
            }

            if (currentBomb.BombRow < matrix.GetLength(0) - 1
                && currentBomb.BombCol < matrix.GetLength(1) - 1) // Проверка за долу в дясно
            {
                if (matrix[currentBomb.BombRow + 1, currentBomb.BombCol + 1] > 0)
                {
                    matrix[currentBomb.BombRow + 1, currentBomb.BombCol + 1] -= currentBomb.BombPower;
                }
            }
        }

        private static void CalculateMiddleOfTheBombCell(int[,] matrix, Bombs currentBomb)
        {
            if (currentBomb.BombCol >= 1) // Проверка за среда в ляво
            {
                if (matrix[currentBomb.BombRow, currentBomb.BombCol - 1] > 0)
                {
                    matrix[currentBomb.BombRow, currentBomb.BombCol - 1] -= currentBomb.BombPower;
                }
            }

            if (currentBomb.BombCol < matrix.GetLength(1) - 1) // Проверка за среда в дясно
            {
                if (matrix[currentBomb.BombRow, currentBomb.BombCol + 1] > 0)
                {
                    matrix[currentBomb.BombRow, currentBomb.BombCol + 1] -= currentBomb.BombPower;
                }
            }
        }

        private static void CalculateTopOfTheBombCell(int[,] matrix, Bombs currentBomb)
        {
            if (currentBomb.BombRow >= 1 && currentBomb.BombCol >= 1) // Проверка за горе в ляво
            {
                if (matrix[currentBomb.BombRow - 1, currentBomb.BombCol - 1] > 0)
                {
                    matrix[currentBomb.BombRow - 1, currentBomb.BombCol - 1] -= currentBomb.BombPower;
                }
            }

            if (currentBomb.BombRow >= 1) // Проверка за горе в средата
            {
                if (matrix[currentBomb.BombRow - 1, currentBomb.BombCol] > 0)
                {
                    matrix[currentBomb.BombRow - 1, currentBomb.BombCol] -= currentBomb.BombPower;
                }
            }

            if (currentBomb.BombRow >= 1 // Тука.
                && currentBomb.BombCol < matrix.GetLength(1) - 1) // Проверка за горе в дясно
            {
                if (matrix[currentBomb.BombRow - 1, currentBomb.BombCol + 1] > 0)
                {
                    matrix[currentBomb.BombRow - 1, currentBomb.BombCol + 1] -= currentBomb.BombPower;
                }
            }
        }
        private static void GetAndMarkBombCoordinates(int[,] matrix, string[] bombsCoordinates, List<Bombs> bombsInfo, int i)
        {
            string[] currentBomb = bombsCoordinates[i].Split(",");

            int bombRow = int.Parse(currentBomb[0]);
            int bombCol = int.Parse(currentBomb[1]);
            int bombPower = matrix[bombRow, bombCol];

            Bombs currentBombInfo = new Bombs();

            currentBombInfo.BombRow = bombRow;
            currentBombInfo.BombCol = bombCol;
            currentBombInfo.BombPower = bombPower;

            bombsInfo.Add(currentBombInfo);
        }
        private static void FillingUpTheMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
    class Bombs
    {
        public int BombRow { get; set; }
        public int BombCol { get; set; }
        public int BombPower { get; set; }
    }
}
