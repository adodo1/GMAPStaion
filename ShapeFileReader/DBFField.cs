using System;
using System.Net;
using System.Windows;

namespace Vishcious.ArcGIS.SLContrib
{
    public class DBFField
    {
        public string FieldName
        {
            get;
            set;
        }

        public byte FieldType
        {
            get;
            set;
        }

        public uint FieldDataAddress
        {
            get;
            set;
        }

        public byte FieldLengthInBytes
        {
            get;
            set;
        }

        public byte NumberOfDecimalPlaces
        {
            get;
            set;
        }

        public byte FieldFlags
        {
            get;
            set;
        }

        public uint NextAutoIncrementValue
        {
            get;
            set;
        }

        public byte AutoIncrementStepValue
        {
            get;
            set;
        }

        public byte[] ReservedBytes
        {
            get;
            set;
        }
    }
}
