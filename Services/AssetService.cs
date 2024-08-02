using AssetTrackingEF.Enums;
using AssetTrackingEF.Helpers;
using AssetTrackingEF.Models;
using AssetTrackingEF.Repositorys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Services
{
    public class AssetService : IAssetService
    {
        private AssetRepository _assetRepository = new AssetRepository();

        public void AddAsset()
        {
            Asset asset = SetValues();
            _assetRepository.Add(asset);
            ConsoleHelper.ConsoleWrite($"The asset is now added", false, ConsoleColor.Green);
        }

        public void DeleteAsset(int id)
        {
            var asset = _assetRepository.GetById(id);
            if (asset == null)
            {
                ConsoleHelper.ConsoleWrite($"The asset could not be found: {id}", false, ConsoleColor.Red);
            }
            else 
            {
                _assetRepository.Delete(asset);
                ConsoleHelper.ConsoleWrite($"The asset has been deleted", false, ConsoleColor.Green);
            }
        }

        public void GetAssets()
        {
            var assetList = _assetRepository.Get();
            foreach (var asset in assetList)
            {
                var price = Math.Round((asset.Price * asset.Office.Rate),2);
                var assetType = asset.AssetType == (int)AssetType.computer ? "Computer" : "Phone";

                var D = DateTime.Now.AddMonths(-3);
                var test = asset.PurchaseDate.AddYears(3);


                DateTime t = new DateTime(test.Ticks);

                ConsoleHelper.ConsoleWrite(
                    $"{asset.Id.ToString().PadRight(10)}" +
                    $"{asset.Brand.ToString().PadRight(10)} " +
                    $"{asset.Model.ToString().PadRight(10)}" +
                    $"{assetType.ToString().PadRight(15)}" +
                    $"{asset.PurchaseDate.ToString("yyyy-MM-dd").PadRight(15)} " +
                    $"{price.ToString().PadRight(10)} " +
                    $"{asset.Office.Currency.ToString().PadRight(10)} " +
                    $"{asset.Office.Country.ToString()}", false);
            }
        }

        public Asset SetValues(Asset asset = null)
        {
            var brand = ConsoleHelper.ConsoleWrite($"Brand: ");
            var model = ConsoleHelper.ConsoleWrite($"Model: ");
            var price = ConsoleHelper.ConsoleWrite($"Price: ");
            var purchaseDate = ConsoleHelper.ConsoleWrite($"PurchaseDate: ");
            var assetType = ConsoleHelper.ConsoleWrite($"Choose AssetType: Phone ({(int)AssetType.phone}) Computer ({(int)AssetType.computer})");
            var office = ConsoleHelper.ConsoleWrite($"Choose Office: " +
                                      $"Spain ({(int)OfficePlaces.spain})" +
                                      $"England ({(int)OfficePlaces.england})" +
                                      $"Sweden ({(int)OfficePlaces.sweden})" +
                                      $"USA ({(int)OfficePlaces.usa})");

            if (asset == null)
            {
                asset = new Asset(brand, model, decimal.Parse(price), DateTime.Parse(purchaseDate), int.Parse(assetType), int.Parse(office));
            }
            else 
            {
                asset.Brand = brand;
                asset.Model = model;
                asset.Price = decimal.Parse(price);
                asset.PurchaseDate = DateTime.Parse(purchaseDate);
                asset.AssetType = int.Parse(assetType);
                asset.OfficeId = int.Parse(office);
            }
            return asset;
        }

        public void UpdateAsset(int id)
        {
            var asset = _assetRepository.GetById(id);
            if (asset == null)
            {
                ConsoleHelper.ConsoleWrite($"The asset could not be found: {id}", false, ConsoleColor.Red);
            }
            else 
            {
                asset = SetValues(asset);
                _assetRepository.Update(asset);
                ConsoleHelper.ConsoleWrite($"The asset has been updated", false, ConsoleColor.Green);
            }
           
        }
    }
}
