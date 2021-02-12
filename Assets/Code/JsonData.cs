using System.IO;
using UnityEngine;


namespace GeekBrains
{
    public class JsonData<T> : IData<T>
    {
        public T Load(string path = null)
        {
            var str = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(Crypto.CryptoXOR(str));
        }

        public void Save(T data, string path = null)
        {
            var str = JsonUtility.ToJson(data);
            File.WriteAllText(path, Crypto.CryptoXOR(str));
        }
    }
}