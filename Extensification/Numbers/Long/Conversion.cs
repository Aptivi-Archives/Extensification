
namespace Extensification.LongExts
{
    /// <summary>
    /// Provides the 64-bit integer extensions related to conversion
    /// </summary>
    public static class Conversion
    {

        /// <summary>
        /// Converts number to a human readable format with units used
        /// </summary>
        /// <param name="Num">Number</param>
        /// <param name="Type">Measurement types</param>
        /// <returns>A string containing the processed number and unit</returns>
        public static string ToHumanReadable(this long Num, HumanFormats Type)
        {
            string HumanString = "";
            var HumanNum = default(double);
            switch (Type)
            {
                case HumanFormats.DataSize:
                    {
                        if (Num >= 1000000000000000000L) // EB
                        {
                            HumanNum = Num / 1000000000000000000d;
                            HumanString = HumanNum + " EB";
                        }
                        else if (Num >= 1000000000000000L) // PB
                        {
                            HumanNum = Num / 1000000000000000d;
                            HumanString = HumanNum + " PB";
                        }
                        else if (Num >= 1000000000000L) // TB
                        {
                            HumanNum = Num / 1000000000000d;
                            HumanString = HumanNum + " TB";
                        }
                        else if (Num >= 1000000000L) // GB
                        {
                            HumanNum = Num / 1000000000d;
                            HumanString = HumanNum + " GB";
                        }
                        else if (Num >= 1000000L) // MB
                        {
                            HumanNum = Num / 1000000d;
                            HumanString = HumanNum + " MB";
                        }
                        else if (Num >= 1000L) // KB
                        {
                            HumanNum = Num / 1000d;
                            HumanString = HumanNum + " KB";
                        }
                        else // bytes
                        {
                            HumanString = HumanNum + " bytes";
                        }

                        break;
                    }
                case HumanFormats.MeasurementsImperial:
                    {
                        if (Num >= 63360L) // miles
                        {
                            HumanNum = Num / 63360d;
                            HumanString = HumanNum + " miles";
                        }
                        else if (Num >= 36L) // yards
                        {
                            HumanNum = Num / 36d;
                            HumanString = HumanNum + " yards";
                        }
                        else if (Num >= 12L) // feet
                        {
                            HumanNum = Num / 12d;
                            HumanString = HumanNum + " feet";
                        }
                        else // inches
                        {
                            HumanString = Num + " inches";
                        }

                        break;
                    }
                case HumanFormats.MeasurementsMetric:
                    {
                        if (Num >= 1000000L) // km
                        {
                            HumanNum = Num / 1000000d;
                            HumanString = HumanNum + " kilometers";
                        }
                        else if (Num >= 1000L) // m
                        {
                            HumanNum = Num / 1000d;
                            HumanString = HumanNum + " meters";
                        }
                        else if (Num >= 10L) // cm
                        {
                            HumanNum = Num / 10d;
                            HumanString = HumanNum + " centimeters";
                        }
                        else // mm
                        {
                            HumanString = Num + " millimeters";
                        }

                        break;
                    }
                case HumanFormats.MeasurementsMetricUnusual:
                    {
                        if (Num >= 1000000L) // km
                        {
                            HumanNum = Num / 1000000d;
                            HumanString = HumanNum + " kilometers";
                        }
                        else if (Num >= 100000L) // hm
                        {
                            HumanNum = Num / 100000d;
                            HumanString = HumanNum + " hectameters";
                        }
                        else if (Num >= 10000L) // dcm
                        {
                            HumanNum = Num / 10000d;
                            HumanString = HumanNum + " decameters";
                        }
                        else if (Num >= 1000L) // m
                        {
                            HumanNum = Num / 1000d;
                            HumanString = HumanNum + " meters";
                        }
                        else if (Num >= 100L) // dm
                        {
                            HumanNum = Num / 100d;
                            HumanString = HumanNum + " decimeters";
                        }
                        else if (Num >= 10L) // cm
                        {
                            HumanNum = Num / 10d;
                            HumanString = HumanNum + " centimeters";
                        }
                        else // mm
                        {
                            HumanString = Num + " millimeters";
                        }

                        break;
                    }
                case HumanFormats.VolumeMetric:
                    {
                        if (Num >= 1000000L) // kL
                        {
                            HumanNum = Num / 1000000d;
                            HumanString = HumanNum + " kiloliters";
                        }
                        else if (Num >= 1000L) // L
                        {
                            HumanNum = Num / 1000d;
                            HumanString = HumanNum + " liters";
                        }
                        else // mL
                        {
                            HumanString = Num + " milliliters";
                        }

                        break;
                    }
                case HumanFormats.VolumeImperial:
                    {
                        if (Num >= 8L) // gallons
                        {
                            HumanNum = Num / 8d;
                            HumanString = HumanNum + " gallons";
                        }
                        else if (Num >= 2L) // quarts
                        {
                            HumanNum = Num / 2d;
                            HumanString = HumanNum + " quarts";
                        }
                        else // pints
                        {
                            HumanString = Num + " pints";
                        }

                        break;
                    }
            }
            return HumanString;
        }

