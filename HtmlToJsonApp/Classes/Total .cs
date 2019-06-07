using System.Collections.Generic;

namespace HtmlToJsonApp
{
    public class Total
    {
        public List<Year> Year { get; set; }

        public Total()
        {
            Year = new List<Year>();
        }
    }
}
