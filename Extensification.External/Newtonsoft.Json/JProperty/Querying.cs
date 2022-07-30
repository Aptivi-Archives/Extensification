
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