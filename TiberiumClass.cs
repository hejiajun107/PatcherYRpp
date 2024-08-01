using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 296)]
    public struct TiberiumClass
    {
        static public readonly IntPtr ArrayPointer = new IntPtr(0xB0F4E8u);
        static public ref DynamicVectorClass<Pointer<TiberiumClass>> Array { get => ref DynamicVectorClass<Pointer<TiberiumClass>>.GetDynamicVector(ArrayPointer); }

    }
}
