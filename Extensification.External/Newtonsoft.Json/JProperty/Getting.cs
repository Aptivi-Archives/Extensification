using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Extensification.External.Newtonsoft.Json.JPropertyExts
{
    /// <summary>
    /// Provides the JProperty extensions related to getting
    /// </summary>
    public static class Getting
    {

        /// <summary>
        /// Gets a property name that starts with specified string
        /// </summary>
        /// <param name="Token">JSON token</param>
        /// <param name="Containing">String to find at the beginning of string</param>
        /// <returns>A property name if found; nothing if not found</returns>
        public static string GetPropertyNameStartingWith(this JToken Token, string Containing)
        {
            foreach (JProperty TokenProperty in Token)
            {
                if (TokenProperty.Name.StartsWith(Containing))
                {
                    return TokenProperty.Name;
                }
            }
            return "";
        }

        /// <summary>
        /// Gets a property name that ends with specified string
        /// </summary>
        /// <param name="Token">JSON token</param>
        /// <param name="Containing">String to find at the end of string</param>
        /// <returns>A property name if found; nothing if not found</returns>
        public static string GetPropertyNameEndingWith(this JToken Token, string Containing)
        {
            foreach (JProperty TokenProperty in Token)
            {
                if (TokenProperty.Name.EndsWith(Containing))
                {
                    return TokenProperty.Name;
                }
            }
            return "";
        }

        /// <summary>
        /// Gets a property name that contains the specified string
        /// </summary>
        /// <param name="Token">JSON token</param>
        /// <param name="Containing">String to find in string</param>
        /// <returns>A property name if found; nothing if not found</returns>
        public static string GetPropertyNameContaining(this JToken Token, string Containing)
        {
            foreach (JProperty TokenProperty in Token)
            {
                if (TokenProperty.Name.Contains(Containing))
                {
                    return TokenProperty.Name;
                }
            }
            return "";
        }

        /// <summary>
        /// Gets properties that have the specific type in value.
        /// </summary>
        /// <param name="Token">JSON token</param>
        /// <param name="Type">JSON token type to search. If the type is <see cref="JTokenType.None"/>, returns all properties.</param>
        /// <returns>A property list if properties with specific type is found; empty list if nothing is found</returns>
        public static List<JToken> GetPropertiesTypeInValue(this JToken Token, JTokenType Type)
        {
            var TokenList = new List<JToken>();
            foreach (JProperty TokenProperty in Token)
            {
                if (TokenProperty.Value.Type == Type | Type == JTokenType.None)
                {
                    TokenList.Add(TokenProperty);
                }
            }
            return TokenList;
        }

    }
}