using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace ICD
{
    public interface IParser
    {
        List<DataSet> ParseIcdCatalog (string icdStringList);
    }
}