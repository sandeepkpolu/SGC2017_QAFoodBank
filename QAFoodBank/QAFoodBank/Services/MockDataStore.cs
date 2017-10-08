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
                    Id = Guid.NewGuid().ToString(),
                    Name = "Chicken soup",
                    Description ="Any chicken soup, small cans.",
                    Category = ItemCategory.Food,
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
                    Id = Guid.NewGuid().ToString(),
                    Name = "Chili & Beans",
                    Description ="Any chili, small cans.",
                    Category = ItemCategory.Food,
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
                    Id = Guid.NewGuid().ToString(),
                    Name = "Green beans",
                    Description ="Any green beans, small cans.",
                    Category = ItemCategory.Food,
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

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
