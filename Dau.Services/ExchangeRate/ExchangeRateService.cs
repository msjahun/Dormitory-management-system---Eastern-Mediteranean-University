using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Dau.Services.ExchangeRate
{
   public class ExchangeRateService
    {

        public void GetCurrentExhangeRates()
        {

            XmlDocument doc1 = new XmlDocument();
            doc1.Load("http://api.wunderground.com/api/your_key/conditions/q/92135.xml");
            XmlElement root = doc1.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/response/current_observation");

            foreach (XmlNode node in nodes)
            {
                string tempf = node["temp_f"].InnerText;
                string tempc = node["temp_c"].InnerText;
                string feels = node["feelslike_f"].InnerText;

            }
        }
    }
}
