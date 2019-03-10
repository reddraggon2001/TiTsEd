﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Resources;
using System.Text;

namespace TiTsEd.Common
{
    class VersionInfo
    {
        public static String Version {
            get {
                var versionText = "0.0.0";
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                if (version.Build == 0) versionText = version.Major + "." + version.Minor;
                else versionText = version.Major + "." + version.Minor + "." + version.Build;
                return versionText;
            }
        }

        public static T GetAssemblyAttribute<T>(Assembly assembly)
        where T : Attribute
        {
            // Get attributes of this type.
            object[] attributes =
                assembly.GetCustomAttributes(typeof(T), true);

            // If we didn't get anything, return null.
            if ((attributes == null) || (attributes.Length == 0))
                return null;

            // Convert the first attribute value into
            // the desired type and return it.
            return (T)attributes[0];
        }
    }
}
