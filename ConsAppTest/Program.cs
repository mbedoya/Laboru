using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ConsAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(GetRequest("http://localhost:57565/Expert/Get/1", "", null));
            Console.WriteLine(GetRequest("http://mungos:8083/Expert/Register", "{\"Name\":\"Mauro\",\"Mobile\":\"3004802278\"}", null));
            //string contacts = "{\"ID\":\"2\", \"Name\":\"Negrito\", \"contacts\" : [{\"Name\":\"Pirrycin\",\"Mobile\":\"3001234563\"}] }";
            //Console.WriteLine(GetRequest("http://localhost:57565/Expert/SetContacts", contacts, null));

            //Console.WriteLine(GetRequest("http://localhost:57565/Expert/GetBySkillAndExpert", "{\"SkillID\":\"12\",\"FromExpertID\":\"2\"}", null));

            Console.ReadLine();
        }

        public static string GetRequest(string url, string postData, Dictionary<string, string> headers)
        {
            try
            {
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(url);
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        wrGETURL.Headers.Add(item.Key, item.Value);
                    }                    
                }

                wrGETURL.Method = "POST";
                wrGETURL.ContentType = "application/json; charset=utf-8";

                if(!String.IsNullOrEmpty(postData)){
                    //var data = Encoding.ASCII.GetBytes(postData);
                    //wrGETURL.ContentLength = data.Length;

                    using (var stream = new StreamWriter(wrGETURL.GetRequestStream()))
                    {
                        stream.Write(postData);
                    }
                }

                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);
                string result = objReader.ReadToEnd();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en: " + url);
                Console.WriteLine(ex.Message);

                return "{}";
            }

        }
    }
}
