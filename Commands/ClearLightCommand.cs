using System;
using CommandSystem;
using Exiled.API.Features;

namespace TorchPlayer.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ClearLightCommand : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (!Plugin.Instance.Config.RainbowRoleAllowd.Contains(player.GroupName))
            {
                response = "You don't have a permissions!";
                return false;
            }

            response = $"Successfully removed from {EventHandler.Lights.Count} players";
            EventHandler.BurnAllLights();
            return true;
        }

        public string Command { get; } = "clearlights";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Burn all lights";
    }
}