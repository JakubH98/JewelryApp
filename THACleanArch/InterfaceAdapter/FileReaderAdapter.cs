using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THACleanArch.Application;
using THACleanArch.Domain;

namespace THACleanArch.InterfaceAdapter // FILE HANDLING
{
    public interface IFileReader
    {
        List<string> ReadAllLines(string filePath);
    }

    public class FileReaderAdapter : IFileReader
    {
        public List<string> ReadAllLines(string filePath)
        {
            var lines = new List<string>();

            using (var reader = new StreamReader("txtFiles/ItemsDB.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
    }
    public class FileItemRepos : IItemsRepository
    {
        private readonly IFileReader _fileReader;
       

        public FileItemRepos(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public List<Item> LoadItems()
        {
            var lines = _fileReader.ReadAllLines("txtFiles/ItemsDB.txt");
            var items = new List<Item>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var item = new Item(parts[0], parts[1], double.Parse(parts[2]));
                items.Add(item);
            }

            return items;
        }
    }
}
