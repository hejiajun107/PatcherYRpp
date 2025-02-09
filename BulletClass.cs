﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BulletData
    {
        public TimerStruct UnknownTimer;
        public TimerStruct ArmTimer;
        public CoordStruct Location;
        public int Distance;
    };

    [StructLayout(LayoutKind.Explicit, Size = 352)]
    public struct BulletClass : IOwnAbstractType<BulletTypeClass>
    {
        static public readonly IntPtr ArrayPointer = new IntPtr(0xA8ED40);
        static public ref DynamicVectorClass<Pointer<BulletClass>> Array { get => ref DynamicVectorClass<Pointer<BulletClass>>.GetDynamicVector(ArrayPointer); }

        Pointer<BulletTypeClass> IOwnAbstractType<BulletTypeClass>.OwnType => Type;
        Pointer<AbstractTypeClass> IOwnAbstractType.AbstractType => Type.Convert<AbstractTypeClass>();

        // 123 virtual function
        public void SetTarget(Pointer<AbstractClass> pTarget)
        {
            this.Target = pTarget;
        }

        public unsafe bool MoveTo(CoordStruct where, BulletVelocity velocity)
        {
            var func = (delegate* unmanaged[Thiscall]<ref BulletClass, ref CoordStruct, ref BulletVelocity, Bool>)this.GetVirtualFunctionPointer(124);
            return func(ref this, ref where, ref velocity);
        }

        public unsafe void Fire(bool destroy = false)
        {
            var func = (delegate* unmanaged[Thiscall]<ref BulletClass, Bool, void>)0x468D80;
            func(ref this, destroy);
        }

        public unsafe void Detonate(CoordStruct coords)
        {
            var func = (delegate* unmanaged[Thiscall]<ref BulletClass, ref CoordStruct, void>)0x4690B0;
            func(ref this, ref coords);
        }

        public void DetonateAndUnInit(CoordStruct coords)
        {
            //if not set location,some effects of phobos will not applied
            Base.SetLocation(coords);

            Detonate(coords);
            Base.UnInit();
        }


        public unsafe void LoseTarget()
        {
            var func = (delegate* unmanaged[Thiscall]<ref BulletClass, void>)0x468430;
            func(ref this);
        }

        [FieldOffset(0)]
        public ObjectClass Base;

        [FieldOffset(172)] public Pointer<BulletTypeClass> Type;
        [FieldOffset(176)] public Pointer<TechnoClass> Owner;

        [FieldOffset(184)] public BulletData Data;
        [FieldOffset(224)] public Bool Bright;

        [FieldOffset(232)] public BulletVelocity Velocity;

        [FieldOffset(261)] public Bool CourseLocked;
        [FieldOffset(264)] public int CourseLockedDuration;
        [FieldOffset(268)] public Pointer<AbstractClass> Target;
        [FieldOffset(272)] public int Speed;
        [FieldOffset(276)] public int InheritedColor;

        [FieldOffset(296)] public Pointer<WarheadTypeClass> WH;
        [FieldOffset(300)] public byte AnimFrame;
        [FieldOffset(301)] public byte AnimRateCounter;
        [FieldOffset(304)] public Pointer<WeaponTypeClass> WeaponType;
        [FieldOffset(308)] public CoordStruct SourceCoords;
        [FieldOffset(320)] public CoordStruct TargetCoords;
        [FieldOffset(332)] public CellStruct LastMapCoords;
        [FieldOffset(336)] public int DamageMultiplier;
        [FieldOffset(340)] public Pointer<AnimClass> NextAnim;
        [FieldOffset(344)] public Bool SpawnNextAnim;
        [FieldOffset(348)] public int Range;
    }
}
