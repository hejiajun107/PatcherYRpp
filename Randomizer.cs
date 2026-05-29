using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct Randomizer
    {
        //public static Pointer<Randomizer> Global = new Pointer<Randomizer>(0x886B88);
        private static IntPtr instance = new IntPtr(0x886B88);
        static public ref Randomizer Instance { get => ref instance.Convert<Pointer<Randomizer>>().Ref.Ref; }


        [FieldOffset(0)]
        public Bool unknown_00;

        [FieldOffset(4)]
        public int Next1;

        [FieldOffset(8)]
        public int Next2;

        //public unsafe uint Random()
        //{
        //    var func = (delegate* unmanaged[Thiscall]<ref Randomizer, uint>)0x65C780;
        //    return func(ref this);
        //}

        [FieldOffset(12)]
        public unsafe IntPtr Table;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Pointer<Randomizer> GetThis() => this.GetThisPointer();

        public unsafe int RandomRanged(int nMin, int nMax)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, int, int, int>)0x65C7E0;
            return func(GetThis(), nMin, nMax);
        }

        //public Randomizer(uint dwSeed = 0)
        //{
        //    unknown_00 = false;
        //    Next1 = 0;
        //    Next2 = 0;
        //}

        //public double RandomDouble()
        //{
        //    return this.RandomRanged(1, 2147483647) / 2147483648.0;
        //}
    }
}