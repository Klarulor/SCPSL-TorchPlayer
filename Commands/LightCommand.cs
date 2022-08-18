using System;
using CommandSystem;
using Exiled.API.Features;

namespace TorchPlayer.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class LightCommand : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (EventHandler.Lights.ContainsKey(player))
            {
                EventHandler.BurnLight(player);
                response = "Successfully removed light";
            }
            else
            {
                EventHandler.SpawnLight(player);
                response = "Successfully added light";
            }
            return true;
        }

        public string Command { get; } = "light";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Attach/detach a lightball to yourself";
    }
}