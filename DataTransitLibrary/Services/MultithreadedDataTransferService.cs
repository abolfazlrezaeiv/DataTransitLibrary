using System.Collections.Generic;
using System.Threading.Tasks;
using DataTransitLibrary.Interfaces;
using DataTransitLibrary.Models;

namespace DataTransitLibrary.Services
{
    public class MultithreadedDataTransferService : IDataTransferService
    {
        private readonly IDataReader _dataReader;
        private readonly IDataWriter _dataWriter;
        private readonly IImporter _importer;

        public MultithreadedDataTransferService(IDataReader dataReader, IDataWriter dataWriter, IImporter importer)
        {
            _dataReader = dataReader;
            _dataWriter = dataWriter;
            _importer = importer;
        }

        public TransferResult TransferData(TransferTask transferTask)
        {
            var transferResult = new TransferResult();

            // Read data from source
            List<TransferData> data = _dataReader.ReadData(transferTask.SourceFilePath);

            // Transform data if needed
        

            // Import data to destination
            bool importSuccess = ImportData(data, transferTask);

            // Update the transfer result
            transferResult.Successful = importSuccess;

            return transferResult;
        }

        private List<TransferData> TransformDataExcelToCsv(List<TransferData> data)
        {
            // TODO: Transform data as needed for Excel to CSV transfer
            return data;
        }

        private bool ImportData(List<TransferData> data, TransferTask transferTask)
        {
            var tasks = new List<Task<bool>>();
            for (int i = 0; i < transferTask.ThreadCount; i++)
            {
                var dataPartition = PartitionData(data, i, transferTask.ThreadCount);
                tasks.Add(Task.Run(() => _importer.ImportData(dataPartition, transferTask.SourceFilePath)));
            }

            Task.WaitAll(tasks.ToArray());

            bool allSucceeded = true;
            foreach (var task in tasks)
            {
                if (!task.Result)
                {
                    allSucceeded = false;
                }
            }

            return allSucceeded;
        }

        private List<TransferData> PartitionData(List<TransferData> data, int partitionIndex, int partitionCount)
        {
            var partitionedData = new List<TransferData>();
            for (int i = partitionIndex; i < data.Count; i += partitionCount)
            {
                partitionedData.Add(data[i]);
            }
            return partitionedData;
        }
    }
}
