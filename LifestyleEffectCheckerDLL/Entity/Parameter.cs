﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifestyleEffectCheckerDLL.Entity
{
    public class Parameter : AbstractBaseObject
    {
        public MeasuringMethod MeasuringMethod { get; set; } = MeasuringMethod.Slider;

        private string Text { get; set; }
        private string ImgPath { get; set; }
        private double DecimalValue { get; set; }
        private double SliderValue { get; set; }
        private int NumberValue { get; set; }
        private MyGeoPosition GeoPosition { get; set; }

        public string GetValue()
        {
            switch (MeasuringMethod)
            {
                case MeasuringMethod.Text:
                    return Text;
                case MeasuringMethod.Decimal:
                    return DecimalValue + "";
                case MeasuringMethod.Number:
                    return NumberValue + "";
                case MeasuringMethod.Picture:
                    return ImgPath;
                case MeasuringMethod.Slider:
                    return SliderValue + "";
                case MeasuringMethod.GPSLocation:
                    return "GeoLocation - Latitude:" + GeoPosition.Latitude + " " + "Longitude:" +
                           GeoPosition.Longitude;
                default:
                    return "No measuring method defined";
            }
        }

        public void SetValue(object value)
        {
            switch (MeasuringMethod)
            {
                case MeasuringMethod.Text:
                    Text = (string)value;
                    break;
                case MeasuringMethod.Decimal:
                    DecimalValue = (double)value;
                    break;
                case MeasuringMethod.Number:
                    NumberValue = (int)value;
                    break;
                case MeasuringMethod.Picture:
                    ImgPath = (string)value;
                    break;
                case MeasuringMethod.Slider:
                    SliderValue = (double)value;
                    break;
                default:
                    break;
            }
        }
        public void SetValue(object value1, object value2)
        {
            switch (MeasuringMethod)
            {
                case MeasuringMethod.GPSLocation:
                    GeoPosition.Latitude = (double)value1;
                    GeoPosition.Longitude = (double)value2;
                    break;
                default:
                    break;
            }
        }

    }

    public enum MeasuringMethod
    {
        Slider, Decimal, Number, Text, GPSLocation, Picture
    }

}

