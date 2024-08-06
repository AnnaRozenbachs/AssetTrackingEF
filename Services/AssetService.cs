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
        private double threeYearsInDays = (3 * 365);

        public void AddAsset()
        {
            var brand = ConsoleHelper.ConsoleWrite($"Brand: ");
            var model = ConsoleHelper.ConsoleWrite($"Model: ");
            var price = ConsoleHelper.ConsoleWrite($"Price: ");
            var purchaseDate = ConsoleHelper.ConsoleWrite($"PurchaseDate: ");
            var assetType = ConsoleHelper.ConsoleWrite($"Choose AssetType: Phone ({(int)AssetType.phone}) Computer ({(int)AssetType.computer})");
            var office = ConsoleHelper.ConsoleWrite($"Choose Office: " +
                                      $"Spain ({(int)OfficePlaces.spain}) " +
                                      $"England ({(int)OfficePlaces.england}) " +
                                      $"Sweden ({(int)OfficePlaces.sweden}) " +
                                      $"USA ({(int)OfficePlaces.usa})");
            Asset asset = new Asset(brand, model, decimal.Parse(price), DateTime.Parse(purchaseDate), int.Parse(assetType), int.Parse(office));
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

                var threeMonthsIntervall = (DateTime.Now.AddMonths(3) - asset.PurchaseDate).TotalDays;
                var sixMonthsIntervall = (DateTime.Now.AddMonths(6) - asset.PurchaseDate).TotalDays;

                ConsoleColor color = threeMonthsIntervall >= threeYearsInDays ? ConsoleColor.Red : 
                                     sixMonthsIntervall >= threeYearsInDays ? ConsoleColor.Yellow: 
                                     ConsoleColor.White; 

                ConsoleHelper.ConsoleWrite(
                    $"{asset.Id.ToString().PadRight(10)}" +
                    $"{asset.Brand.ToString().PadRight(20)} " +
                    $"{asset.Model.ToString().PadRight(10)}" +
                    $"{assetType.ToString().PadRight(15)}" +
                    $"{asset.PurchaseDate.ToString("yyyy-MM-dd").PadRight(15)} " +
                    $"{price.ToString().PadRight(10)} " +
                    $"{asset.Office.Currency.ToString().PadRight(10)} " +
                    $"{asset.Office.Country.ToString()}", false, color);
            }
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
                var input = ConsoleHelper.ConsoleWrite($"Update (1) Brand, (2) Model, (3) AssetType, (4) PurchaseDate, (5) Price, (6) Office");
                switch (input)
                {
                    case "1":
                        input = ConsoleHelper.ConsoleWrite($"Update Brand: ");
                        asset.Brand = input;
                        break;
                    case "2":
                        input = ConsoleHelper.ConsoleWrite($"Update Model: ");
                        asset.Model = input;
                        break;
                    case "3":
                        input = ConsoleHelper.ConsoleWrite($"Update AssetType: Phone ({(int)AssetType.phone}) Computer ({(int)AssetType.computer})");
                        asset.AssetType = int.Parse(input);
                        break;
                    case "4":
                        input = ConsoleHelper.ConsoleWrite($"Update PurchaseDate: ");
                        asset.PurchaseDate = DateTime.Parse(input);
                        break;
                    case "5":
                        input = ConsoleHelper.ConsoleWrite($"Update Price: ");
                        asset.Price = decimal.Parse(input);
                        break;
                    case "6":
                        input = ConsoleHelper.ConsoleWrite($"Update Office: " +
                                          $"Spain ({(int)OfficePlaces.spain}) " +
                                          $"England ({(int)OfficePlaces.england}) " +
                                          $"Sweden ({(int)OfficePlaces.sweden}) " +
                                          $"USA ({(int)OfficePlaces.usa})");
                        asset.OfficeId = int.Parse(input);
                        break;
                    default:
                        break;
                }
                _assetRepository.Update(asset);
                ConsoleHelper.ConsoleWrite($"The asset has been updated", false, ConsoleColor.Green);
            }
           
        }
    }
}
