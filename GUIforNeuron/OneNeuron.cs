using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;

namespace GUIforNeuron
{
    class OneNeuron
    {
        Point[,] sinPoints = new Point[32, 32];
        Point[,] cosPoints = new Point[32, 32];
        Point[,] tanPoints = new Point[32, 32];
        Point[,] ctanPoints = new Point[32, 32];
        Point[,] expPoints = new Point[32, 32];
        Point[,] lgPoints = new Point[32, 32];
        Point[,] lnPoints = new Point[32, 32];
        public OneNeuron()
        {
            string sinDirectory = @"d:\programs\Diplom\GUI\GUIforNeuron\GUIforNeuron\json\SmatrLayer32\sin.json";
            string cosDirectory = @"d:\programs\Diplom\GUI\GUIforNeuron\GUIforNeuron\json\SmatrLayer32\cos.json";
            string tanDirectory = @"d:\programs\Diplom\GUI\GUIforNeuron\GUIforNeuron\json\SmatrLayer32\tan.json";
            string ctanDirectory = @"d:\programs\Diplom\GUI\GUIforNeuron\GUIforNeuron\json\SmatrLayer32\ctan.json";

            for (int grahp = 0; grahp < 4; grahp++)
            {
                Point[,] array;
                string directory;
                switch (grahp)
                {
                    case (0): array = sinPoints; directory = sinDirectory; break;
                    case (1): array = cosPoints; directory = cosDirectory; break;
                    case (2): array = tanPoints; directory = tanDirectory; break;
                    case (3): array = ctanPoints; directory = ctanDirectory; break;
                    default: array = lnPoints; directory = ""; break;
                }
                var points = new List<Point>();
                var jObject = JObject.Parse(File.ReadAllText(directory));
                int size = (int)jObject["size"];
                for (int i = 0; i < size; i++)
                {
                    var ans = new Point();
                    ans.white = (double)jObject["arrayAnswer"]["items"][i]["white"];
                    ans.grey = (double)jObject["arrayAnswer"]["items"][i]["grey"];
                    ans.black = (double)jObject["arrayAnswer"]["items"][i]["black"];
                    ans.color = (double)jObject["arrayAnswer"]["items"][i]["color"];
                    ans.radius = (double)jObject["arrayAnswer"]["items"][i]["radius"];
                    points.Add(ans);
                }
                int inc = 0;
                for (int x = 0; x < 32; x++)
                    for (int y = 0; y < 32; y++)
                    {
                        array[x, y] = points[inc];
                        inc++;
                    }
            }
        }

        public void culk()
        {

            double sinW = 0;
            double cosW = 0;
            double tanW = 0;
            double ctanW = 0;
            int inc = 0;

            metka:
            sinW = 0;
            cosW = 0;
            tanW = 0;
            ctanW = 0;
            inc = 0;

            //for (int x = 21; x <= 24; x++)
            //    for (int y = 12; y <= 15; y++)
            //    {
            //        sinW += 1 - sinPoints[x, y].radius;
            //        cosW += 1 - cosPoints[x, y].radius;
            //        tanW += 1 - tanPoints[x, y].radius;
            //        ctanW += 1 - ctanPoints[x, y].radius;
            //        inc++;
            //    }
            for (int x = 28; x <= 29; x++)
                for (int y = 17; y <= 18; y++)
                {
                    sinW += 1 - sinPoints[x, y].radius;
                    cosW += 1 - cosPoints[x, y].radius;
                    tanW += 1 - tanPoints[x, y].radius;
                    ctanW += 1 - ctanPoints[x, y].radius;
                    inc++;
                }
            sinW /= inc;
            cosW /= inc;
            tanW /= inc;
            ctanW /= inc;

            var file = File.CreateText(@"C:\Users\Constantine\Desktop\OutputBayes.txt");
            file.WriteLine(sinW);
            file.WriteLine(cosW);
            file.WriteLine(tanW);
            file.WriteLine(ctanW);
            file.Close();

            goto metka;
        }
    }
}
