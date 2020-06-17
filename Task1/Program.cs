using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Components;

namespace Task1
{
    class Program
    {
        private static char _outputFigureFrame = '¤', _outputFigurePicture = '\"';
        private static int _frameWidth, _frameHeight, _pictureWidth, _pictureHeight,_pictureY,_pictureX;

        static void Main(string[] args)
        {
            char [,] _mainArray;

            //Get data from user
            while (true)
            {
                try
                {
                    Console.WriteLine("Dear User :) \nPlease enter main FRAME WIDTH :");

                    _frameWidth = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter main FRAME HEIGHT :");

                    _frameHeight = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter  PICTURE WIDTH :");

                    _pictureWidth = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter  PICTURE HEIGHT :");

                    _pictureHeight = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter  PICTURE X :");

                    _pictureX = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter  PICTURE Y :");

                    _pictureY = int.Parse(Console.ReadLine());

                    //Picture initialization
                    Picture picture = new Picture(_pictureHeight, _pictureWidth);
                    picture.X = _pictureX;
                    picture.Y = _pictureY;

                    //Array initialization
                    _mainArray = new char[_frameHeight, _frameWidth];
                    _mainArray = ArrayInitialization(_frameHeight, _frameWidth, picture);

                    //Display current state
                    Console.WriteLine("Congratulation you have got Frame with your sizes and random generated image inside this frame!");
                    Display(_mainArray);

                    //Display new picture position (0;0)
                    PictureToLeftUpCorner(_mainArray, picture);
                    Display(_mainArray);
                }
                catch (Exception)
                {
                    Console.WriteLine("Your input is incorect!");
                }
            }
        }

        private static char[,] ArrayInitialization(int _frameHeight, int _frameWidth, Picture picture)
        {
            char[,] _resultArray = new char[_frameHeight, _frameWidth];

            for (int fy = 0; fy < _frameHeight; fy++)
            {
                for (int fx = 0; fx < _frameWidth; fx++)
                {
                    if(fy==0 && fx>=0 && fx<= _frameWidth ||
                       fy >= 0 && fy <= _frameHeight && fx == 0 ||
                       fy== _frameHeight-1 && fx >= 0 && fx <= _frameWidth || 
                       fx == _frameWidth-1 && fy>=0 && fy <= _frameHeight)
                    {
                        _resultArray[fy, fx] = _outputFigureFrame;
                    }
                    if (fy == picture.Y && fx >= picture.X && fx <= picture.X+ picture.Width-1 ||
                       fy >= picture.Y && fy <= picture.Height-1 + picture.Y && fx == picture.X ||
                       fy == picture.Y+picture.Height-1 && fx >= picture.X && fx <= picture.Width-1 + picture.X ||
                       fx == picture.Width-1 + picture.X && fy >= picture.Y && fy <= picture.Height-1 + picture.Y
                        )
                    {
                        _resultArray[fy, fx] = _outputFigurePicture;
                    }
                }
            }
            return _resultArray;
        }

        private static void Display(char[,] mainArray)
        {
            for (int fy = 0; fy < mainArray.GetLength(0); fy++)
            {
                for (int fx = 0; fx < mainArray.GetLength(1); fx++)
                {
                    Console.Write(mainArray[fy, fx]);
                }
                Console.WriteLine();
            }
        }

        private static void PictureToLeftUpCorner(char[,] array, Picture picture)
        {
            if (picture.X == 0 && picture.Y == 0) return;

            for (int py = picture.Y; py < picture.Y + picture.Height; py++)
            {
                for (int px = picture.X; px < picture.X + picture.Width; px++)
                {
                    if (py < _frameHeight && px < _frameWidth && array[py, px] == _outputFigurePicture)
                    {
                        array[py- picture.Y, px- picture.X] = _outputFigurePicture;
                        array[py, px] = ' ';
                    }
                    
                }
            }
        }
    }
}
