using System;
using System.Runtime.InteropServices;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct PCX
    {
     
        private static IntPtr InstancePointer = new IntPtr(0xAC4848);
        public static Pointer<PCX> Instance { get => ((Pointer<Pointer<PCX>>)InstancePointer).Data; set => ((Pointer<Pointer<PCX>>)InstancePointer).Ref = value; }

        private unsafe bool ForceLoadFile(string pFileName, int flag1, int flag2)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, string, int, int, bool>)0x6B9D00;
            return func(this.GetThisPointer(), pFileName, flag1, flag2);
        }

        public bool LoadFile(string fileName, int flag1 = 2, int flag2 = 0)
	    {
            if (Instance.Ref.GetSurface(fileName, Pointer<BytePalette>.Zero).IsNotNull)
            {
                return true;
            }
            return Instance.Ref.ForceLoadFile(fileName, flag1, flag2);
        }

        public unsafe Pointer<BSurface> GetSurface(string pFileName, Pointer<BytePalette> pPalette)
		{
            var func = (delegate* unmanaged[Thiscall]<IntPtr,string,IntPtr,IntPtr>)0x6BA140;
            return func(this.GetThisPointer(),pFileName,pPalette);
        }

        public unsafe bool BlitToSurface(Pointer<RectangleStruct> boundingRect,Pointer<DSurface> targetSurface, Pointer<BSurface> PCXSurface, int transparentColor = 0xF81F)
        {
            var func = (delegate* unmanaged[Thiscall]<IntPtr, IntPtr, IntPtr, IntPtr, int, bool>)0x6BA580;
            return func(this.GetThisPointer(), boundingRect, targetSurface,PCXSurface,transparentColor);
        }
    }
}
