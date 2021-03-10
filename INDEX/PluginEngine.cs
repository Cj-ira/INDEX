using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using INDEX.Plugin;

namespace INDEX
{
    // Todo: Sandboxing and other security features.
    // Todo: Functionality to disable-enable plugins.

    /// <summary>
    /// This class is a backend class to manage the plugins.
    /// </summary>
    public class PluginEngine
    {
        private Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();
        private FileSystemWatcher FileSystemWatcher;

        /// <summary>
        /// Ctors the class to a object!
        /// </summary>
        /// <param name="pluginDirectory">The directory path of where the plugin are located in.</param>
        /// <param name="monitorPlugins">If enabled this class will monitor the plugin directory for changes.</param>
        public PluginEngine(string pluginDirectory, bool monitorPlugins)
        {
            if (monitorPlugins)
            {
                FileSystemWatcher = new FileSystemWatcher(pluginDirectory);
                FileSystemWatcher.EnableRaisingEvents = true;
                FileSystemWatcher.Changed += FileSystemWatcher_Changed;
                FileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
                FileSystemWatcher.Created += FileSystemWatcher_Created;
            }

            InitPlugins(Search(pluginDirectory));
        }

        #region Events
        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (plugins.KVSearchnRun(e.FullPath, (x, v) => { x.Dispose(); v.Remove(e.FullPath); }))
            {
                InitPlugin(e.FullPath);
            }
        }

        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (!plugins.KVSearchnRun(e.FullPath, (x, v) => { x.Dispose(); v.Remove(e.FullPath); }))
            {
                // Todo: Log!
            }
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            InitPlugin(e.FullPath);
        }
        #endregion


        // Todo: Move some methods to helper classes? clean up.

        /// <summary>
        /// Searches for possible plugins.
        /// </summary>
        /// <param name="pluginDirectory"></param>
        /// <returns></returns>
        private string[] Search(string pluginDirectory) => Directory.GetFiles(pluginDirectory, "*.dll");

        /// <summary>
        /// helper method for <see cref="InitPlugin(string)"/>
        /// </summary>
        /// <param name="plugins">plugin paths</param>
        private void InitPlugins(string[] plugins)
        {
            for (int i = 0; i < plugins.GetUpperBound(0); i++)
            {
                InitPlugin(plugins[i]);
            }
        }

        /// <summary>
        /// Contructs the plugin and stores to be managed using the file path.
        /// </summary>
        /// <param name="pluginPath">the plugin path</param>
        private void InitPlugin(string pluginPath)
        {
            try
            {
                Assembly asm = Assembly.LoadFrom(pluginPath);

                foreach (var type in asm.GetTypes())
                {
                    if (typeof(IPlugin).IsAssignableFrom(type))
                    {
                        object? contructedtype = Activator.CreateInstance(type);

                        if (contructedtype != null)
                        {
                            IPlugin plugin = (IPlugin)contructedtype;
                            plugin.Start();
                            plugins.Add(pluginPath, plugin);
                            break;
                        }
                        // Todo: Probably should log this later.
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                // Todo: Probably should log this.
            }
        }


    }
}
