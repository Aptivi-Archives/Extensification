
// Extensification  Copyright (C) 2020-2021  Aptivi
// 
// This file is part of Extensification
// 
// Extensification is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Extensification is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

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