using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskTracker
{
    internal class TaskFileStorage
    {
        private string _path;
        public TaskFileStorage(string path) 
        { 
            _path = path;
        }

        public List<Task> LoadTasksFromJSONFile()
        {
            List<Task>? tasks = null;

            if (File.Exists(_path)) {
                try
                {
                    string json = File.ReadAllText(_path);

                    tasks = JsonSerializer.Deserialize<List<Task>>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

             }

            if (tasks == null) {
                return new List<Task>();
            }
            return tasks;
        }

        public void SaveTasks(List<Task> tasks) {

            try
            {
                JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(tasks, jsonOptions);

                File.WriteAllText(_path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        
        }
    }
}
