using System;
using System.Collections.Generic;
using QAFoodBank.Models;

namespace QAFoodBank
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Picture { get; set; }
        public bool Urgent { get; set; }
        public List<Vendor> SourceUrls { get; set; }
    }
}
