using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;
using System.Linq;


public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise {

    //public delegate List<List<string>> process (List<List<string>> data);
    internal class Delegate_Exercise {
        public static void Main(string[] args) {

            string readFilePath = "/Users/sharm/Documents/data.csv";
            string writeFilePath = "/Users/sharm/Documents/process_data.csv";


           CsvHandler csvHan = new CsvHandler();
           DataParser dParser = new DataParser();
            //process p = new process(dParser.StripQuotes);
            Func<List<List<string>>, List<List<string>>> process = new Func<List<List<string>>, List<List<string>>>(dParser.StripQuotes);
            process += dParser.StripWhiteSpace;
            process += removeHashtag;
           csvHan.ProcessCsv(readFilePath, writeFilePath,process );

        }

      

        static List<List<string>> removeHashtag(List<List<string>> data)
        {
            return data.Select(l => l.Select(s => s.Replace("#", "")).ToList()).ToList();
        }



    }
}