using System;
using System.Collections.Generic;
using System.Text;

namespace INDEX.Plugin
{
    public interface IPlugin : IDisposable
    {
        PluginData pluginData { get; set; }


        // state controllers?
        void Start();

        void Pause();
        void Resume();
    }
}
