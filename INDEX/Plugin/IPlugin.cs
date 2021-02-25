using System;
using System.Collections.Generic;
using System.Text;

namespace INDEX.Plugin
{
    public interface IPlugin
    {
        string Name { get; set; }
        string Author { get; set; }
        string Version { get; set; }

        void Start();
        void Stop();
    }
}
