using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;

namespace GUIforNeuron
{
    class Json
    {
        string directory = @"d:\programs\Develop\ApplicationDevelopment\ApplicationDevelopment\ApplicationDevelopment\JSON\";
        string fileName = @"file.json";
        public Json(string directory, string fileName)
        {
            this.directory = directory;
            this.fileName = fileName;
        }
        public List<Answer> Read()
        {
            var answer = new List<Answer>();
            var jObject = JObject.Parse(File.ReadAllText(directory + fileName));
            int size = (int)jObject["size"];
            for (int i = 0; i < size * size; i++)
            {
                var ans = new Answer();
                ans.white = (double)jObject["arrayAnswer"]["items"][i]["white"];
                ans.grey = (double)jObject["arrayAnswer"]["items"][i]["grey"];
                ans.darkGrey = (double)jObject["arrayAnswer"]["items"][i]["darkGrey"];
                ans.liteGrey = (double)jObject["arrayAnswer"]["items"][i]["liteGrey"];
                ans.black = (double)jObject["arrayAnswer"]["items"][i]["black"];
                ans.color = (double)jObject["arrayAnswer"]["items"][i]["color"];
                answer.Add(ans);
            }
            return answer;
        }
        public void Write(Answer[,] answer)
        {
            int size = Convert.ToInt32(Math.Sqrt(answer.Length));

            List<Answer> forJson = new List<Answer>();
            foreach (var element in answer)
                forJson.Add(element);

            //JObject jObject = new JObject();
            int i = 0;
            JObject jObject = new JObject(
                new JProperty("size", size),
                new JProperty("arrayAnswer",
                new JObject(
                    new JProperty("items",
                        new JArray(
                            from element in forJson
                            select new JObject(
                                new JProperty("nubmer", i++),
                                new JProperty("white", element.white),
                                new JProperty("grey", element.grey),
                                new JProperty("darkGrey", element.darkGrey),
                                new JProperty("liteGrey", element.liteGrey),
                                new JProperty("black", element.black),
                                new JProperty("color", element.color)
                                )
                            )
                        )
                    )
                ));

            File.WriteAllText(directory + fileName, jObject.ToString());
            Console.WriteLine(jObject.ToString());
        }
    }
}
