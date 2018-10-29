using System;
using System.Collections.Generic;
using System.Text;

namespace SWriter.RequestManager.Helpers
{
    public static class StringExtensions
    {
        public static object ToObject(this string value, object source, string propertyName)
        {
            object objectValue;

            string className = source.GetType().GetProperty(propertyName).PropertyType.FullName.ToLower();

            switch (className)
            {
                case "system.string":
                    objectValue = value;
                    break;
                case "system.boolean":
                    objectValue = Convert.ToBoolean(value);
                    break;
                case "system.byte":
                    objectValue = Convert.ToByte(value);
                    break;
                case "system.sbyte":
                    objectValue = Convert.ToSByte(value);
                    break;
                case "system.char":
                    objectValue = Convert.ToChar(value);
                    break;
                case "system.decimal":
                    objectValue = Convert.ToDecimal(value);
                    break;
                case "system.double":
                    objectValue = Convert.ToDouble(value);
                    break;
                case "system.single":
                    objectValue = Convert.ToSingle(value);
                    break;
                case "system.int16":
                    objectValue = Convert.ToInt16(value);
                    break;
                case "system.int32":
                    objectValue = Convert.ToInt32(value);
                    break;
                case "system.int64":
                    objectValue = Convert.ToInt64(value);
                    break;
                case "system.uint16":
                    objectValue = Convert.ToUInt16(value);
                    break;
                case "system.uint32":
                    objectValue = Convert.ToUInt32(value);
                    break;
                case "system.uint64":
                    objectValue = Convert.ToUInt64(value);
                    break;
                default:
                    objectValue = value;
                    break;
            }

            return objectValue; 
        }
    }
}
