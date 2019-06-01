using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace HtmlToJsonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(@"C:\Projetos\HtmlToJsonApp\HtmlToJsonApp\html\MailBusinessReport.html");

            var tBody = doc.DocumentNode.SelectSingleNode("//tbody");
            //var TagsTr = tBody.ChildNodes.Where(t => t.Name.ToLower() == "tr");
            var TagsTr = doc.DocumentNode.SelectSingleNode("//tbody//tr");

            MailBusiness mailBusiness = new MailBusiness();
            Agent agent = null;

            var periodLabel = string.Empty;


            foreach(var tr in doc.DocumentNode.SelectNodes("//tbody//tr"))
            {
                //var tds = tr.ChildNodes.Where(t => t.Name.ToLower() == "td");
                foreach (var td in tr.SelectNodes("td"))
                {
                    var label = td.ChildNodes.FirstOrDefault(n => n.Name.ToLower() == "label");
                    if (label != null)
                    {
                        periodLabel = label.InnerText;
                        agent = new Agent();
                        agent.Period = label.InnerText;                        
                    }
                    else if(td.GetAttributeValue("class", "").Trim() == "table-title")
                    {                        
                        if (agent != null 
                            && td.InnerText.IndexOf("AGENT") == -1)
                        {
                            agent.State = td.InnerText;                            
                        }
                    }
                    else
                    {
                        if(td.GetAttributeValue("class", "").Trim() == "title-cell")
                        {
                            if (string.IsNullOrEmpty(agent.AgentName))
                                agent.AgentName = td.InnerText;
                            else
                                agent.State = td.InnerText;

                        }else if (td.GetAttributeValue("class", "").Trim() == "transactions-cell")
                        {
                            agent.Transactions = System.Convert.ToInt32(td.InnerText);   
                            
                        }else if (td.GetAttributeValue("class", "").Trim() == "sendamound-cell")
                        {
                            agent.SendAmount = td.InnerText;
                            mailBusiness.Agents.Add(agent);
                            agent = new Agent();
                            agent.Period = periodLabel;
                        }

                    }
                                                            
                }

                //if (agent != null 
                //    && !string.IsNullOrEmpty(agent.SendAmount))
                //    mailBusiness.Agents.Add(agent);
             }

            var jsonSerializer = new JsonSerializer();
            var json = JsonConvert.SerializeObject(mailBusiness,Formatting.Indented);

            var fileName = @"C:\integrations\json\file.json";

            if (File.Exists(fileName))
                File.Delete(fileName);

            using (var wr = new StreamWriter(fileName))
                wr.Write(json);
           

            }                                
    }
}
