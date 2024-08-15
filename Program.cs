using AssetTrackingEF.Enums;
using AssetTrackingEF.Helpers;
using AssetTrackingEF.Models;
using AssetTrackingEF.Services;

namespace AssetTrackingEF
{
    internal class Program
    {
        static AssetService _assetService = new AssetService();
        static OfficeService _oService = new OfficeService();
        static void Main(string[] args)
        {
            while (true) 
            {
                _oService.AddOfficeList();
                RunApplication();
            }

        }

        private static void RunApplication()
        {
            var input = ConsoleHelper.ConsoleWrite($"Welcome! Press (1) to show assetlist, (2) to add asset, (3) to update asset, (4) to delete asset");
            try
            {
                switch (input)
                {
                    case "1":
                        _assetService.GetAssets();
                        break;
                    case "2":
                        _assetService.AddAsset();
                        break;
                    case "3":
                        var assetId = ConsoleHelper.ConsoleWrite($"AssetId: ");
                        _assetService.UpdateAsset(int.Parse(assetId));
                        break;
                    case "4":
                         assetId = ConsoleHelper.ConsoleWrite($"AssetId: ");
                        _assetService.DeleteAsset(int.Parse(assetId));
                        break;
                }
            }
            catch (Exception ee)
            {
                ConsoleHelper.ConsoleWrite($"Something went wrong: {ee.Message}", false, ConsoleColor.Red);
            }

        }

    }
}