using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
namespace MestoOpravaV2.Utils
{
    class StorageManager
    {
        private string path;
        public StorageManager(string fileName)
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
        }
        public bool CheckFile()
        {
            return File.Exists(this.path);
        }
        public bool WriteFile(Dictionary<string,string> data)
        {
            string content = JsonConvert.SerializeObject(data);
            try
            {
                using (StreamWriter sw = new StreamWriter(this.path))
                {
                    sw.WriteLine(content);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Dictionary<string, string> ReadFile()
        {
            string content = "";
            Dictionary<string, string> data = null;
            if (CheckFile())
            {
                using (StreamReader sr = new StreamReader(this.path))
                {
                    content = sr.ReadLine();
                }
                data = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
            }
            return data;
        }

    }
}
