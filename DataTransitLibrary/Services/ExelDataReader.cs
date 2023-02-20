using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Metadata;
using DataTransitLibrary.Interfaces;
using DataTransitLibrary.Models;
using OfficeOpenXml;

namespace DataTransitLibrary.Services
{
    public class ExelDataReader : IDataReader
    {
        public ExelDataReader()
        {
        }

        public List<string> ReadData(string filePath)
        {
            List<string> worksheetData = new List<string>();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[1];
                if (worksheet != null)
                {
                    for (int row = 1; row <= worksheet.Dimension.Rows; row++)
                    {
                        for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                        {
                            string cellValue = worksheet.Cells[row, col].Value?.ToString();
                            worksheetData.Add(cellValue);
                        }
                    }
                }
                return worksheetData;
            }
        }
    }
}

