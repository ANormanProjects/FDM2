using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace t2u_remote_test_benbowes
{
    public class HttpWebRequestWrapper
    {
        public string GetHttpWebRequestv2()
        {
            try
            {
                var request = ((HttpWebRequest)WebRequest.Create("http://google.co.uk"));

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var htmlToReturn = "";

                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
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
            catch (WebException ex)
            {
                return ex.Message;
            }
        }
    }
}
