﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 4468)]
    public struct MapClass
    {
        //[UnmanagedFunctionPointer(CallingConvention.FastCall)]
        //public delegate DamageAreaResult DamageAreaFunction(in CoordStruct Coords, int Damage, /*Pointer<TechnoClass>*/IntPtr SourceObject,
        //    IntPtr WH, bool AffectsTiberium, IntPtr SourceHouse);
        //public static DamageAreaFunction DamageAreaDlg = Marshal.GetDelegateForFunctionPointer<DamageAreaFunction>(new IntPtr(0x489280));

        public static unsafe DamageAreaResult DamageArea(in CoordStruct Coords, int Damage, Pointer<TechnoClass> SourceObject,
            Pointer<WarheadTypeClass> WH, bool AffectsTiberium, Pointer<HouseClass> SourceHouse)
        {
            //var func = (delegate* unmanaged[Fastcall]<in CoordStruct, int, IntPtr, IntPtr, bool, IntPtr, DamageAreaResult>)0x489280;
            var func = (delegate* managed<in CoordStruct, int, Pointer<HouseClass>, bool, Pointer<WarheadTypeClass>, Pointer<TechnoClass>, DamageAreaResult>)0x489280;
            return func(in Coords, Damage, SourceHouse, AffectsTiberium, WH, SourceObject);
        }

        //[UnmanagedFunctionPointer(CallingConvention.FastCall)]
        //public delegate void FlashbangWarheadAtFunction(int Damage, IntPtr WH, CoordStruct coords, bool Force = false, SpotlightFlags CLDisableFlags = SpotlightFlags.None);
        //public static FlashbangWarheadAtFunction FlashbangWarheadAt = Marshal.GetDelegateForFunctionPointer<FlashbangWarheadAtFunction>(new IntPtr(0x48A620));

        public static unsafe void FlashbangWarheadAt(int Damage, Pointer<WarheadTypeClass> WH, CoordStruct coords, bool Force = false, SpotlightFlags CLDisableFlags = SpotlightFlags.None)
        {
            //var func = (delegate* unmanaged[Fastcall]<int, IntPtr, CoordStruct, bool, SpotlightFlags, void>)0x48A620;
            var func = (delegate* managed<int, Pointer<WarheadTypeClass>, SpotlightFlags, bool, CoordStruct, void>)0x48A620;
            func(Damage, WH, CLDisableFlags, Force, coords);
        }
    }
}
