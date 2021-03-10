using System;
using System.Collections.Generic;

namespace INDEX
{
    public static class Helper
    {

        /// <summary>
        /// Searches a dictionary for a value using a key and passes the value to an action to save time and to maintain DRY.
        /// </summary>
        /// <typeparam name="Key"></typeparam>
        /// <typeparam name="Value"></typeparam>
        /// <param name="dictionary">The dictionary that it'll search</param>
        /// <param name="key">the key that it'll search the dictionary with.</param>
        /// <param name="action">the code that the value will be passed into.</param>
        /// <returns>An boolean based on the invokation of the action.</returns>
        public static bool KVSearchnRun<Key, Value>(this Dictionary<Key, Value> dictionary, Key key, Action<Value, Dictionary<Key, Value>> action)
        {
            if (dictionary.ContainsKey(key))
            {
                action.Invoke(dictionary[key], dictionary);
                return true;
            }
            return false;
        }
    }
}
