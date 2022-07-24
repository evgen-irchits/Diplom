using Script.Interface;
using UnityEngine;

namespace Script.Service
{
    public class SaveService : ISaveService
    {
        private ISaveService _saveServisImplementation;

        public void Write(object obj, string name)
        {
            var json = JsonUtility.ToJson(obj);
            PlayerPrefs.SetString(name,json);
        }

        public T Load<T>(string name)
        {
			
            if (PlayerPrefs.HasKey(name))
            {
                var json = PlayerPrefs.GetString(name);

                if (json == null)
                    return default;
                return JsonUtility.FromJson<T>(json);
            }

            return default;
        }

        public void Save()
        {
            PlayerPrefs.Save();
        }

    }

    public static class SaveServiceExtension
    {
        public static T Load<T>(this ISaveService self)
        {
            return self.Load<T>(nameof(T));
        }

        public static void Write<T>(this ISaveService self, T obj)
        {
            self.Write(obj, nameof(T));
        }
    }

}