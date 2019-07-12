using System.IO;
using HtmlAgilityPack;
using HtmlToJsonApp.Model.DailyBusinessModel;
using HtmlToJsonApp.Model.DailyBusinessModelS;
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

            PaymentAggregatorModel paymentAggregatorModel = null;
            PaymentAggregatorItem paymentAggregatorItem = null;

            CountriesPerAgentModel countriesPerAgentModel = null;
            CountriesPerAgentItem countriesPerAgentItem = null;

            CountryAndStatePerAgentModel countryAndStatePerAgentModel = null;
            CountryAndStatePerAgentItem countryAndStatePerAgentItem = null;


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

                    if (td.GetAttributeValue("class", "").Contains("perPaymentAgregator"))
                    {

                        paymentAggregatorModel = new PaymentAggregatorModel();                        
                        dailyBusiness.PaymentAggregatorModel.Add(paymentAggregatorModel);
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("paymentAgregatorItem"))
                    {

                        paymentAggregatorItem = new PaymentAggregatorItem();
                        paymentAggregatorModel.Item.Add(paymentAggregatorItem);
                        paymentAggregatorItem.Name = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("paymentAgregatorTransaction"))
                    {
                        paymentAggregatorItem.Transactions = td.InnerText;                        
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("paymentAgregatorSendAmount"))
                    {
                        paymentAggregatorItem.SendAmount = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("paymentAgregatorTotalHeader"))
                    {
                        paymentAggregatorModel.PaymentAggregatorTotal = new PaymentAggregatorTotal();
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("paymentAgregatorTotalTransactions"))
                    {
                        paymentAggregatorModel.PaymentAggregatorTotal.Transactions = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("paymentAgregatorTotalSendAmount"))
                    {
                        paymentAggregatorModel.PaymentAggregatorTotal.SendAmount = td.InnerText;
                        continue;
                    }

                    #endregion

                    #region CountriesPerAgent

                    if (td.GetAttributeValue("class", "").Contains("countriesPerAgent"))
                    {
                        countriesPerAgentModel = new CountriesPerAgentModel();
                        countriesPerAgentModel.Model = td.InnerText;
                        dailyBusiness.CountriesPerAgentModel.Add(countriesPerAgentModel);
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countriesAgentItem"))
                    {
                        countriesPerAgentItem = new CountriesPerAgentItem();
                        countriesPerAgentItem.Country = td.InnerText;
                        countriesPerAgentModel.Item.Add(countriesPerAgentItem);
                        
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countriesAgentTransaction"))
                    {                        
                        countriesPerAgentItem.Transactions = td.InnerText;                        
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countriesAgentSendAmount"))
                    {
                        countriesPerAgentItem.SendAmount = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countriesAgentTotalHeader"))
                    {
                        countriesPerAgentModel.CountriesPerAgentTotal = new CountriesPerAgentTotal();
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countriesAgentTotalTransaction"))
                    {
                        countriesPerAgentModel.CountriesPerAgentTotal.Transactions = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countriesAgentTotalSendAmount"))
                    {
                        countriesPerAgentModel.CountriesPerAgentTotal.SendAmount = td.InnerText;
                        continue;
                    }
                    #endregion

                    #region CountryAndStatePerAgent

                    if (td.GetAttributeValue("class", "").Contains("countryAndStatePerAgent"))
                    {
                        countryAndStatePerAgentModel = new CountryAndStatePerAgentModel();
                        dailyBusiness.CountryAndStatePerAgentModel.Add(countryAndStatePerAgentModel);
                        countryAndStatePerAgentModel.Model = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countryAndStateAgentItem1"))
                    {
                        countryAndStatePerAgentItem = new CountryAndStatePerAgentItem();
                        countryAndStatePerAgentItem.Country = td.InnerText;
                        countryAndStatePerAgentModel.Item.Add(countryAndStatePerAgentItem);
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countryAndStateAgentItem2"))
                    {
                        countryAndStatePerAgentItem.State = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countryAndStateAgentTransaction"))
                    {
                        countryAndStatePerAgentItem.Transactions = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countryAndStateAgentSendAmount"))
                    {
                        countryAndStatePerAgentItem.SendAmount = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countryAndStateAgentTotalHeader"))
                    {
                        countryAndStatePerAgentModel.CountryAndStatePerAgentTotal = new CountryAndStatePerAgentTotal();                        
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countryAndStateAgentTotalTransaction"))
                    {
                        countryAndStatePerAgentModel.CountryAndStatePerAgentTotal.Transactions = td.InnerText;
                        continue;
                    }

                    if (td.GetAttributeValue("class", "").Contains("countryAndStateAgentTotalSendAmount"))
                    {
                        countryAndStatePerAgentModel.CountryAndStatePerAgentTotal.SendAmount = td.InnerText;
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
