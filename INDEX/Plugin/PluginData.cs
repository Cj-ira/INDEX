using System;
using System.Collections.Generic;
using System.Text;

namespace INDEX.Plugin
{
    public struct PluginData
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Version { get; private set; }

        public PluginData(string name, string author, string version)
        {
            this.Name = name;
            this.Author = author;
            this.Version = version;
        }
    }
}
