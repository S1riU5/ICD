using System;
using System.Security.Cryptography.X509Certificates;

namespace ICD
{
    public interface IParser
    {
        DataSet parse(String line);
    }
}