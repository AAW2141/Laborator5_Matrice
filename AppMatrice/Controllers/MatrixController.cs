﻿using Microsoft.AspNetCore.Mvc;

namespace AppMatrice.Controllers
{
    public class MatrixController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateMatrix(int rows, int columns)
        {
            if (ModelState.IsValid)
            {
                int[,] matrix = GenerateRandomMatrix(rows, columns);
                int maxValue = matrix.Cast<int>().Max();
                int minValue = matrix.Cast<int>().Min();

                ViewBag.Matrix = matrix;    
                ViewBag.MaxValue = maxValue;
                ViewBag.MinValue = minValue;    
                return View("Matrix");
            }
            
            return View("Index");
        }

        private int[,] GenerateRandomMatrix(int rows, int columns)
        {
            Random random = new Random();
            int[,] matrix = new int[rows, columns];
            for (int i = 0;i<rows; i++)
            {
                for (int j = 0;j<columns; j++)
                {
                    matrix[i,j] = random.Next(1,100);
                }
            }
            return matrix;
        }
    }
}
