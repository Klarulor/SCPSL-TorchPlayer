using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;

namespace TorchPlayer.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class LightAttachCommand : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count == 0)
            {
                response = "First argument should be a number";
                return false;
            }
            bool rainbow = false;
            if (arguments.Count == 2)
            {
                if (!bool.TryParse(arguments.At(1), out rainbow))
                {
                    response = "true/false";
                    return false;
                }
            }
            
            Player player = Player.Get(sender);
            if (!Plugin.Instance.Config.RainbowRoleAllowd.Contains(player.GroupName))
            {
                response = "You don't have a permissions!";
                return false;
            }
            if (Player.TryGet(arguments.At(0), out Player target))
            {
                if (EventHandler.Lights.ContainsKey(target))
                {
                    EventHandler.BurnLight(target);
                    response = $"Successfully removed lightball from {target}";
                }
                else
                {
                    EventHandler.SpawnLight(target, rainbow);
                    response = $"Successfully added lightball from {target}";
                }
            }
            else
            {
                response = "Player cannot be found";
                return false;
            }
            
            return false;
        }

        public string Command { get; } = "setlight";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Attach light to other player. attachlight <ID>";
    }
}