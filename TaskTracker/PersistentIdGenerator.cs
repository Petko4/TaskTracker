using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker
{
    internal class PersistentIdGenerator
    {
        private string _path;

        public PersistentIdGenerator(string path) 
        { 
            this._path = path;
        }

        public int GetNewId()
        {
            int lastId = GetLastId();
            int newId = ++lastId;
            SaveLastId(newId);

            return newId;
        }

        private int GetLastId()
        {
            int lastId = 0;

            if (File.Exists(this._path))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(this._path))
                    {
                        string? firstLine = reader.ReadLine();
                        int.TryParse(firstLine, out lastId);
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return lastId;
        }

        private void SaveLastId(int lastId)
        {
            using (StreamWriter writer = new StreamWriter(this._path))
            {
                writer.WriteLine(lastId.ToString());
            }
        }
    }
}
