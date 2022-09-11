
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


namespace Extensification
{

    /// <summary>
    /// Human-readable formats
    /// </summary>
    public enum HumanFormats
    {
        /// <summary>
        /// Computer data size (KB, MB, GB, TB, PB, EB, ...)
        /// </summary>
        DataSize,
        /// <summary>
        /// Body measurements in metric units (mm, cm, m, km, ...)
        /// </summary>
        MeasurementsMetric,
        /// <summary>
        /// Body measurements in metric units (mm, cm, dm (Decimeters), m, dcm (Decameters), hm (Hectameters), km, ...)
        /// </summary>
        MeasurementsMetricUnusual,
        /// <summary>
        /// Body measurements in imperial units (feet, yards, miles, ...)
        /// </summary>
        MeasurementsImperial,
        /// <summary>
        /// Body volume in metric units (mL, L, kL (Kiloliters))
        /// </summary>
        VolumeMetric,
        /// <summary>
        /// Body volume in imperial units (pints, quarts, gallons, ...)
        /// </summary>
        VolumeImperial
    }
}