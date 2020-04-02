using System.Collections.Generic;
using System.IO;
using Users.Service.Managment.Application.Common.Interfaces;

namespace Users.Service.Managment.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        //public byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var streamWriter = new StreamWriter(memoryStream))
        //        using (var csvWriter = new CsvWriter(streamWriter))
        //        {
        //            csvWriter.Configuration.RegisterClassMap<ProductFileRecordMap>();
        //            csvWriter.WriteRecords(records);
        //        }

        //        return memoryStream.ToArray();
        //    }
        //}
    }
}
