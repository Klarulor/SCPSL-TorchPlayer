using System;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace TorchPlayer
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        internal EventHandler EventHandler = new EventHandler();
        public override PluginPriority Priority { get; } = PluginPriority.Last;
        public Plugin() => Instance = this;
        public override string Name { get; } = typeof(Plugin).Namespace;
        public override string Author { get; } = "Klarulor";
        public override Version Version { get; } = new Version(1, 2, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 1, 0);

        public override void OnEnabled()
        {
            RegisterEvents();
            Log.Info($"Plugin {Name} started");
        }

        public override void OnDisabled() => UnregisterEvents();

        private void RegisterEvents()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers += EventHandler.OnWaitingForPlayers;
        }

        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= EventHandler.OnWaitingForPlayers;
        }
    }
}