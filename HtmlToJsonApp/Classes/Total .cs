using System.Collections.Generic;

namespace HtmlToJsonApp
{
    public class Total
    {
        public List<Year> Years { get; set; }

        public Total()
        {
            Years = new List<Year>();
        }
    }
}
