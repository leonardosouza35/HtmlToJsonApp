namespace HtmlToJsonApp.Model.DailyBusinessModel
{
    public class BusinessType
    {
        public string Name { get; set; }
        public string Transactions { get; set; }
        public string SendAmount { get; set; }

        public BusinessType(string name)
        {
            this.Name = name;
        }
    }
}
