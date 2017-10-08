using System;
using System.Collections.Generic;
using QAFoodBank.Models;

namespace QAFoodBank
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemCategory Category { get; set; }
        public string Picture { get; set; }
        public bool Urgent { get; set; }
        public List<Vendor> SourceUrls { get; set; }
    }
}
