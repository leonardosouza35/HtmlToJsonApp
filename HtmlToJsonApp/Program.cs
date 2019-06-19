using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
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
            doc.Load(@"C:\Projetos\HtmlToJsonApp\HtmlToJsonApp\html\MailBusinessReport-6.html");

            var TagsTr = doc.DocumentNode.SelectSingleNode("//tbody//tr");

            MailBusiness mailBusiness = new MailBusiness();
            Section section = null;
            Total total =null;
            SubSection subSection = null;
            BusinessModel agentType = null;
            var years = new List<Year>();
            var year = new Year();
            var count = 0;


            var periodLabel = string.Empty;


            foreach (var tr in doc.DocumentNode.SelectNodes("//tbody//tr"))
            {
                foreach (var td in tr.SelectNodes("td"))
                {

                    if (td.GetAttributeValue("class", "") == "table-title section")
                    {
                        section = new Section(td.InnerText);
                        mailBusiness.Sections.Add(section);
                        continue;                                               
                    }

                                        
                    if (td.GetAttributeValue("class", "").Contains("transactions-amount-table-border-full") 
                        && !IsByPassedTag(td))                       
                    {                                                                            
                        var tdValue = td.InnerText.Trim();
                        if (!string.IsNullOrEmpty(tdValue))
                        {
                            var label = td.ChildNodes.FirstOrDefault(n => n.Name.ToLower() == "label");
                            if (label != null)
                            {
                                var throughText = label.InnerText.Trim();
                                tdValue = tdValue.Substring(0, 4) + " " + throughText;
                            }

                            if (subSection != null)
                                subSection.Years.Add(new Year() { YearDescription = tdValue });
                            else
                                section.Years.Add(new Year() { YearDescription = tdValue });
                            
                            
                        }
                    }

                    if (td.GetAttributeValue("class", "") == "table-title subsection")                        
                    {
                        subSection = CreateSubSection(section,subSection, td);                        
                        continue;
                    }



                    if (td.GetAttributeValue("class", "").Trim() == "title-cell")
                    {
                        agentType = new BusinessModel();

                        if (subSection == null)                        
                            subSection = CreateSubSection(section, subSection, td);                                                    

                        subSection.BusinessModels.Add(agentType);
                        agentType.Description = td.InnerText;
                        count = 0;
                        continue;

                    }

                    if (td.GetAttributeValue("class", "").Trim() == "transactions-cell")
                    {
                        year = new Year();
                        year.Transactions = !string.IsNullOrEmpty(td.InnerText) ? int.Parse(td.InnerText) : 0;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Trim() == "sendamound-cell")
                    {
                        year.SendAmount = td.InnerText;

                        try {
                            if (subSection != null && subSection.Years.Count > 0 )
                                year.YearDescription = subSection.Years[count].YearDescription;
                            else
                                year.YearDescription = section.Years[count].YearDescription;

                            count++;
                            agentType.Years.Add(year);
                        }
                        catch {
                        }

                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Trim() == "table-total-border-full")
                    {
                        subSection = null;
                        total = CreateTotalSection(section, total, td);                                                
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

                        try {

                            year.YearDescription = section.Years[count].YearDescription;
                            count++;                          
                        } catch { }

                        total.Years.Add(year);                        
                        continue;
                    }



                }

            }

            SerializeObject(mailBusiness);

        }

        private static SubSection CreateSubSection(Section section, SubSection subSection, HtmlNode td)
        {
            subSection = new SubSection(td.InnerText);
            section.SubSection.Add(subSection);
            return subSection;
        }


        private static Total CreateTotalSection(Section section, Total total, HtmlNode td)
        {
            total = new Total();
            section.Total.Add(total);
            return total;
        }

        private static bool IsByPassedTag(HtmlNode td)
        {

            if (td.GetAttributeValue("class", "").Contains("countrystate-country")
                || td.GetAttributeValue("class", "").Contains("countrystate-state")
                || td.GetAttributeValue("class", "").Contains("agentstate-agent")
                || td.GetAttributeValue("class", "").Contains("agentstate-state")
                || td.GetAttributeValue("class", "").Contains("country")
                || td.GetAttributeValue("class", "").Contains("state")
                || td.GetAttributeValue("class", "").Contains("agent"))
                return true;

            return false;
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
