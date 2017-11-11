using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIforNeuron
{
    struct SecondResponse
    {
        public byte empty;
        public byte white;
        public byte grey;
        public byte black;
        public byte color;

        public int quantityGrey;
        public bool boolGrey;
    }
    class SecondNeuron
    {
        int size = 0;
        Eye data;
        SecondResponse[,] secondnetNetwork;

        public SecondNeuron(Eye data)
        {
            this.data = data;
            int incX = 0; int incY = 0;

            int Xend = data.image.Width;
            int Yend = data.image.Height;
            secondnetNetwork = new SecondResponse[Xend/5, Yend/5];
            Xend -= 4;
            Yend -= 4; // need a testing
            for (int x = 0; x < Xend; x+=5)
            {
                for (int y = 0; y < Yend; y+=5)
                {

                    secondnetNetwork[incX, incY] = ProcessResponse(ref x, ref y);
                   // y += 5;
                    incY++;
                }
                //x += 5;
                incY = 0;
                incX++;
            }
            size = incX - 1;
        }

        public SecondResponse ProcessResponse(ref int x, ref int y)
        {
            List<FistResponse> response = new List<FistResponse>();
            SecondResponse secondResponse = new SecondResponse();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    response.Add(data.GetResponse(x + i, y + j));
                }
            //x += 5; y += 5;

            secondResponse.empty = 0;
            secondResponse.white = 0;
            secondResponse.grey = 0;
            secondResponse.black = 0;
            secondResponse.color = 0;
            secondResponse.quantityGrey = 0;
            secondResponse.boolGrey = false;

            int maxGrey = 127;
            int minGrey = 127;

            foreach (var element in response)
            {
                if (element.color) { secondResponse.color++; continue; }
                if (element.empty) { secondResponse.empty++; continue; }
                if (element.BlackWhite > 240) { secondResponse.white++; continue; }
                if (element.BlackWhite < 20) { secondResponse.black++; continue; }

                secondResponse.grey++;
                secondResponse.quantityGrey += element.BlackWhite;

                if (maxGrey < element.BlackWhite) maxGrey = element.BlackWhite;
                if (minGrey > element.BlackWhite) minGrey = element.BlackWhite;
            }
            if (secondResponse.empty + secondResponse.white + secondResponse.grey + secondResponse.black + secondResponse.color != 25) Messeges.Write("empty + white + grey + black + color != 25");

            if (maxGrey - minGrey > 22) { secondResponse.boolGrey = true; }

            if (secondResponse.empty == 25) return secondResponse;
            if (secondResponse.white == 25) return secondResponse;
            if (secondResponse.black == 25) return secondResponse;
            if (secondResponse.color == 25) return secondResponse;

            if (secondResponse.grey != 0) { secondResponse.quantityGrey = secondResponse.quantityGrey / secondResponse.grey; }
            else { secondResponse.quantityGrey = 0; }
            //           if (secondResponse.grey > 0) { secondResponse.quantityGrey = secondResponse.quantityGrey / secondResponse.grey; }
            //else return;

            //if (secondResponse.black > 0 && secondResponse.white > 0 && secondResponse.quantityGrey == 0) { return; }
            return secondResponse;
        }

        public void GetResponse()
        {
            for (int x = 0; x <= size; x++)
                for (int y = 0; y <= size; y++)
                {

                }
        }
    }
}
