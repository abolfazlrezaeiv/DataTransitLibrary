using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransitLibrary.Models
{
    public enum TransferType
    {
        ExcelToSql,
        ExcelToRedisToSql,
        SqlToExcel,
        SqlToRedisToExcel,
    }
}
