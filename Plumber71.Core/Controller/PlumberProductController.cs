﻿using System.Linq;
using System.Threading.Tasks;
using Plumber71.Core.Service.JsonFileService;
using Plumber71.Core.Service.Woocomerce;

namespace Plumber71.Core.Controller
{
    public class PlumberProductController
    {
        private readonly ProductsDownloader productsDownloader;
        public PlumberProductController(WooClient wooClient)
        {
            productsDownloader = new ProductsDownloader(wooClient);
        }

        public async Task LoadOnDevice()
        {
            // Кеширование товаров
            var chacheProducts = await productsDownloader.DownloadAll();
            //ЧАчапури под лодочкой
            JsonFileStorage.Save(chacheProducts.ToList());
        }
    }
}
