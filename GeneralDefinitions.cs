﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    [Flags]
    public enum AbstractFlags
    {
        None = 0x0,
        Techno = 0x1,
        Object = 0x2,
        Foot = 0x4
    };

    public enum Armor
    {
        None = 0,
        Flak = 1,
        Plate = 2,
        Light = 3,
        Medium = 4,
        Heavy = 5,
        Wood = 6,
        Steel = 7,
        Concrete = 8,
        Special_1 = 9,
        Special_2 = 10
    }

    public enum AbstractType
    {
        None = 0,
        Unit = 1,
        Aircraft = 2,
        AircraftType = 3,
        Anim = 4,
        AnimType = 5,
        Building = 6,
        BuildingType = 7,
        Bullet = 8,
        BulletType = 9,
        Campaign = 10,
        Cell = 11,
        Factory = 12,
        House = 13,
        HouseType = 14,
        Infantry = 15,
        InfantryType = 16,
        Isotile = 17,
        IsotileType = 18,
        BuildingLight = 19,
        Overlay = 20,
        OverlayType = 21,
        Particle = 22,
        ParticleType = 23,
        ParticleSystem = 24,
        ParticleSystemType = 25,
        Script = 26,
        ScriptType = 27,
        Side = 28,
        Smudge = 29,
        SmudgeType = 30,
        Special = 31,
        SuperWeaponType = 32,
        TaskForce = 33,
        Team = 34,
        TeamType = 35,
        Terrain = 36,
        TerrainType = 37,
        Trigger = 38,
        TriggerType = 39,
        UnitType = 40,
        VoxelAnim = 41,
        VoxelAnimType = 42,
        Wave = 43,
        Tag = 44,
        TagType = 45,
        Tiberium = 46,
        Action = 47,
        Event = 48,
        WeaponType = 49,
        WarheadType = 50,
        Waypoint = 51,
        Abstract = 52,
        Tube = 53,
        LightSource = 54,
        EMPulse = 55,
        TacticalMap = 56,
        Super = 57,
        AITrigger = 58,
        AITriggerType = 59,
        Neuron = 60,
        FoggedObject = 61,
        AlphaShape = 62,
        VeinholeMonster = 63,
        NavyType = 64,
        SpawnManager = 65,
        CaptureManager = 66,
        Parasite = 67,
        Bomb = 68,
        RadSite = 69,
        Temporal = 70,
        Airstrike = 71,
        SlaveManager = 72,
        DiskLaser = 73
    };

    public enum DamageState
    {
        Unaffected = 0,
        Unchanged = 1,
        NowYellow = 2,
        NowRed = 3,
        NowDead = 4,
        PostMortem = 5
    };

    public enum DamageAreaResult
    {
        Hit = 0,
        Missed = 1,
        Nullified = 2
    };

    public enum KickOutResult
    {
        Failed = 0,
        Busy = 1,
        Succeeded = 2
    };

    public enum CanBuildResult
    {
        TemporarilyUnbuildable = -1, // black out cameo
	    Unbuildable = 0, // permanently; remove cameo
	    Buildable = 1, // can build
}   ;

    public enum Direction
    {
        N = 0x0,
        North = 0x0,
        NE = 0x1,
        NorthEast = 0x1,
        E = 0x2,
        East = 0x2,
        SE = 0x3,
        SouthEast = 0x3,
        S = 0x4,
        South = 0x4,
        SW = 0x5,
        SouthWest = 0x5,
        W = 0x6,
        West = 0x6,
        NW = 0x7,
        NorthWest = 0x7,
    };

    public enum SpotlightFlags
    {
        None = 0x0,
        NoColor = 0x1,
        NoRed = 0x2,
        NoGreen = 0x4,
        NoBlue = 0x8
    };
    public enum LandType
    {
        Clear = 0,
        Road = 1,
        Water = 2,
        Rock = 3,
        Wall = 4,
        Tiberium = 5,
        Beach = 6,
        Rough = 7,
        Ice = 8,
        Railroad = 9,
        Tunnel = 10,
        Weeds = 11
    };

    public enum Layer
    {
        None = -1,
        Underground = 0,
        Surface = 1,
        Ground = 2,
        Air = 3,
        Top = 4
    };

    public enum PlacementType
    {
        Remove = 0,
        Put = 1,
        Redraw = 2,
        AddContent = 3
    };

    public enum ChargeDrainState
    {
        None = -1,
        Charging = 0,
        Ready = 1,
        Draining = 2
    };

    public enum SuperWeaponType
    {
        Invalid = -1,
        Nuke = 0,
        IronCurtain = 1,
        LightningStorm = 2,
        ChronoSphere = 3,
        ChronoWarp = 4,
        ParaDrop = 5,
        AmerParaDrop = 6,
        PsychicDominator = 7,
        SpyPlane = 8,
        GeneticMutator = 9,
        ForceShield = 10,
        PsychicReveal = 11
    };

    [Flags]
    public enum BlitterFlags
    {
        None = 0x0,
        Darken = 0x1,
        TransLucent25 = 0x2,
        TransLucent50 = 0x4,
        TransLucent75 = 0x6,
        Warp = 0x8,
        ZRemap = 0x10,
        Plain = 0x20,
        bf_040 = 0x40,
        bf_080 = 0x80,
        MultiPass = 0x100,
        Centered = 0x200,
        bf_400 = 0x400,
        Alpha = 0x800,
        bf_1000 = 0x1000,
        Flat = 0x2000,
        ZRead = 0x3000,
        ZReadWrite = 0x4000,
        bf_8000 = 0x8000,
        Zero = 0x10000,
        Nonzero = 0x20000
    };

    public enum VisualType
    {
        Normal = 0,
        Indistinct = 1,
        Darken = 2,
        Shadowy = 3,
        Ripple = 4,
        Hidden = 5
    };

    public enum Move
    {
        OK = 0,
        Cloak = 1,
        MovingBlock = 2,
        ClosedGate = 3,
        FriendlyDestroyable = 4,
        Destroyable = 5,
        Temp = 6,
        No = 7
    };

    public enum ZGradient
    {
        None = -1,
        Ground = 0,
        Deg45 = 1,
        Deg90 = 2,
        Deg135 = 3
    };

    // this is how game's enums are to be defined from now on
    public enum FireError
    {
        NONE = -1, // no valid value
        OK = 0, // no problem, can fire
        AMMO = 1, // no ammo
        FACING = 2, // bad facing
        REARM = 3, // still reloading
        ROTATING = 4, // busy rotating
        ILLEGAL = 5, // can't fire
        CANT = 6, // I'm sorry Dave, I can't do that
        MOVING = 7, // moving, can't fire
        RANGE = 8, // out of range
        CLOAKED = 9, // need to decloak
        BUSY = 10, // busy, please hold
        MUST_DEPLOY = 11 // deploy first!
    };
    public enum Rank
    {
        Invalid = -1,
        Elite = 0,
        Veteran = 1,
        Rookie = 2
    };

    public enum SpeedType
    {
        None = -1,
        Foot = 0,
        Track = 1,
        Wheel = 2,
        Hover = 3,
        Winged = 4,
        Float = 5,
        Amphibious = 6,
        FloatBeach = 7
    };

    public enum MovementZone
    {
        None = -1,
        Normal = 0,
        Crusher = 1,
        Destroyer = 2,
        AmphibiousDestroyer = 3,
        AmphibiousCrusher = 4,
        Amphibious = 5,
        Subterrannean = 6,
        Infantry = 7,
        InfantryDestroyer = 8,
        Fly = 9,
        Water = 10,
        WaterBeach = 11,
        CrusherAll = 12
    };

    public enum Mission
    {
        None = -1,
        Sleep = 0,
        Attack = 1,
        Move = 2,
        QMove = 3,
        Retreat = 4,
        Guard = 5,
        Sticky = 6,
        Enter = 7,
        Capture = 8,
        Eaten = 9,
        Harvest = 10,
        Area_Guard = 11,
        Return = 12,
        Stop = 13,
        Ambush = 14,
        Hunt = 15,
        Unload = 16,
        Sabotage = 17,
        Construction = 18,
        Selling = 19,
        Repair = 20,
        Rescue = 21,
        Missile = 22,
        Harmless = 23,
        Open = 24,
        Patrol = 25,
        ParadropApproach = 26,
        ParadropOverfly = 27,
        Wait = 28,
        AttackMove = 29,
        SpyplaneApproach = 30,
        SpyplaneOverfly = 31
    };

    [Flags]
    public enum TargetFlags
    {
        None = 0x0,
        unknown_1 = 0x1,
        unknown_2 = 0x2,
        Air = 0x4,
        Infantry = 0x8,
        Vehicles = 0x10,
        Buildings = 0x20,
        Economy = 0x40,
        Ships = 0x80, // from RA1
        Neutral = 0x100, // from RA1
        Capture = 0x200,
        Fakes = 0x400, // from RA1
        Power = 0x800,
        Factories = 0x1000,
        BaseDefense = 0x2000,
        Friendlies = 0x4000,
        Occupiable = 0x8000,
        TechCapture = 0x10000
    };

    public enum RadioCommand
    {
        AnswerInvalid = 0, // static (no message)
        AnswerPositive = 1, // Roger.
        RequestLink = 2, // Come in.
        NotifyUnlink = 3, // Over and out.
        RequestPickUp = 4,// "Please pick me up."
        RequestAttach = 5,// "Attach to transport."
        RequestDelivery = 6,// "I've got a delivery for you."
        NotifyBeginLoad = 7, // I'm performing load/unload maneuver. Be careful.
        NotifyUnloaded = 8, // I'm clear.
        RequestUnload = 9, // You are clear to unload. Driving away now.
        AnswerNegative = 10, // Am unable to comply.
        RequestBeginProduction = 11, // I'm starting construction now... act busy.
        RequestEndProduction = 12, // I've finished construction. You are free.
        RequestRedraw = 13, // We bumped, redraw yourself please.
        RequestLoading = 14, // I'm trying to load up now.
        AnswerLoading = 14, // Loading up now.
        QueryCanEnter = 15, // May I become a passenger?
        QueryCanUnload = 16, // Are you ready to receive shipment?
        QueryWantEnter = 17, // Are you trying to become a passenger?
        RequestMoveTo = 18, // Move to location X.
        QueryMoving = 19, // Do you need to move?
        AnswerAwaiting = 20, // All right already. Now what?
        RequestCompleteEnter = 21, // I'm a passenger now.
        RequestDockRefinery = 22, // Backup into refinery now.
        AnswerLeave = 23, // Run away!
        NotifyLeave = 23, // Running away.
        RequestTether = 24, // Tether established.
        RequestUntether = 25, // Tether broken.
        RequestAlternativeTether = 26, // Alternative tether established.
        RequestAlternativeUntether = 27, // Alternative tether broken.
        RequestRepair = 28, // Repair one step.
        QueryReadiness = 29, // Are you prepared to fight?
        RequestAttack = 30, // Attack this target please.
        RequestReload = 31, // Reload one step.
        AnswerBlocked = 32, // Circumstances prevent success.
        QueryDone = 33, // All done with the request?
        AnswerDone = 33, // All done with the request.
        QueryNeedRepair = 34, // Do you need service depot work?
        QueryOnBuilding = 35, // Are you located on top of me?
        QueryCanTote = 36, // Want ride
    };

    public enum NetworkEvents
    {
        Empty = 0x0,
        PowerOn = 0x1,
        PowerOff = 0x2,
        Ally = 0x3,
        MegaMission = 0x4,
        MegaMissionF = 0x5,
        Idle = 0x6,
        Scatter = 0x7,
        Destruct = 0x8,
        Deploy = 0x9,
        Detonate = 0xA,
        Place = 0xB,
        Options = 0xC,
        GameSpeed = 0xD,
        Produce = 0xE,
        Suspend = 0xF,
        Abandon = 0x10,
        Primary = 0x11,
        SpecialPlace = 0x12,
        Exit = 0x13,
        Animation = 0x14,
        Repair = 0x15,
        Sell = 0x16,
        SellCell = 0x17,
        Special = 0x18,
        FrameSync = 0x19,
        Message = 0x1A,
        ResponseTime = 0x1B,
        FrameInfo = 0x1C,
        SaveGame = 0x1D,
        Archive = 0x1E,
        AddPlayer = 0x1F,
        Timing = 0x20,
        ProcessTime = 0x21,
        PageUser = 0x22,
        RemovePlayer = 0x23,
        LatencyFudge = 0x24,
        MegaFrameInfo = 0x25,
        PacketTiming = 0x26,
        AboutToExit = 0x27,
        FallbackHost = 0x28,
        AddressChange = 0x29,
        PlanConnect = 0x2A,
        PlanCommit = 0x2B,
        PlanNodeDelete = 0x2C,
        AllCheer = 0x2D,
        AbandonAll = 0x2E
    };

    public enum MarkType
    {
        UP = 0,
        DOWN = 1,
        CHANGE = 2,
        CHANGE_REDRAW = 3,
        OVERLAP_DOWN = 4,
        OVERLAP_UP = 5
    }
    public enum Edge
    {
        None = -1,
        North = 0,
        East = 1,
        South = 2,
        West = 3,
        Air = 4
    };

    public enum GameMode
    {
        Campaign = 0x0,
        Modem = 0x1,		// modem game
        NullModem = 0x2,	// NULL-modem
        LAN = 0x3,
        Internet = 0x4,
        Skirmish = 0x5,
    };


	public enum RadBeamType
	{
		Temporal = 0x0,
		RadBeam = 0x1,
		Eruption = 0x2 // this sets the beam color to MagnaBeamColor! There probably was no reason for that whatsoever.
	};


}
