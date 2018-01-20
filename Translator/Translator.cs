using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

namespace Translator
{
    public class Translator : MonoBehaviour
    {
        private string DefaultLanguage = "en";
        private string Language;

        private Dictionary<string, Dictionary<string, string>> i18n =
            new Dictionary<string, Dictionary<string, string>>();

        private void Start()
        {
            Language = getLanguage();
            string filePath = Path.Combine(Application.streamingAssetsPath, "i18n.json");
            string jsonData;
            if (Application.platform == RuntimePlatform.Android) {
                WWW reader = new WWW(filePath);
                while (!reader.isDone) {
                }

                jsonData = reader.text;
            }
            else {
                jsonData = File.ReadAllText(filePath);
            }

            List<Row> rows = JsonUtility.FromJson<Serialization<Row>>(jsonData).ToList();

            Dictionary<string, string> translations;
            foreach (var row in rows) {
                translations = new Dictionary<string, string>();
                foreach (var translation in row.target) {
                    translations[translation.lang] = translation.translation;
                }

                i18n[row.key] = translations;
            }
        }

        public string Translate(string key)
        {
            if (!i18n.ContainsKey(key)) {
                Debug.LogError("Translation " + key + " does not exist");
                return key;
            }

            if (!i18n[key].ContainsKey(Language) || i18n[key][Language] == "") {
                return i18n[key][DefaultLanguage];
            }

            return i18n[key][Language];
        }


        public string getLanguage()
        {
            SystemLanguage lang = Application.systemLanguage;

            switch (lang) {
                case SystemLanguage.Afrikaans:
                    return "af";
                case SystemLanguage.Arabic:
                    return "ar";
                case SystemLanguage.Basque:
                    return "eu";
                case SystemLanguage.Belarusian:
                    return "by";
                case SystemLanguage.Bulgarian:
                    return "bg";
                case SystemLanguage.Catalan:
                    return "ca";
                case SystemLanguage.Chinese:
                    return "zh";
                case SystemLanguage.Czech:
                    return "cs";
                case SystemLanguage.Danish:
                    return "da";
                case SystemLanguage.Dutch:
                    return "nl";
                case SystemLanguage.English:
                    return "en";
                case SystemLanguage.Estonian:
                    return "et";
                case SystemLanguage.Faroese:
                    return "fo";
                case SystemLanguage.Finnish:
                    return "fi";
                case SystemLanguage.French:
                    return "fr";
                case SystemLanguage.German:
                    return "de";
                case SystemLanguage.Greek:
                    return "el";
                case SystemLanguage.Hebrew:
                    return "iw";
                case SystemLanguage.Hungarian:
                    return "hu";
                case SystemLanguage.Icelandic:
                    return "is";
                case SystemLanguage.Indonesian:
                    return "in";
                case SystemLanguage.Italian:
                    return "it";
                case SystemLanguage.Japanese:
                    return "ja";
                case SystemLanguage.Korean:
                    return "ko";
                case SystemLanguage.Latvian:
                    return "lv";
                case SystemLanguage.Lithuanian:
                    return "lt";
                case SystemLanguage.Norwegian:
                    return "no";
                case SystemLanguage.Polish:
                    return "pl";
                case SystemLanguage.Portuguese:
                    return "pt";
                case SystemLanguage.Romanian:
                    return "ro";
                case SystemLanguage.Russian:
                    return "ru";
                case SystemLanguage.SerboCroatian:
                    return "sh";
                case SystemLanguage.Slovak:
                    return "sk";
                case SystemLanguage.Slovenian:
                    return "sl";
                case SystemLanguage.Spanish:
                    return "es";
                case SystemLanguage.Swedish:
                    return "sv";
                case SystemLanguage.Thai:
                    return "th";
                case SystemLanguage.Turkish:
                    return "tr";
                case SystemLanguage.Ukrainian:
                    return "uk";
                case SystemLanguage.Vietnamese:
                    return "vi";
                default:
                    return DefaultLanguage;
            }
        }
    }

    [Serializable]
    public class Row
    {
        [SerializeField] public string key;
        [SerializeField] public Translations[] target;
    }

    [Serializable]
    public class Translations
    {
        [SerializeField] public string lang;
        [SerializeField] public string translation;
    }

    [Serializable]
    public class Serialization<T>
    {
        [SerializeField] List<T> target;

        public List<T> ToList()
        {
            return target;
        }

        public Serialization(List<T> target)
        {
            this.target = target;
        }
    }
}