using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransitLibrary.Models
{
    public class TransferTask
    {
        public TransferType TransferType { get; set; }
        public string SourceFilePath { get; set; }
        public string RedisKey { get; set; }
        public string SqlConnectionString { get; set; }
    }
}
