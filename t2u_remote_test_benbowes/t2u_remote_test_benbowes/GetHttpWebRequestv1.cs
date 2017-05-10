using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace t2u_remote_test_benbowes
{
    public class GetHttpWebRequestv1
    {
        public string GetHttpWebRequestv1()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://google.co.uk");
            HttpWebResponse response = null;
            string htmlToReturn = "";
            
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }

                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                htmlToReturn = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            return htmlToReturn;
        }


    }
}
