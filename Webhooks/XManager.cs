using System;
using System.IO;
using System.Xml.Linq;

namespace Webhooks
{
    public class XManager
    {
        private readonly string settingsFile;

        public XManager(string settingsFile)
        {
            this.settingsFile = settingsFile;
        }

        public string Load()
        {
            if (File.Exists(settingsFile))
            {
                try
                {
                    XElement root = XElement.Load(settingsFile);
                    return root.Element("URL")?.Value ?? string.Empty;
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while loading settings: {ex.Message}", ex);
                }
            }
            else
            {
                throw new FileNotFoundException("Settings file not found.");
            }
        }

        public void Save(string url)
        {
            // Create XML with URL value
            XElement root = new XElement("Root",
                new XElement("URL", url)
            );

            try
            {
                root.Save(settingsFile);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while saving settings: {ex.Message}", ex);
            }
        }
    }
}
