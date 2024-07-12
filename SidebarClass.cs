using DynamicPatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    public struct SidebarClass
    {
        public static readonly IntPtr ppInstance = new IntPtr(0x87F7E8);
        public static Pointer<SidebarClass> pInstance { get => ppInstance; }


        public unsafe bool AddCameo(AbstractType absType, int idxType) 
            => ((delegate* unmanaged[Thiscall]<ref SidebarClass, AbstractType, int, Bool>)0x6A6300)(ref this, absType, idxType);

        public static unsafe int GetObjectTabIdx(AbstractType abs, int idxType, int unused) 
            => ((delegate* unmanaged[Thiscall]<int, AbstractType, int, int, int>)ASM.FastCallTransferStation)(0x6ABC60, abs, idxType, unused);

        public unsafe void RepaintSidebar(int tab = 0) 
            => ((delegate* unmanaged[Thiscall]<ref SidebarClass, int, void>)0x6A60A0)(ref this, tab);

    }
}