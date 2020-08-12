using System;

using CommandSystem;

using Exiled.API.Features;

using RemoteAdmin;

namespace BallGulag.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Wipe : ICommand
    {
        public string Command { get; set; } = BallGulagPlugin.pluginInstance.Config.wipeCommand;

        public string[] Aliases { get; set; } = null;

        public string Description { get; set; } = "clears the gulag killing everybody";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Sending wipe command";
            
            if (sender is PlayerCommandSender player)
            {
                BallGulagPlugin.pluginInstance.gulag.wipe();
                response = $" sent the command!";
                var a = Player.Get(player.SenderId);
                a.RemoteAdminMessage("Wiped!");
            }
         
            return true;
        }

    }
}
