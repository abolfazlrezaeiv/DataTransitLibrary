using DataTransitLibrary.Interfaces;
using DataTransitLibrary.Models;
using System;

namespace DataTransitLibrary.Services
{
    public class TransferServiceFactory
    {
        public IDataTransferService GetTransferService(TransferTask transferTask)
        {
            switch (transferTask.TransferType)
            {
                case TransferType.ExcelToSql:
                    return new BatchDataTransferService(new ExcelDataReader(), new SqlDataWriter());
                case TransferType.ExcelToRedisToSql:
                    return new BatchDataTransferService(new ExcelDataReader(), new RedisDataWriter());
                case TransferType.SqlToSql:
                    return new MultithreadedDataTransferService(new SqlDataReader(), new SqlDataWriter());
                default:
                    throw new NotSupportedException($"Transfer type {transferTask.TransferType} is not supported.");
            }
        }
    }
}
