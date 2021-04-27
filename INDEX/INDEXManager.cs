namespace INDEX
{
    /// <summary>
    /// Frontend interface for the library.
    /// </summary>
    public class INDEXManager
    {
        private PluginEngine PluginEngine;


        /// <summary>
        ///
        /// </summary>
        /// <param name="pluginDirectory">The directory path of the plugins.</param>
        /// <param name="hotLoading">This enables plugins to be 'removed', 'added', 'modified' during runtime.</param>
        public INDEXManager(string pluginDirectory, bool hotLoading)
        {
            PluginEngine = new PluginEngine(pluginDirectory, hotLoading);
        }

        //public List<PluginData> GetPlugins()
    }
}