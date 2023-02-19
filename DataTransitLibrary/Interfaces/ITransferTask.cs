using DataTransitLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransitLibrary.Interfaces
{
    public interface ITransferTask
    {
        TransferType TransferType { get; set; }
        string SourceFilePath { get; set; }
        string RedisKey { get; set; }
        string SqlConnectionString { get; set; }
    }
}
