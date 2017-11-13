//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace GUIforNeuron
{
    struct SmartLayer32response
    {
        public double white;
        public double grey;
        public double black;
        public double color;
    }
    class SmartLayer32
    {
        List<SecondResponse>[,] listData = new List<SecondResponse>[32, 32];

        public SmartLayer32(SecondResponse[,] data)
        {
            int size = Convert.ToInt32(Math.Sqrt(data.Length));
            int step = size / 32; 
            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {

                    listData[x, y] = new List<SecondResponse>();
                    listData[x, y] = CollectDate(x, y, data, size, step);
                }
            }
        }
        List<SecondResponse> CollectDate(int x, int y, SecondResponse[,] data, int size, int step)
        {
            int Xb = x * step;
            int Yb = y * step;
            List<SecondResponse> response = new List<SecondResponse>();
            int itr = 0;
            for (int X = Xb - 1; X < Xb + step + 1; X++)
                for (int Y = Yb -1; Y < Yb + step + 1; Y++)
                {
                    itr++;
                    if (X < 0 || Y < 0) continue;
                    if (X >= size || Y >= size) continue;
                    response.Add(data[X, Y]);
                }
            return response;
        }
    }
}