﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ClassLibrary
{
    public interface IFileManager
    {
        string Content { get; }
        string FilePath { set; }
        string[] Alternatives { get; }
        string[] StringMatrix { get; }
        void WriteAlternatives();
        void WriteStringMatrix();
        void SaveContent(string content);
        bool isExist();
    }
    public class FileManager: IFileManager
    {
        string filePath = "alternative.txt";
        
        string[] alternatives;
        string[] stringMatrix;

        public void WriteAlternatives()
        {
            alternatives = File.ReadAllLines(filePath, Encoding.GetEncoding(1251));
        }
        public void WriteStringMatrix()
        {
            stringMatrix = File.ReadAllLines(filePath, Encoding.GetEncoding(1251));
        }
        public string[] Alternatives
        {
            get { return alternatives; }
        }
        public string[] StringMatrix
        {
            get { return stringMatrix; }
        }
        public string Content
        {
            get { return File.ReadAllText(filePath, Encoding.GetEncoding(1251)); }
        }
        public string FilePath
        {
            set { filePath = value; }
        }
        public void SaveContent(string content)
        {
            File.WriteAllText(filePath, content, Encoding.GetEncoding(1251));
        }
        public bool isExist()
        {
            return File.Exists(filePath);
        }
        public FileManager()
        {
            WriteAlternatives();
        }

    }
}
