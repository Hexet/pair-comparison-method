using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace ClassLibrary
{
    public interface IMatrixManager
    {
        bool isExist(string filePath);
        string GetContent(string filePath);
    }
    public class MatrixManager: IMatrixManager
    {
        public bool isExist(string filePath)
        {
            return File.Exists(filePath);
        }
        public string GetContent(string filePath)
        {
            string content = File.ReadAllText(filePath, Encoding.GetEncoding(1251));
            return content;
        }
    }
}
