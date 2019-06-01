using System.Collections.Generic;

namespace HtmlToJsonApp
{
    public class MailBusiness
    {
        public List<Agent> Agents { get; set; }

        public MailBusiness()
        {
            Agents = new List<Agent>();
        }
    }


    
}
