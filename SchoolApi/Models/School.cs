using System;

namespace SchoolApi.Models
{
    public class School
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string TradingName { get; set; }

        public string WebSite { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
