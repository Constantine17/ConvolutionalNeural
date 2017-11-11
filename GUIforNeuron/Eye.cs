using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GUIforNeuron
{
    struct FistResponse{
        public int BlackWhite;
        public bool color;
        public bool empty;
    }
    class Eye
    {
        public Bitmap image;
        public Eye(string directory)
        {
            Bitmap inputImage = new Bitmap(directory);
            //Bitmap outpuImage = new Bitmap()
            int inputX = inputImage.Width;
            int inputY = inputImage.Height;

            int outputSize;

            if (inputX > inputY) { outputSize = inputX; }
            else { outputSize = inputY; }
            image = new Bitmap(outputSize, outputSize);

            int beginX = (outputSize - inputX) / 2;
            int endX = outputSize - (outputSize - inputX) / 2;
            int beginY = (outputSize - inputY) / 2;
            int endY = outputSize - (outputSize - inputY) / 2;
            /*
            for (int x = 0; x < outputSize; x++)
            {
                for (int y = 0; y < outputSize; y++)
                {
                    image.SetPixel(x, y, Color.Red);
                }
            }
            */
            int oX = 0, oY = 0;
            for (int x = beginX; x < endX - 1; x++)
            {
                for (int y = beginY; y < endY - 1; y++)
                {
                    image.SetPixel(x, y, inputImage.GetPixel(oX, oY));
                    //var tt = image.GetPixel(x, y);
                    oY++;
                }
                oY = 0;
                oX++;
            }
        }

        public FistResponse GetResponse(int X, int Y)
        {
            var response = new FistResponse();
            response.BlackWhite = 256;
            response.empty = false;


            byte Alpha = image.GetPixel(X, Y).A;
            byte Red = image.GetPixel(X, Y).R;
            byte Green = image.GetPixel(X, Y).G;
            byte Blue = image.GetPixel(X, Y).B;

            int Mid = (Red + Green + Blue) / 3;

            //double relativityAlpha = 0;
            if (Alpha < 10) { response.empty = true; response.BlackWhite = Mid; return response; }
            //if (Alpha < 240) { relativityAlpha = Convert.ToDouble(Alpha) / 256; }

            if(Red==Blue&&Red==Green&&Green==Blue) { response.BlackWhite = Mid; return response; }

            if ((Mid - Red <= 20 && Mid - Red >= -20
                && Mid - Green <= 12 && Mid - Green >= -12
                && Mid - Blue <= 25 && Mid - Blue >= -25)
                ||(Red - Mid <= 28 && Red - Mid >= -28
                && Green - Mid <= 18 && Green - Mid >= -18
                && Blue - Mid <= 17 && Blue - Mid >= -17)
                ) { response.BlackWhite = Mid; return response; }

            response.color = true;
            response.BlackWhite = Mid;
            return response;
        }

        public void ConvertImage()
        {
            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++)
                {
                    var response = GetResponse(x, y);
                    if (response.BlackWhite >= 256) { new Exception("response.BlackWhite >= 256"); }
                    if (response.color) {  }


                    /*
                    var response = GetResponse(x, y);
                    if (response.empty) image.SetPixel(x, y, Color.Green);
                    if (response.BlackWhite != 256) { image.SetPixel(x, y, Color.FromArgb(255, response.BlackWhite, response.BlackWhite, response.BlackWhite)); }
                    if(response.color) image.SetPixel(x, y, Color.Red);
                    */
                }
        }
    }
}
