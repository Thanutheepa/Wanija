using System;
using System.Collections.Generic;
using Microsoft.JSInterop;
using OfficeOpenXml;
using System.Linq;
using System.Threading.Tasks;
using MotherSLAdmin.Models;

namespace MotherSLAdmin.Data
{
    public class ExcelDownloadForReports_T
    {

        public void ReportRenewalReportInvoice1(List<OutletProduct> dataList, IJSRuntime iJSRuntime)
        {
            string[] header = { "OutletId", "ItemId", "Item Name", "Current Stock" };
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");

                for (int i = 0; i < header.Length; i++)
                {

                    workSheet.Cells[1, i + 1].Value = header[i];
                }


                int r = 2;
                foreach (var data in dataList)
                {
                    workSheet.Cells[r, 1].Value = data.OutletId;
                    workSheet.Cells[r, 2].Value = data.ItemId;
                    workSheet.Cells[r, 3].Value = data.product.name;
                    workSheet.Cells[r, 4].Value = data.CurrentStock;

                    r += 1;
                }

                fileContents = package.GetAsByteArray();

            }

            iJSRuntime.InvokeAsync<ExcelDownloadForReports_T>(
                "saveAsFile",
                "ReportInvoice.xlsx",
                Convert.ToBase64String(fileContents)
            );
            /*iJSRuntime.InvokeAsync<>(
                "saveAsFile",
                "ReportInvoice.xlsx",
                Convert.ToBase64String(fileContents)
            );*/
        }
    }
}
