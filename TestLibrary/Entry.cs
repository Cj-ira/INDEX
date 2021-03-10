using INDEX.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class Entry : IPlugin
    {
        // I don't care about any problematic code smells that this may have because this is just a test plugin.
        public PluginData pluginData { get => new PluginData("TestLibrary", "Cj-ira", "0.0.2"); set => _ = value; }

        public void Start()
        {
            Console.WriteLine($"Started, {pluginData.Name} by {pluginData.Author} version {pluginData.Version}");
        }

        public void Dispose()
        {
            Console.WriteLine($"Stopped, {pluginData.Name} by {pluginData.Author} version {pluginData.Version}");
        }

        public void Pause()
        {
        }

        public void Resume()
        {
        }
    }
}
