using DataTransitLibrary.Interfaces;
using DataTransitLibrary.Models;
using System.Collections.Generic;

namespace DataTransitLibrary.Services
{
 public class DataTransferService : IDataTransferService
    {
        private readonly IDataReader _dataReader;
        private readonly IDataWriter _dataWriter;

        public DataTransferService(IDataReader dataReader, IDataWriter dataWriter)
        {
            _dataReader = dataReader;
            _dataWriter = dataWriter;
        }

        public TransferResult TransferData(TransferTask transferTask)
        {
            var transferResult = new TransferResult();




            // Read data from source
            List<string> data = _dataReader.ReadData(transferTask.SourceFilePath);

          
           
            // Write data to destination
            bool writeSuccess = _dataWriter.WriteData(data, transferTask.SqlConnectionString);

            // Update the transfer result
            transferResult.Successful = writeSuccess;

            return transferResult;
        }

    }
}