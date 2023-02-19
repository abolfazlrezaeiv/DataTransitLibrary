using DataTransitLibrary.Interfaces;
using DataTransitLibrary.Models;
using System.Collections.Generic;

namespace DataTransitLibrary.Services
{
 public class BatchDataTransferService : IDataTransferService
    {
        private readonly IDataReader _dataReader;
        private readonly IDataWriter _dataWriter;

        public BatchDataTransferService(IDataReader dataReader, IDataWriter dataWriter)
        {
            _dataReader = dataReader;
            _dataWriter = dataWriter;
        }

        public TransferResult TransferData(TransferTask transferTask)
        {
            var transferResult = new TransferResult();

            // Read data from source
            List<TransferData> data = _dataReader.ReadData(transferTask.SourceFilePath).ToList();

            // Transform data if needed
            if (transferTask.TransferType == TransferType.ExcelToRedisToSql)
            {
                // Transform Excel data to Redis data
                data = TransformDataExcelToRedis(data, transferTask.RedisKey);
            }

            // Write data to destination
            bool writeSuccess = _dataWriter.WriteData(data, transferTask.SqlConnectionString);

            // Update the transfer result
            transferResult.Successful = writeSuccess;

            return transferResult;
        }

        private List<TransferData> TransformDataExcelToRedis(List<TransferData> data, string redisKey)
        {
            // TODO: Transform data as needed for Excel to Redis transfer
            return data;
        }
    }
}