//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;


namespace GUIforNeuron
{
    class SmartLayer32
    {
        //List<SecondResponse>[,] listData = new List<SecondResponse>[32, 32];
        Answer[,] answerNeuron32 = new Answer[32, 32];
       // SmartAnswer[,] smartAnswerNeuron32 = new SmartAnswer[32, 32];

        Point[,] sinPoints = new Point[32, 32];
        Point[,] cosPoints = new Point[32, 32];
        Point[,] tanPoints = new Point[32, 32];
        Point[,] ctanPoints = new Point[32, 32];
        Point[,] expPoints = new Point[32, 32];
        Point[,] lgPoints = new Point[32, 32];
        Point[,] lnPoints = new Point[32, 32];

        public SmartLayer32() { }
        public SmartLayer32(SecondResponse[,] data)
        {
            ReadFiles();
            SetData(data);
            double sin = 0;
            double cos = 0;
            int sini = 0, cosi = 0;

            var input = GetData(data);
            var culc = new Geometry();
            for (int x = 0; x < 32; x++)
                for (int y = 0; y < 32; y++)
                {
                    double mid = culc.LengthBetweenPoints(sinPoints[x, y].white, sinPoints[x, y].black, sinPoints[x, y].grey, sinPoints[x, y].color, input[x, y].white, input[x, y].black, input[x, y].grey, input[x, y].color);
                    mid= Math.Abs(sinPoints[x, y].radius - mid);
                    sin += mid;//if (0 < mid && mid < 0.5) sini++;
                }
            for (int x = 0; x < 32; x++)
                for (int y = 0; y < 32; y++)
                {
                    double mid = culc.LengthBetweenPoints(cosPoints[x, y].white, cosPoints[x, y].black, cosPoints[x, y].grey, cosPoints[x, y].color, input[x, y].white, input[x, y].black, input[x, y].grey, input[x, y].color);
                    mid= Math.Abs(cosPoints[x, y].radius - mid);
                    cos += mid;//if (0 < mid && mid < 0.5) cosi++;
                }
            sin /= 1024;
            cos /= 1024;
         
        }

        public Answer[,] GetData(SecondResponse[,] data)
        {
            List<SecondResponse>[,] listData = new List<SecondResponse>[32, 32];
            int size = Convert.ToInt32(Math.Sqrt(data.Length));
            int step = size / 32;
            for (int x = 0; x < 32; x++)
                for (int y = 0; y < 32; y++)
                {

                    listData[x, y] = new List<SecondResponse>();
                    listData[x, y] = CollectDate(x, y, data, size, step);
                }
            CalcConcentration(listData);
            return answerNeuron32;
        }
        public void SetData(SecondResponse[,] data)
        {
            List<SecondResponse>[,] listData = new List<SecondResponse>[32, 32];
            int size = Convert.ToInt32(Math.Sqrt(data.Length));
            int step = size / 32; 
            for (int x = 0; x < 32; x++)
                for (int y = 0; y < 32; y++)
                {

                    listData[x, y] = new List<SecondResponse>();
                    listData[x, y] = CollectDate(x, y, data, size, step);
                }
            CalcConcentration(listData);
        }
        List<SecondResponse> CollectDate(int x, int y, SecondResponse[,] data, int size, int step)
        {
            int Xb = x * step;
            int Yb = y * step;
            List<SecondResponse> response = new List<SecondResponse>();
            //int itr = 0;
            for (int X = Xb - 1; X < Xb + step + 1; X++)
                for (int Y = Yb -1; Y < Yb + step + 1; Y++)
                {
                    //itr++;
                    if (X < 0 || Y < 0) continue;
                    if (X >= size || Y >= size) continue;
                    response.Add(data[X, Y]);
                }
            return response;
        }
        void CalcConcentration(List<SecondResponse>[,] listData)
        {
            for (int x = 0; x < 32; x++)
                for (int y = 0; y < 32; y++)
                {
                    //int empty = 0;
                    int white = 0;
                    int grey = 0;
                    int liteGrey = 0;
                    int darkGrey = 0;
                    int black = 0;
                    int color = 0;
                    //int whiteBlack = 0;
                    //int quantityBlackWhite = 0;
                    //int amUpGrey = 0;
                    //int amDownGray = 0;
                    double amount = 0;
                    foreach (var element in listData[x, y])
                    {
                        if (element.empty == 25) continue;
                        if (element.white == 0 && element.empty > 0) { white += element.empty; }
                        else { white += element.white; }
                        color += element.color;
                        black += element.black;

                        //if(element.grey > 0 && element.upGrey != element.downGrey)
                        //{
                        //    whiteBlack += element.upGrey;
                        //    amUpGrey += element.upGrey;
                        //    amDownGray += element.downGrey;
                        //    quantityBlackWhite++;
                        //}
                        //else
                        grey += element.grey;
                        liteGrey += element.liteGrey;
                        darkGrey += element.darkGrey;

                        //amount += white + grey + black + color + whiteBlack;
                    }
                    //int midUpGrey = amUpGrey / quantityBlackWhite;
                    //int midDownGrey = amDownGray / whiteBlack;
                    amount = white + grey + black + color + liteGrey + darkGrey;
                    if (amount != 0)
                    {
                        answerNeuron32[x, y].white = white / amount;
                        answerNeuron32[x, y].grey = grey / amount;
                        answerNeuron32[x, y].black = black / amount;
                        answerNeuron32[x, y].color = color / amount;
                        answerNeuron32[x, y].liteGrey = liteGrey / amount;
                        answerNeuron32[x, y].darkGrey = darkGrey / amount;

                        //times
                        if (answerNeuron32[x, y].grey == 0) { answerNeuron32[x, y].grey = answerNeuron32[x, y].liteGrey + answerNeuron32[x, y].darkGrey; }
                        else {  answerNeuron32[x, y].white = answerNeuron32[x, y].liteGrey;
                                answerNeuron32[x, y].black = answerNeuron32[x, y].darkGrey;
                        }
                        answerNeuron32[x, y].liteGrey = 0;
                        answerNeuron32[x, y].darkGrey = 0;
                        //
                    }
                    double d = answerNeuron32[x, y].Amount();//detete
                }

        }
        public void writeFile()
        {
            string direcrory = @"d:\programs\Diplom\GUI\GUIforNeuron\GUIforNeuron\json\";
            string fileName = @"SmatrLayer32.json";
            var json = new Json(direcrory,fileName);
            json.Write(answerNeuron32);
        }

