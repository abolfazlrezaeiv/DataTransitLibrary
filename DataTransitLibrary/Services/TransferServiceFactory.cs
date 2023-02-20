using DataTransitLibrary.Interfaces;
using DataTransitLibrary.Models;
using System;

namespace DataTransitLibrary.Services
{
    public class TransferServiceFactory
    {
        public IDataTransferService GetTransferService(TransferTask transferTask)
        {
            if (transferTask.TransferType == TransferType.ExcelToRedis)
            {
                return new DataTransferService(new ExcelDataReader(), new RedisDataWriter());

            }
            if (transferTask.TransferType == TransferType.ExcelToSql)
            {

            }
            if (transferTask.TransferType == TransferType.ExcelToRedisToSql)
            {

            }
            if (transferTask.TransferType == TransferType.SqlToExcel)
            {

            }
            if (transferTask.TransferType == TransferType.SqlToRedis)
            {

            }
            if (transferTask.TransferType == TransferType.SqlToRedisToExcel)
            {

            }
            throw new DataTransferException("No transfer type is specfied !");
        }
    }
}