        /// <summary>
        /// Converts number to a human readable format with units used
        /// </summary>
        /// <param name="Num">Number</param>
        /// <param name="Type">Measurement types</param>
        /// <returns>A string containing the processed number and unit</returns>
        public static string ToHumanReadable(this ulong Num, HumanFormats Type)
        {
            string HumanString = "";
            var HumanNum = default(double);
            switch (Type)
            {
                case HumanFormats.DataSize:
                    {
                        if (Num >= 1000000000000000000m) // EB
                        {
                            HumanNum = Num / 1000000000000000000d;
                            HumanString = HumanNum + " EB";
                        }
                        else if (Num >= 1000000000000000m) // PB
                        {
                            HumanNum = Num / 1000000000000000d;
                            HumanString = HumanNum + " PB";
                        }
                        else if (Num >= 1000000000000m) // TB
                        {
                            HumanNum = Num / 1000000000000d;
                            HumanString = HumanNum + " TB";
                        }
                        else if (Num >= 1000000000m) // GB
                        {
                            HumanNum = Num / 1000000000d;
                            HumanString = HumanNum + " GB";
                        }
                        else if (Num >= 1000000m) // MB
                        {
                            HumanNum = Num / 1000000d;
                            HumanString = HumanNum + " MB";
                        }
                        else if (Num >= 1000m) // KB
                        {
                            HumanNum = Num / 1000d;
                            HumanString = HumanNum + " KB";
                        }
                        else // bytes
                        {
                            HumanString = HumanNum + " bytes";
                        }

                        break;
                    }
                case HumanFormats.MeasurementsImperial:
                    {
                        if (Num >= 63360m) // miles
                        {
                            HumanNum = Num / 63360d;
                            HumanString = HumanNum + " miles";
                        }
                        else if (Num >= 36m) // yards
                        {
                            HumanNum = Num / 36d;
                            HumanString = HumanNum + " yards";
                        }
                        else if (Num >= 12m) // feet
                        {
                            HumanNum = Num / 12d;
                            HumanString = HumanNum + " feet";
                        }
                        else // inches
                        {
                            HumanString = Num + " inches";
                        }

                        break;
                    }
                case HumanFormats.MeasurementsMetric:
                    {
                        if (Num >= 1000000m) // km
                        {
                            HumanNum = Num / 1000000d;
                            HumanString = HumanNum + " kilometers";
                        }
                        else if (Num >= 1000m) // m
                        {
                            HumanNum = Num / 1000d;
                            HumanString = HumanNum + " meters";
                        }
                        else if (Num >= 10m) // cm
                        {
                            HumanNum = Num / 10d;
                            HumanString = HumanNum + " centimeters";
                        }
                        else // mm
                        {
                            HumanString = Num + " millimeters";
                        }

                        break;
                    }
                case HumanFormats.MeasurementsMetricUnusual:
                    {
                        if (Num >= 1000000m) // km
                        {
                            HumanNum = Num / 1000000d;
                            HumanString = HumanNum + " kilometers";
                        }
                        else if (Num >= 100000m) // hm
                        {
                            HumanNum = Num / 100000d;
                            HumanString = HumanNum + " hectameters";
                        }
                        else if (Num >= 10000m) // dcm
                        {
                            HumanNum = Num / 10000d;
                            HumanString = HumanNum + " decameters";
                        }
                        else if (Num >= 1000m) // m
                        {
                            HumanNum = Num / 1000d;
                            HumanString = HumanNum + " meters";
                        }
                        else if (Num >= 100m) // dm
                        {
                            HumanNum = Num / 100d;
                            HumanString = HumanNum + " decimeters";
                        }
                        else if (Num >= 10m) // cm
                        {
                            HumanNum = Num / 10d;
                            HumanString = HumanNum + " centimeters";
                        }
                        else // mm
                        {
                            HumanString = Num + " millimeters";
                        }

                        break;
                    }
                case HumanFormats.VolumeMetric:
                    {
                        if (Num >= 1000000m) // kL
                        {
                            HumanNum = Num / 1000000d;
                            HumanString = HumanNum + " kiloliters";
                        }
                        else if (Num >= 1000m) // L
                        {
                            HumanNum = Num / 1000d;
                            HumanString = HumanNum + " liters";
                        }
                        else // mL
                        {
                            HumanString = Num + " milliliters";
                        }

                        break;
                    }
                case HumanFormats.VolumeImperial:
                    {
                        if (Num >= 8m) // gallons
                        {
                            HumanNum = Num / 8d;
                            HumanString = HumanNum + " gallons";
                        }
                        else if (Num >= 2m) // quarts
                        {
                            HumanNum = Num / 2d;
                            HumanString = HumanNum + " quarts";
                        }
                        else // pints
                        {
                            HumanString = Num + " pints";
                        }

                        break;
                    }
            }
            return HumanString;
        }

    }
}