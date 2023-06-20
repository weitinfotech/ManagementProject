using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;

namespace DocumentAIScanner
{
    public class Layout_Model
    {
        static string endpoint = "https://formreconservice.cognitiveservices.azure.com/";
        static string key = "bc93110f53374d899bcadbe485bd1237";
        static AzureKeyCredential credential = new AzureKeyCredential(key);
        DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(endpoint), credential);

        //sample document
    }
}
