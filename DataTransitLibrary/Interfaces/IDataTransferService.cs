using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataTransitLibrary.Models;

namespace DataTransitLibrary.Interfaces
{
    public interface IDataTransferService
    {
        TransferResult TransferData(TransferTask transferTask);
    }
}