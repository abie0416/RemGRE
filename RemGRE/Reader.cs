using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace RemGRE
{
    class Reader
    {
        //public static Hashtable[] Read(String vocPath)
        //{
        //    try
        //    {
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        FileStream stream = new FileStream(vocPath, FileMode.Open);
        //        Hashtable[] allWords = (Hashtable[])formatter.Deserialize(stream);
        //        stream.Close();
        //        return allWords;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}
        public static Hashtable[] Read(byte[] bytes)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new MemoryStream(bytes);
                Hashtable[] allWords = (Hashtable[])formatter.Deserialize(stream);
                stream.Close();
                return allWords;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
