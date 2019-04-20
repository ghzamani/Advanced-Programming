using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace A6
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TypeOfSize5
    {
        public byte b;
        public int i;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct TypeOfSize22
    {
        [FieldOffset(0)] public short c;  // 2 bytes
        [FieldOffset(2)] public byte array;
        [FieldOffset(21)] public byte d;   // 1 byte
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct TypeOfSize125
    {
        [FieldOffset(0)] public byte array;
        [FieldOffset(124)] public byte b;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct TypeOfSize1024
    {
        [FieldOffset(0)] public byte array;
        [FieldOffset(1023)] public byte b;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct TypeOfSize32768
    {
        [FieldOffset(0)] public byte array;
        [FieldOffset(32767)] public byte b;
    }



    public struct TypeForMaxStackOfDepth10
    {
        public TypeOfSize1024 a;
        public TypeOfSize1024 b;
        public TypeOfSize1024 c;
        public TypeOfSize1024 d;
        public TypeOfSize1024 e;
        public TypeOfSize1024 f;
        public TypeOfSize1024 g;
        public TypeOfSize32768 h;
    }

    public struct TypeForMaxStackOfDepth100
    {
        public TypeOfSize1024 a;
        public TypeOfSize1024 b;
        public TypeOfSize1024 c;
        public TypeOfSize1024 d;
        public TypeOfSize1024 e;
    }

    public struct TypeForMaxStackOfDepth1000
    {
        public TypeOfSize125 a;
        public TypeOfSize125 b;
        public TypeOfSize125 c;
        public TypeOfSize125 d;
    }

    public struct TypeForMaxStackOfDepth3000
    {
        public TypeOfSize125 a;
    }

    public class TypeWithMemoryOnHeap
    {
        int[] array = new int[1_000_000];
        public void Allocate()
        {
            for(int i=0; i<1_000_000; i++)
                array[i] = i;
            
        }

        public void DeAllocate()
        {
            array = null;
        }
    }

    public struct StructOrClass1
    {
        public int X;
    }

    public class StructOrClass2
    {
        public int X;
    }

    public class StructOrClass3
    {
        public StructOrClass2 X;
    }

    public enum FutureHusbandType : int
    {
        None = 0,
        HasBigNose = 1,
        IsBald = 2,
        IsShort = 4
    }


    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public static int GetObjectType(object o)
        {
            string s = o as string;
            if (s != null)
                return 0;
            int[] arr = o as int[];
            if (arr != null)
                return 1;
            else return 2;
        }

        public static bool IdealHusband(FutureHusbandType fht)
        {
            if (fht == FutureHusbandType.HasBigNose
                || fht == FutureHusbandType.IsBald
                || fht == FutureHusbandType.IsShort)
                return false;
            else
            {
                if (fht == 0 )
                    return false;

                if ((fht & FutureHusbandType.HasBigNose) == FutureHusbandType.HasBigNose &&
                    (fht & FutureHusbandType.IsBald) == FutureHusbandType.IsBald &&
                    (fht & FutureHusbandType.IsShort) == FutureHusbandType.IsShort)
                    return false;

                if ((fht & FutureHusbandType.HasBigNose) == FutureHusbandType.HasBigNose ||
                    (fht & FutureHusbandType.IsBald) == FutureHusbandType.IsBald)
                    return true;


                if ((fht & FutureHusbandType.HasBigNose) == FutureHusbandType.HasBigNose ||
                    (fht & FutureHusbandType.IsShort) == FutureHusbandType.IsShort)
                    return true;


                if ((fht & FutureHusbandType.IsShort) == FutureHusbandType.IsShort ||
                    (fht & FutureHusbandType.IsBald) == FutureHusbandType.IsBald)
                    return true;

                return true;
            }

            
        }
    }
}
