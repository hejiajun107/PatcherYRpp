﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct TimerStruct
    {
        public TimerStruct(int duration) : this() { this.Start(duration); }
        public void Start(int duration)
        {
            this.StartTime = Game.CurrentFrame;
            this.TimeLeft = duration;
        }

        public void Stop()
        {
            this.StartTime = -1;
            this.TimeLeft = 0;
        }

        public void Pause()
        {
            if (this.IsTicking())
            {
                this.TimeLeft = this.GetTimeLeft();
                this.StartTime = -1;
            }
        }

        public void Resume()
        {
            if (!this.IsTicking())
            {
                this.StartTime = Game.CurrentFrame;
            }
        }

        public int GetTimeLeft()
        {
            if (!this.IsTicking())
            {
                return this.TimeLeft;
            }

            var passed = Game.CurrentFrame - this.StartTime;
            var left = this.TimeLeft - passed;

            return (left <= 0) ? 0 : left;
        }

        // returns whether a ticking timer has finished counting down.
        public bool Completed()
        {
            return this.IsTicking() && !this.HasTimeLeft();
        }

        // returns whether a delay is active or a timer is still counting down.
        // this is the 'opposite' of Completed() (meaning: incomplete / still busy)
        // and logically the same as !Expired() (meaning: blocked / delay in progress)
        public bool InProgress()
        {
            return this.IsTicking() && this.HasTimeLeft();
        }

        // returns whether a delay is inactive. same as !InProgress().
        public bool Expired()
        {
            return !this.IsTicking() || !this.HasTimeLeft();
        }

        internal bool IsTicking()
        {
            return this.StartTime != -1;
        }

        internal bool HasTimeLeft()
        {
            return this.GetTimeLeft() > 0;
        }

        public int StartTime;
        public int gap;
        public int TimeLeft;
    }

    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct RepeatableTimerStruct
    {
        public RepeatableTimerStruct(int duration) : this()
        {
            this.Start(duration);
        }

        public void Start(int duration)
        {
            this.Duration = duration;
            this.Restart();
        }

        public void Restart()
        {
            Base.Start(this.Duration);
        }

        public TimerStruct Base;
        public int Duration;
    }


    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct ProgressTimer
    {
        public ProgressTimer(int duration)
        {
            this.Value = 0;
            this.HasChanged = false;
            this.Step = 1;

            this.Timer = new RepeatableTimerStruct(duration);
        }

        public void Start(int duration)
        {
            this.Timer.Start(duration);
        }

        public void Start(int duration, int step)
        {
            this.Step = step;
            this.Start(duration);
        }

        // returns whether the value changed.
        public bool Update()
        {
            if (this.Timer.Base.GetTimeLeft() != 0 || this.Timer.Duration == 0)
            {
                // timer is still running or hasn't been set yet.
                this.HasChanged = false;
            }
            else
            {
                // timer expired. move one step forward.
                this.Value += this.Step;
                this.HasChanged = true;
                this.Timer.Restart();
            }

            return this.HasChanged;
        }

        public int Value; // the current value
        public Bool HasChanged; // if the timer expired this frame and the value changed
        public RepeatableTimerStruct Timer;
        public int Step; // added to value every time the timer expires
    }

    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct DirStruct
    {
        public DirStruct(int value)
        {
            Value = (short)value;
            unused_2 = default;
        }
        public DirStruct(double rad) : this()
        {
            this.radians(rad);
        }
        public DirStruct(uint bits, short value)
                : this((short)TranslateFixedPoint(bits, 16, (ushort)value, 0))
        { }

        public short GetValue(uint Bits = 16)
        {
            if (Bits > 0 && Bits <= 16)
            {
                return (short)(TranslateFixedPoint(16, Bits, (uint)(this.Value), 0));
            }
            else
            {
                throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");
            }
        }


        public void SetValue(short value, uint Bits = 16)
        {
            if (Bits > 0 && Bits <= 16)
            {
                this.Value = (short)TranslateFixedPoint(Bits, 16, (uint)(value), 0);
            }
            else
            {
                throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");
            }
        }

        public static uint TranslateFixedPoint(uint bitsFrom, uint bitsTo, uint value, uint offset = 0)
        {
            uint MaskIn = (1u << (int)bitsFrom) - 1;
            uint MaskOut = (1u << (int)bitsTo) - 1;

            if (bitsFrom > bitsTo)
            {
                // converting down
                return (((((value & MaskIn) >> (int)(bitsFrom - bitsTo - 1)) + 1) >> 1) + offset) & MaskOut;
            }
            else if (bitsFrom < bitsTo)
            {
                // converting up
                return (((value - offset) & MaskIn) << (int)(bitsTo - bitsFrom)) & MaskOut;
            }
            else
            {
                return value & MaskOut;
            }
        }

        public short value8()
        {
            return this.GetValue(3);
        }

        public void value8(short value)
        {
            this.SetValue(value, 3);
        }

        public short value32()
        {
            return this.GetValue(5);
        }

        public void value32(short value)
        {
            this.SetValue(value, 5);
        }

        public short value256()
        {
            return this.GetValue(8);
        }

        public void value256(short value)
        {
            this.SetValue(value, 8);
        }

        public short value()
        {
            return this.GetValue(16);
        }

        public void value(short value)
        {
            this.SetValue(value, 16);
        }

        public double radians(uint Bits = 16)
        {
            if (Bits > 0 && Bits <= 16)
            {
                int Max = (1 << (int)Bits) - 1;

                int value = Max / 4 - this.GetValue(Bits);
                return -value * -(Math.PI * 2 / Max);
            }
            else
            {
                throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");
            }
        }

        public void radians(double rad, uint Bits = 16)
        {
            if (Bits > 0 && Bits <= 16)
            {
                int Max = (1 << (int)Bits) - 1;

                int value = (int)(rad * (Max / Math.PI * 2));
                this.SetValue((short)(Max / 4 - value), Bits);
            }
            else
            {
                throw new InvalidOperationException("Bits has to be greater than 0 and lower or equal to 16.");
            }
        }

        public static bool operator ==(DirStruct a, DirStruct b)
        {
            return a.Value == b.Value;
        }
        public static bool operator !=(DirStruct a, DirStruct b) => !(a == b);
        public override bool Equals(object obj) => obj is DirStruct other && this == other;
        public override int GetHashCode() => Value.GetHashCode();

        public short Value;
        ushort unused_2;
    }

    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct FacingStruct
    {
        public FacingStruct(short rot) : this()
        {
            Timer = new TimerStruct(0);
            this.turn_rate(rot);
        }

        public short turn_rate()
        {
            return this.ROT.value();
        }

        public void turn_rate(short value)
        {
            if (value > 127)
            {
                value = 127;
            }

            this.ROT.SetValue(value, 8);
        }

        public bool in_motion()
        {
            return this.turn_rate() > 0 && this.Timer.GetTimeLeft() != 0;
        }

        public DirStruct target()
        {
            return this.Value;
        }

        public DirStruct current()
        {
            var ret = this.Value;

            if (this.in_motion())
            {
                var diff = this.difference();
                var num_steps = (short)(this.num_steps());

                if (num_steps > 0)
                {
                    var steps_left = this.Timer.GetTimeLeft();
                    ret.value((short)(ret.value() - steps_left * diff / num_steps));
                }
            }

            return ret;
        }

        public bool set(DirStruct value)
        {
            bool ret = (this.current() != value);

            if (ret)
            {
                this.Value = value;
                this.Initial = value;
            }

            this.Timer.Start(0);

            return ret;
        }

        public bool turn(DirStruct value)
        {
            if (this.Value == value)
            {
                return false;
            }

            this.Initial = this.current();
            this.Value = value;

            if (this.turn_rate() > 0)
            {
                this.Timer.Start(this.num_steps());
            }

            return true;
        }

        public short difference()
        {
            return (short)(this.Value.value() - this.Initial.value());
        }

        public int num_steps()
        {
            return Math.Abs((int)this.difference()) / (int)this.turn_rate();
        }

        public DirStruct Value; // target facing
        public DirStruct Initial; // rotation started here
        public TimerStruct Timer; // counts rotation steps
        public DirStruct ROT; // Rate of Turn. INI Value * 256
    }
}
