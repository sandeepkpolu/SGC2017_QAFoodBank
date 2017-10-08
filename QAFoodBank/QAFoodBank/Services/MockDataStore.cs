using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QAFoodBank
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;
        Company company;

        public MockDataStore()
        {
            company = new Company();
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item {
                    ItemId = 1,
                    ItemName = "Chicken soup",
                    Description ="Any chicken soup, small cans.",
                    CategoryName = ItemCategory.Food.ToString(),
                    CategoryId = ItemCategory.Food.GetHashCode(),
                    Picture = "food_icon.png",
                    Urgent = false,
                    SourceUrls = new List<Models.Vendor>() {
                        new Models.Vendor() {
                            Name = "Amazon",
                            Url = "https://www.amazon.com/s/ref=nb_sb_noss_1?url=search-alias%3Daps&field-keywords=chicken+soup+cans"
                        },
						new Models.Vendor() {
							Name = "Target",
							Url = "https://www.target.com/s?searchTerm=chicken+soup"
						}
                    }

                },
                new Item {
                    ItemId = 2,
                    ItemName = "Chili & Beans",
                    Description ="Any chili, small cans.",
                    CategoryName = ItemCategory.Clothes.ToString(),
                    CategoryId = ItemCategory.Clothes.GetHashCode(),
                    Picture = "food_icon.png",
					Urgent = true,
					SourceUrls = new List<Models.Vendor>() {
						new Models.Vendor() {
							Name = "Amazon",
							Url = "https://www.amazon.com/s/ref=nb_sb_noss?url=search-alias%3Daps&field-keywords=Chili+%26+Beans"
						},
						new Models.Vendor() {
							Name = "Target",
							Url = "https://www.target.com/s?searchTerm=Chili+%26+Beans"
						}
					}
                },
                new Item {
                    ItemId = 3,
                    ItemName = "Green beans",
                    Description ="Any green beans, small cans.",
                    CategoryName = ItemCategory.Food.ToString(),
                    CategoryId = ItemCategory.Food.GetHashCode(),
                    Picture = "food_icon.png",
                    Urgent = false,
					SourceUrls = new List<Models.Vendor>() {
						new Models.Vendor() {
							Name = "Amazon",
							Url = "https://www.amazon.com/s/ref=nb_sb_noss_2?url=search-alias%3Daps&field-keywords=green+beans&rh=i%3Aaps%2Ck%3Agreen+beans"
						},
						new Models.Vendor() {
							Name = "Target",
							Url = "https://www.target.com/s?searchTerm=green+beans"
						}
					}
                }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
