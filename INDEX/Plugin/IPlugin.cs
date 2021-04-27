using System;

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