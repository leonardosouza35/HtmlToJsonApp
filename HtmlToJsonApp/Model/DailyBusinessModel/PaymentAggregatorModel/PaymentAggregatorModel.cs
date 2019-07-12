using System.Collections.Generic;

namespace HtmlToJsonApp.Model.DailyBusinessModel
{
    public class PaymentAggregatorModel
    {
        public List<PaymentAggregatorItem> Item { get; set; }
        public PaymentAggregatorTotal PaymentAggregatorTotal { get; set; }

        public PaymentAggregatorModel()
        {
            Item = new List<PaymentAggregatorItem>();            
        }
    }
}
