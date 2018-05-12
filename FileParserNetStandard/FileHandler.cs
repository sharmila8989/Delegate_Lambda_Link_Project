using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

using System.Runtime.CompilerServices;

namespace FileParserNetStandard {
    public class FileHandler {
       
        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) {

            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] linesarray = System.IO.File.ReadAllLines(filePath);
            //convert array of strings to List<string>
            List<string> lines = new List<string>(linesarray);
            //return list
            return lines;
        }

        
        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows) {

            List<string> Lines = new List<string>();
            foreach (List<string> ls in rows)
            {
             string str = String.Join(delimeter.ToString(), ls.ToArray());
                Lines.Add(str);
            }
            string[] writeLines = Lines.ToArray();
            System.IO.File.WriteAllLines(filePath, writeLines);

        }
        
        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimeter) {
            return data.Select(e => e.Split(delimeter).ToList()).ToList(); //-- return result here
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data) {

            return data.Select(e => e.Split(',').ToList()).ToList();

            //-- return result here
        }

        

    }
}