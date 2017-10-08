﻿using QAFoodBank.MobileAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QAFoodBank.MobileAPI.Controllers
{
    public class ItemsController : ApiController
    {
        private QAFB_DBEntities db = new QAFB_DBEntities();

        public IEnumerable<QAFoodBankItem> Get()
        {
            var listOfItems = db.GetListOfItems().ToList();
            var items = new List<QAFoodBankItem>();
            foreach (var dbItem in listOfItems)
            {
                QAFoodBankItem item = new QAFoodBankItem();
                item.ItemId = dbItem.ItemId;
                item.ItemName = dbItem.ItemName;
                item.Description = dbItem.Description;
                item.Picture = dbItem.Picture;
                item.CategoryId = (int)dbItem.CategoryId;
                item.CategoryName = dbItem.CategoryName;
                item.Urgent = (bool)dbItem.Urgent;


                var sources = db.GetItemSources(item.ItemId);
                var soruceUrls = new List<Vendor>();

                foreach (var source in sources)
                {
                    soruceUrls.Add(new Vendor()
                    {
                        Name = source.Name,
                        Url = source.URL
                    });
                }
                item.SourceUrls = soruceUrls;
                items.Add(item);
            }
            return items;
        }
    }
}
