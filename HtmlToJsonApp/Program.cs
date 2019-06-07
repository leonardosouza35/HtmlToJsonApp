using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HtmlToJsonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(@"C:\Projetos\HtmlToJsonApp\HtmlToJsonApp\html\MailBusinessReport-Full.html");

            var TagsTr = doc.DocumentNode.SelectSingleNode("//tbody//tr");

            MailBusiness mailBusiness = new MailBusiness();
            Section section = null;
            AgentType agentType = null;
            var years = new List<Year>();
            var year = new Year();
            var count = 0;


            var periodLabel = string.Empty;


            foreach (var tr in doc.DocumentNode.SelectNodes("//tbody//tr"))
            {
                foreach (var td in tr.SelectNodes("td"))
                {

                    if (td.GetAttributeValue("class", "").Contains("json-export-section"))
                    {
                        section = new Section(td.InnerText);
                        mailBusiness.Sections.Add(section);
                        continue;

                    }

                    if (td.GetAttributeValue("class", "").Contains("json-year-export"))
                    {
                        var tdValue = td.InnerText.Trim();
                        if (!string.IsNullOrEmpty(tdValue))
                        {
                            var label = td.ChildNodes.FirstOrDefault(n => n.Name.ToLower() == "label");
                            if (label != null)
                            {
                                var throughText = label.InnerText.Trim();
                                tdValue = tdValue.Substring(0,4) + " " + throughText;
                            }
                            section.Years.Add(new Year() { Value = tdValue });
                            continue;
                        }
                    }


                    if (td.GetAttributeValue("class", "").Contains("json-title-cell"))
                    {
                        agentType = new AgentType();
                        section.Agents.Add(agentType);
                        agentType.AgentTypeDescription = td.InnerText;
                        count = 0;
                        continue;
                        
                    }

                    if (td.GetAttributeValue("class", "").Trim() == "transactions-cell"){
                        year = new Year();
                        year.Transactions = !string.IsNullOrEmpty(td.InnerText) ? int.Parse(td.InnerText) : 0;                        
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Trim() == "sendamound-cell")
                    {
                        year.SendAmount = td.InnerText;

                        try { year.Value = section.Years[count].Value;  } catch { }

                        count++;
                        agentType.Years.Add(year);                        
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("json-table-total"))
                    {
                        agentType = new AgentType();
                        section.Agents.Add(agentType);
                        agentType.AgentTypeDescription = td.InnerText;
                        count = 0;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Trim() == "table-total-transactions")
                    {
                        year = new Year();
                        year.Transactions = !string.IsNullOrEmpty(td.InnerText) ? int.Parse(td.InnerText) : 0;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Trim() == "table-total-send-amound")
                    {
                        year.SendAmount = td.InnerText;

                        try { year.Value = section.Years[count].Value; } catch { }

                        count++;
                        agentType.Years.Add(year);
                        continue;
                    }



                }

            }

            SerializeObject(mailBusiness);

        }

        private static void SerializeObject(MailBusiness mailBusiness)
        {
            var jsonSerializer = new JsonSerializer();
            var json = JsonConvert.SerializeObject(mailBusiness, Formatting.Indented);

            var fileName = @"C:\integrations\json\file.json";

            if (File.Exists(fileName))
                File.Delete(fileName);

            using (var wr = new StreamWriter(fileName))
                wr.Write(json);
        }
    }
}
