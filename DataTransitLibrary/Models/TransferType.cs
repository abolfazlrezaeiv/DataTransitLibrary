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
        SqlToRedis,
        ExcelToRedisToSql,
        CsvToSql,
        CsvToRedisToSql,
        ExcelToRedis
    }
}
