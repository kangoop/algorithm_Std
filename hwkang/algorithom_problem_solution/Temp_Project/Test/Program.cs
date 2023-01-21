using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "qweasdzxc123";

            byte[] byte_arr = Encoding.UTF8.GetBytes(code);

            Console.WriteLine(byte_arr.Length);
        }

        public static void Binaray_Code(object code,string code_str)
        {
            BinaryFormatter bf = new BinaryFormatter();
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, code);
                bytes = ms.ToArray();
            }

            for(int i = 0; i < bytes.Length; i++)
            {
                Console.WriteLine($"{i + 1} : byte {bytes[i]}");
            }

            byte[] bytes_str = Encoding.UTF8.GetBytes(code_str);

            foreach (var item in bytes_str)
            {
                Console.WriteLine($"byte : {item}");
            }
        }


    }
}
