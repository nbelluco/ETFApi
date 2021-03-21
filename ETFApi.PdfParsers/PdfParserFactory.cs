using System;
using System.Collections.Generic;
using ETFApi.PdfParsers.Parsers;

namespace ETFApi.PdfParsers
{
    public class PdfParserFactory
    {
        private static readonly Dictionary<string, Func<byte[], PdfParser>> ConstructorsMap = new()
        {
            { "iShares", bytes => new iSharesPdfParser(bytes) }
        };
        
        public static PdfParser GetParser(string providerName, byte[] pdfBytesContent)
        {
            var constructor = ConstructorsMap[providerName];
            return constructor(pdfBytesContent);
        }
    }
}