        void ReadFiles()
        {
            string sinDirectory = @"d:\programs\Diplom\GUI\GUIforNeuron\GUIforNeuron\json\SmatrLayer32\sin.json";
            string cosDirectory = @"d:\programs\Diplom\GUI\GUIforNeuron\GUIforNeuron\json\SmatrLayer32\cos.json";
            string tanDirectory = @"d:\programs\Diplom\GUI\GUIforNeuron\GUIforNeuron\json\SmatrLayer32\tan.json";
            string ctanDirectory = @"d:\programs\Diplom\GUI\GUIforNeuron\GUIforNeuron\json\SmatrLayer32\ctan.json";

            for (int grahp = 0; grahp < 4; grahp++)
            {
                Point[,] array;
                string directory;
                switch (grahp) { 
                    case (0): array = sinPoints; directory = sinDirectory; break;
                    case (1): array = cosPoints; directory = cosDirectory; break;
                    case (2): array = tanPoints; directory = tanDirectory; break;
                    case (3): array = ctanPoints; directory = ctanDirectory; break;
                    default:  array = lnPoints; directory = ""; break;
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
                        array[x,y] = points[inc];
                        inc++;
                    }
            }
        }
        
        public void CreateKnowlengeFile()
        {
            string imageDirectory = @"d:\programs\Diplom\GUI\GUIforNeuron\GUIforNeuron\json\SmatrLayer32\images\sin\";
            string file1 = @"sin1.jpg";
            string file2 = @"sin2.png";
            string file3 = @"sin3.jpg";

            List<Point> points = new List<Point>();
            Answer[,] fist = new Answer[32, 32];
            Answer[,] second = new Answer[32, 32];
            Answer[,] third = new Answer[32, 32];

            //var eye = new Eye(imageDirectory);
            fist = new SmartLayer32().GetData(new SecondNeuron(new Eye(imageDirectory + file1)).secondnetNetwork);
            second = new SmartLayer32().GetData(new SecondNeuron(new Eye(imageDirectory + file2)).secondnetNetwork);
            third = new SmartLayer32().GetData(new SecondNeuron(new Eye(imageDirectory + file3)).secondnetNetwork);

            var culk = new Geometry();
            for (int x = 0; x < 32; x++)
                for (int y = 0; y < 32; y++)
                {
                    //double fist1 = 0, second1 = 0, third1 = 0;

                    var point = new Point();
                    point.white = (fist[x,y].white + second[x, y].white + third[x, y].white) / 3;
                   // fist1 = fist[x, y].white; second1 = second[x, y].white; third1 = third[x, y].white;
                    point.black = (fist[x, y].black + second[x, y].black + third[x, y].black) / 3;
                   // fist1 = fist[x, y].black; second1 = second[x, y].black; third1 = third[x, y].black;
                    point.grey = (fist[x, y].grey + second[x, y].grey + third[x, y].grey) / 3;
                    
                    point.color = (fist[x, y].color + second[x, y].color + third[x, y].color) / 3;
                   // fist1 = fist[x, y].color; second1 = second[x, y].color; third1 = third[x, y].color;



                    double bigRadius;
                    double smalRadius;
                    double radius;
                    radius = culk.LengthBetweenPoints(point.white, point.black, point.grey, point.color, fist[x, y].white, fist[x, y].black, fist[x, y].grey, fist[x, y].color);
                    bigRadius = radius; smalRadius = radius;
                    radius = culk.LengthBetweenPoints(point.white, point.black, point.grey, point.color, second[x, y].white, second[x, y].black, second[x, y].grey, second[x, y].color);
                    if (bigRadius < radius) bigRadius = radius;
                    if (smalRadius > radius) smalRadius = radius;
                    radius = culk.LengthBetweenPoints(point.white, point.black, point.grey, point.color, third[x, y].white, third[x, y].black, third[x, y].grey, third[x, y].color);
                    if (bigRadius < radius) bigRadius = radius;
                    if (smalRadius > radius) smalRadius = radius;

                    point.smalRadius = smalRadius;
                    point.bigRadius = bigRadius;
                    point.radius = (smalRadius + bigRadius) / 2;

                    points.Add(point);
                }

            int i = 0;
            JObject jObject = new JObject(
                new JProperty("size", 1024),
                new JProperty("arrayAnswer",
                new JObject(
                    new JProperty("items",
                        new JArray(
                            from element in points
                            select new JObject(
                                new JProperty("number", i++),
                                new JProperty("white", element.white),
                                new JProperty("grey", element.grey),
                                new JProperty("black", element.black),
                                new JProperty("color", element.color),
                                new JProperty("radius", element.radius),
                                new JProperty("smalRadius", element.smalRadius),
                                new JProperty("bigRadius", element.bigRadius)
                                )
                            )
                        )
                    )
                ));

            File.WriteAllText(@"d:\programs\Diplom\GUI\GUIforNeuron\GUIforNeuron\json\SmatrLayer32\ctan.json", jObject.ToString());
        }
    }
}