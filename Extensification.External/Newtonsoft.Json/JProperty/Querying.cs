using Extensification.StringExts;
using Newtonsoft.Json.Linq;

namespace Extensification.External.Newtonsoft.Json.JPropertyExts
{
    /// <summary>
    /// Provides the JProperty extensions related to querying
    /// </summary>
    public static class Querying
    {

        /// <summary>
        /// Selects a token that has its key containing the specified string
        /// </summary>
        /// <param name="Token">JSON token</param>
        /// <param name="Containing">String to find in the key string</param>
        /// <returns>A token if found; nothing if not found</returns>
        public static JToken SelectTokenKeyContaining(this JToken Token, string Containing)
        {
            string PropertyName = Token.GetPropertyNameContaining(Containing);
            if (!string.IsNullOrEmpty(PropertyName))
            {
                return Token.SelectToken("['" + PropertyName.ReplaceAllRange(new[] { @"\", "/", "'", "\"" }, new[] { @"\\", @"\/", @"\'", @"\""" }) + "']");
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Selects a token that has its key ending with the specified string
        /// </summary>
        /// <param name="Token">JSON token</param>
        /// <param name="Containing">String to find at the end of key string</param>
        /// <returns>A token if found; nothing if not found</returns>
        public static JToken SelectTokenKeyEndingWith(this JToken Token, string Containing)
        {
            string PropertyName = Token.GetPropertyNameEndingWith(Containing);
            if (!string.IsNullOrEmpty(PropertyName))
            {
                return Token.SelectToken("['" + PropertyName.ReplaceAllRange(new[] { @"\", "/", "'", "\"" }, new[] { @"\\", @"\/", @"\'", @"\""" }) + "']");
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Selects a token that has its key starting with the specified string
        /// </summary>
        /// <param name="Token">JSON token</param>
        /// <param name="Containing">String to find at the beginning of key string</param>
        /// <returns>A token if found; nothing if not found</returns>
        public static JToken SelectTokenKeyStartingWith(this JToken Token, string Containing)
        {
            string PropertyName = Token.GetPropertyNameStartingWith(Containing);
            if (!string.IsNullOrEmpty(PropertyName))
            {
                return Token.SelectToken("['" + PropertyName.ReplaceAllRange(new[] { @"\", "/", "'", "\"" }, new[] { @"\\", @"\/", @"\'", @"\""" }) + "']");
            }
            else
            {
                return null;
            }
        }

    }
}