using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace BankHelper.Configuration
{
    public class BankConfigurationHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            Dictionary<string, Dictionary<string, string>> mappingBankClasses = new Dictionary<string, Dictionary<string, string>>();
            if (section.HasChildNodes)
            {
                foreach (XmlNode child in section.ChildNodes)
                {
                    if (!mappingBankClasses.ContainsKey(child.Name.ToLower()))
                    {
                        mappingBankClasses.Add(child.Name, new Dictionary<string, string>());
                    }
                    foreach (XmlNode childAdd in child.ChildNodes)
                    {
                        if (childAdd.Name.ToLower() == "add")
                        {
                            mappingBankClasses[child.Name].Add(childAdd.Attributes["interface"].Value, childAdd.Attributes["class"].Value);
                            mappingBankClasses[child.Name].Add(childAdd.Attributes["interface"].Value + ".Value", childAdd.Attributes["value"].Value);
                        }
                    }
                }
            }
            return mappingBankClasses;
        }
    }
}