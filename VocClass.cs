using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 328)]
    public struct VocClass
    {
        public static readonly IntPtr ArrayPointer = new IntPtr(0xB1D378);

        public static ref DynamicVectorClass<Pointer<VocClass>> Array { get => ref DynamicVectorClass<Pointer<VocClass>>.GetDynamicVector(ArrayPointer); }

        public static bool VoicesEnabled { get => pVoicesEnabled.Convert<bool>().Data; set => pVoicesEnabled.Convert<bool>().Ref = value; }
        public static IntPtr pVoicesEnabled = new IntPtr(0x8464AC); 

    }
}
