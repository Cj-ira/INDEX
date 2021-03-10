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
        public string Name { get => ""; set => _ = value; }
        public string Author { get => "NillByte"; set => _ = value; }
        public string Version { get => "0.0.1"; set => _ = value; }

        public void Start()
        {
            Console.WriteLine($"Started, {Name} by {Author} version {Version}");
        }

        public void Dispose()
        {
            Console.WriteLine($"Stopped, {Name} by {Author} version {Version}");
        }

        public void Pause()
        {
        }

        public void Resume()
        {
        }
    }
}
