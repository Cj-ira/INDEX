using System.IO;

namespace INDEX
{
    /// <summary>
    /// Frontend interface for the library.
    /// </summary>
    class INDEXManager
    {
        private PluginEngine PluginEngine;


        /// <summary>
        ///
        /// </summary>
        /// <param name="pluginDirectory">the directory path to the plugins.</param>
        /// <param name="hotLoading">This enables plugins to be 'removed', 'added', 'modified' during runtime.</param>
        public INDEXManager(string pluginDirectory, bool hotLoading)
        {
            PluginEngine = new PluginEngine(pluginDirectory, hotLoading);
        }
    }
}
