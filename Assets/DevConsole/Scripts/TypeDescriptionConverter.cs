using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;


public class Vector2Converter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context,
        Type sourceType)
    {
        if (sourceType == typeof(string))
        {
            return true;
        }
        return base.CanConvertFrom(context, sourceType);
    }
    public override object ConvertFrom(ITypeDescriptorContext context,
        CultureInfo culture, object value)
    {
        if (value is string)
        {
            string[] valueSplit = (value as string).Split(',');
            if (valueSplit.Length == 2)
            {
                valueSplit[0] = valueSplit[0].TrimStart('(');
                valueSplit[1] = valueSplit[1].TrimEnd(')');
                return new Vector2(float.Parse(valueSplit[0]), float.Parse(valueSplit[1]));
            }
        }
        return base.ConvertFrom(context, culture, value);
    }
    public override object ConvertTo(ITypeDescriptorContext context,
        CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string))
        {
            return value.ToString();
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }
}

public class Vector3Converter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context,
        Type sourceType)
    {
        if (sourceType == typeof(string))
        {
            return true;
        }
        return base.CanConvertFrom(context, sourceType);
    }
    public override object ConvertFrom(ITypeDescriptorContext context,
        CultureInfo culture, object value)
    {
        if (value is string)
        {
            string[] valueSplit = (value as string).Split(',');
            if (valueSplit.Length == 3)
            {
                valueSplit[0] = valueSplit[0].TrimStart('(');
                valueSplit[2] = valueSplit[2].TrimEnd(')');
                return new Vector3(float.Parse(valueSplit[0]), float.Parse(valueSplit[1]), float.Parse(valueSplit[2]));
            }
        }
        return base.ConvertFrom(context, culture, value);
    }
    public override object ConvertTo(ITypeDescriptorContext context,
        CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string))
        {
            return value.ToString();
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }
}

public class Vector4Converter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context,
        Type sourceType)
    {
        if (sourceType == typeof(string))
        {
            return true;
        }
        return base.CanConvertFrom(context, sourceType);
    }
    public override object ConvertFrom(ITypeDescriptorContext context,
        CultureInfo culture, object value)
    {
        if (value is string)
        {
            string[] valueSplit = (value as string).Split(',');
            if (valueSplit.Length == 4)
            {
                valueSplit[0] = valueSplit[0].TrimStart('(');
                valueSplit[3] = valueSplit[3].TrimEnd(')');
                return new Vector4(float.Parse(valueSplit[0]), float.Parse(valueSplit[1]), float.Parse(valueSplit[2]),
                    float.Parse(valueSplit[3]));
            }
        }
        return base.ConvertFrom(context, culture, value);
    }
    public override object ConvertTo(ITypeDescriptorContext context,
        CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string))
        {
            return value.ToString();
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }
}
