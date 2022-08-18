using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using TorchPlayer.Features;

namespace TorchPlayer
{
    public sealed class Config : IConfig
    {
        [Description("Enable")] 
        public bool IsEnabled { get; set; } = true;

        [Description("Light intensity")]
        public float LightIntensity { get; set; } = 0.3f;
        
        [Description("Light range")]
        public float LightRange { get; set; } = 10f;
        
        [Description("Light shadows")]
        public bool LightShadow { get; set; } = true;

        [Description("Default light color")]
        public SerializableColor LightColor { get; set; } = new SerializableColor(255, 255, 255, 1);

        [Description("Rainbow frames")]
        public RainbowColorIteration[] RainbowFrames { get; set; } = new RainbowColorIteration[]
        {
            new RainbowColorIteration(), new RainbowColorIteration()
        };

        [Description("Badge names with raionbow allowed")]
        public string[] RainbowRoleAllowd { get; set; } = new string[]
        {
            "owner",
            "admin"
        };

    }
}