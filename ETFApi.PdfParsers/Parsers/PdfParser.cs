using System;
using System.Collections.Generic;
using System.Text;
using ETFApi.Domain.Entities;
using UglyToad.PdfPig;

namespace ETFApi.PdfParsers.Parsers
{
    public abstract class PdfParser
    {
        private readonly byte[] _pdfBytes;
        protected abstract List<KeyValuePair<string, (string, string)>> ContentParts { get; set; }
        private Dictionary<string, string> ContentPairs { get; set; }

        protected PdfParser(byte[] pdfBytes)
        {
            _pdfBytes = pdfBytes;
        }
        
        public Etf ExtractContent()
        {
            using (var document = PdfDocument.Open(_pdfBytes))
            {
                var content = new StringBuilder();
                
                for (int i = 1; i < document.NumberOfPages + 1; i++)
                {
                    content.Append(document.GetPage(i));
                }
                
                ExtractContentPairs(content.ToString());
            }

            return ParseContentToEtfObject();
        }

        private void ExtractContentPairs(string content)
        {
            var parts = new Dictionary<string, string>();
            
            int currentIndex = 0;
            var currentSubstring = content.AsSpan(0, content.Length);

            for (int i = 0; i < ContentParts.Count; i++)
            {
                int start = currentSubstring.IndexOf(ContentParts[currentIndex].Value.Item1);
                int startLimiterLength = ContentParts[currentIndex].Value.Item1.Length; 
                int end = currentSubstring.IndexOf(ContentParts[currentIndex].Value.Item2);
            
                currentIndex += 1;
                if (start == -1 || end == -1) continue;
                
                parts.Add(
                    ContentParts[currentIndex].Key, 
                    currentSubstring
                        .Slice(start + startLimiterLength, end - start - startLimiterLength)
                        .ToString()
                    );
                
                currentSubstring = currentSubstring.Slice(end);
            }

            ContentPairs =  parts;
        }
        
        private protected abstract Etf ParseContentToEtfObject();

    }
}