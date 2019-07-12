using System;
using System.IO;
using HtmlAgilityPack;
using HtmlToJsonApp.Model.DailyBusinessModel;
using Newtonsoft.Json;

namespace HtmlToJsonApp.Report
{
    public class DailyBusinessReport
    {
        public void CreateReport()
        {
            var doc = new HtmlDocument();
            doc.Load(@"C:\Projetos\HtmlToJsonApp\HtmlToJsonApp\html\Daily\DailyBusiness.html");

            var dailyBusiness = new DailyBusiness();
            BusinessModel businessModel = null;
            BusinessType businessType = null;

            StatesPerAgentModel statesPerAgentModel =null;
            StatesPerAgentItem statesPerAgentItem = null;

            PaymentAggregatorModel paymentAggregatorModel;
            PaymentAggregatorItem paymentAggregatorItem;

            foreach (var tr in doc.DocumentNode.SelectNodes("//tbody//tr"))
            {
                foreach (var td in tr.SelectNodes("td"))
                {
                    #region Business Model
                    if (td.GetAttributeValue("class", "").Contains("BusinessModel"))
                    {
                        businessModel = new BusinessModel();
                        dailyBusiness.SetBusinessModel(businessModel);
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("BMTransactionsItem"))
                    {
                        businessType = new BusinessType(td.InnerText);
                        businessModel.BusinessType.Add(businessType);
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("BMTransactions"))
                    {
                        businessType.Transactions = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("BMSendAmount"))
                    {
                        businessType.SendAmount = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("BMTotalHeader"))
                    {
                        businessModel.BusinessModelTotal = new BusinessModelTotal();                        
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("BMTotalHeader"))
                    {
                        businessModel.BusinessModelTotal = new BusinessModelTotal();
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("BMTotalTransactions"))
                    {
                        businessModel.BusinessModelTotal.Transactions = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("BMTotalSendAmount"))
                    {
                        businessModel.BusinessModelTotal.SendAmount = td.InnerText;
                        continue;
                    }

                    #endregion

                    #region StatesPerAgent

                    if (td.GetAttributeValue("class", "").Contains("statesPerAgent"))
                    {
                        statesPerAgentModel = new StatesPerAgentModel(td.InnerText);
                        dailyBusiness.StatesPerAgentModel.Add(statesPerAgentModel);
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("stateItem"))
                    {
                        statesPerAgentItem = new StatesPerAgentItem();
                        statesPerAgentModel.AgentType.Add(statesPerAgentItem);
                        statesPerAgentItem.State = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("stateTransaction"))
                    {
                        statesPerAgentItem.Transactions = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("stateSendAmount"))
                    {
                        statesPerAgentItem.SendAmount = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("agentTypeTotalHeader"))
                    {
                        statesPerAgentModel.StatesPerAgentTotal = new StatesPerAgentTotal();                        
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("agentTypeTotalTransaction"))
                    {
                        statesPerAgentModel.StatesPerAgentTotal.Transactions = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("agentTypeTotalSendAmount"))
                    {
                        statesPerAgentModel.StatesPerAgentTotal.SendAmount = td.InnerText;
                        continue;
                    }
                    #endregion

                    #region PaymentAggregator

                    if (td.GetAttributeValue("class", "").Contains("paymentAgregator"))
                    {

                        paymentAggregatorModel = new PaymentAggregatorModel();                        
                        dailyBusiness.PaymentAggregatorModel.Add(paymentAggregatorModel);
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("paymentAgregator"))
                    {

                        paymentAggregatorModel = new PaymentAggregatorModel();
                        dailyBusiness.PaymentAggregatorModel.Add(paymentAggregatorModel);
                        continue;
                    }

                    #endregion


                }
            }

            SerializeObject(dailyBusiness);

        }

        private static void SerializeObject(DailyBusiness dailyBusiness)
        {
            var jsonSerializer = new JsonSerializer();
            var json = JsonConvert.SerializeObject(dailyBusiness, Formatting.Indented);

            var fileName = @"C:\integrations\json\dailyBusiness.json";

            if (File.Exists(fileName))
                File.Delete(fileName);

            using (var wr = new StreamWriter(fileName))
                wr.Write(json);
        }

    }
}
