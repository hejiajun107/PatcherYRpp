using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct VocClassHeader
    {
        [FieldOffset(0)] public IntPtr Next;
        [FieldOffset(4)] public IntPtr Prev;
        [FieldOffset(8)] public int Magic;

    }

    [StructLayout(LayoutKind.Explicit, Size = 328)]
    public struct VocClass
    {
        public static readonly IntPtr ArrayPointer = new IntPtr(0xB1D378);

        public static ref DynamicVectorClass<Pointer<VocClass>> Array { get => ref DynamicVectorClass<Pointer<VocClass>>.GetDynamicVector(ArrayPointer); }

        public static bool VoicesEnabled { get => pVoicesEnabled.Convert<bool>().Data; set => pVoicesEnabled.Convert<bool>().Ref = value; }
        public static IntPtr pVoicesEnabled = new IntPtr(0x8464AC);

        [FieldOffset(0)] public VocClassHeader Header;


        [FieldOffset(108)] public byte Name_first;

        public AnsiStringPointer Name => Pointer<byte>.AsPointer(ref Name_first);


        public static unsafe int FindIndex(string name)
        {
            int i = 0;
            foreach (var ptr in Array)
            {
                Pointer<VocClass> pItem = ptr.Convert<VocClass>();
                if (pItem.Ref.GetName() == name)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        //public unsafe static int FindIndex(AnsiString name)
        //{
        //    var func = (delegate* unmanaged[Thiscall]<IntPtr, int>)0x7514D0;
        //    return func(name);
        //}

        public unsafe string GetName()
        {
            var func = (delegate* unmanaged[Thiscall]<ref VocClass, string>)0x751600;
            return func(ref this);
        }


    }


}
