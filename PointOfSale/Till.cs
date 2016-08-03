﻿using System.Collections.Generic;

namespace PointOfSale
{
    public class Till
    {
        private readonly Screen _screen;
        private readonly Dictionary<string, string> _products;

        public Till(Screen screen, Dictionary<string, string> pricesByBarcode)
        {
            _screen = screen;
            _products = pricesByBarcode;
        }

        public void OnBarcode(string barcode)
        {
            if (barcode == string.Empty)
            {
                DisplayEmptyBarcodeMessage();
                return;
            }

            if (_products.ContainsKey(barcode))
                    DisplayPrice(barcode);
            else
                DisplayProductNotFoundMessage(barcode);
        }

        private void DisplayPrice(string barcode)
        {
            _screen.Print(_products[barcode]);
        }

        private void DisplayProductNotFoundMessage(string barcode)
        {
            _screen.Print(string.Format("Product not found for {0}", barcode));
        }

        private void DisplayEmptyBarcodeMessage()
        {
            _screen.Print("Barcode empty");
        }
    }
}