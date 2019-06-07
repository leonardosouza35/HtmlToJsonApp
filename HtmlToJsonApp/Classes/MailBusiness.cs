using System.Collections.Generic;

namespace HtmlToJsonApp
{
    public class MailBusiness
    {
        public List<Section> Sections { get; set; }        
        public MailBusiness()
        {
            Sections = new List<Section>();            
        }
    }


    
}
