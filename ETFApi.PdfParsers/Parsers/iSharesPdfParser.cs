using System;
using System.Collections.Generic;
using ETFApi.Domain.Entities;

namespace ETFApi.PdfParsers.Parsers
{
    public class iSharesPdfParser : PdfParser
    {
        public iSharesPdfParser(byte[] pdfBytes) : base(pdfBytes)
        {
        }

        protected override List<KeyValuePair<string, (string, string)>> ContentParts { get; set; } = new()
        {
            new KeyValuePair<string, (string, string)>("", ("", ""))
        };

        private protected override Etf ParseContentToEtfObject()
        {
            throw new NotImplementedException();
        }
    }
}