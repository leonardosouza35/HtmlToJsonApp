using System.Collections.Generic;

namespace HtmlToJsonApp.Model.DailyBusinessModel
{
    public class BusinessModel
    {
        public List<BusinessType> BusinessType { get; set; }
        public BusinessModelTotal BusinessModelTotal { get; set; }

        public BusinessModel()
        {
            BusinessType = new List<BusinessType>();
            BusinessModelTotal = new BusinessModelTotal();
        }

    }
}
