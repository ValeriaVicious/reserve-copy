using System.IO;
using System.Xml;
using UnityEngine;


namespace GeekBrains
{
    public sealed class XMLData : IData<SavedData>
    {
        public SavedData Load(string path = "")
        {
            var result = new SavedData();

            if (!File.Exists(path))
            {
                return result;
            }

            using (var reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    var key = "Name";
                    if (reader.IsStartElement(key))
                    {
                        result.Name = reader.GetAttribute("value");
                    }

                    key = "PositionX";
                    if (reader.IsStartElement(key))
                    {
                        result.Position.X = reader.GetAttribute("value").TrySingle();
                    }

                    key = "PositionY";
                    if (reader.IsStartElement(key))
                    {
                        result.Position.Y = reader.GetAttribute("value").TrySingle();
                    }

                    key = "PositionZ";
                    if (reader.IsStartElement(key))
                    {
                        result.Position.Z = reader.GetAttribute("value").TrySingle();
                    }

                    key = "IsEnabled";
                    if (reader.IsStartElement(key))
                    {
                        result.IsEnabled = reader.GetAttribute("value").TryBool();
                    }

                }
            }
            return result;
        }

        public void Save(SavedData data, string path = "")
        {
            var xmlDocument = new XmlDocument();
            XmlNode rootNode = xmlDocument.CreateElement("Player");
            xmlDocument.AppendChild(rootNode);

            var element = xmlDocument.CreateElement("Name");
            element.SetAttribute("value", data.Name);
            rootNode.AppendChild(element);

            element = xmlDocument.CreateElement("PositionX");
            element.SetAttribute("value", data.Position.X.ToString());
            rootNode.AppendChild(element);

            element = xmlDocument.CreateElement("PositionY");
            element.SetAttribute("value", data.Position.Y.ToString());
            rootNode.AppendChild(element);

            element = xmlDocument.CreateElement("PositionZ");
            element.SetAttribute("value", data.Position.Z.ToString());
            rootNode.AppendChild(element);

            element = xmlDocument.CreateElement("IsEnabled");
            element.SetAttribute("value", data.IsEnabled.ToString());
            rootNode.AppendChild(element);

            XmlNode userNode = xmlDocument.CreateElement("Info");
            var attribute = xmlDocument.CreateAttribute("Unity");
            attribute.Value = Application.unityVersion;
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "System Language: " + Application.systemLanguage;
            rootNode.AppendChild(userNode);
            xmlDocument.Save(path);
        }
    }
}
