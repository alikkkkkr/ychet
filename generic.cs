using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac4sharp
{
    class generic
    {
        public static T deserializ<T>(string p)
        {
            string json = File.ReadAllText(p);
            T json_text = JsonConvert.DeserializeObject<T>(json);
            return json_text;
        }

        public static void serializ<T>(T items_zametki, string p)
        {
            string json = JsonConvert.SerializeObject(items_zametki);
            File.WriteAllText(p, json);
        }
    }
}
