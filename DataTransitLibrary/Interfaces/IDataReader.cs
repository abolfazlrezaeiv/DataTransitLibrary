using DataTransitLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransitLibrary.Interfaces
{
    public interface IDataReader
    {
        List<string> ReadData(string filePath);
    }
}
