using System;
using System.Collections.Generic;
using System.Text;

namespace INDEX.Plugin
{
    public interface IPlugin : IDisposable
    {
        string Name { get; set; }
        string Author { get; set; }
        string Version { get; set; }


        // state controllers?
        void Start();

        void Pause();
        void Resume();
    }
}
