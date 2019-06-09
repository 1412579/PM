using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Security.Claims;
using System.Globalization;

namespace PM.lib
{
    public static class PMExtension
    {
        /// <summary>
        /// Là môi trường local, beta
        /// </summary>
        public static bool IsTestEnv
        {
            get
            {
                return Debugger.IsAttached;
            }
        }
        public static bool IsNumericType(this object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
        private static string FormatNumber(this object value, string format)
        {
            if (!value.IsNumericType())
                throw new ArgumentException("\"" + value + "\" is not a number.");

            var result = string.Format(CultureInfo.GetCultureInfo("vi-VN"), format, value);
            if (result.StartsWith("0"))
                return string.Empty;
            return result;
        }

        public static string ToCurrency(this object number)
        {
            return number.FormatNumber("{0:c0}");
        }

       

    }

    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }



}
