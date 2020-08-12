using System;

using CommandSystem;

using Exiled.API.Features;

using RemoteAdmin;

namespace BallGulag.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    class RemoveFromQueue : ICommand
    {
        public string Command { get; set; } = BallGulagPlugin.pluginInstance.Config.removeCommand;

        public string[] Aliases { get; set; } = null;

        public string Description { get; set; } = "Removes the sender from the queue";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            response = "";
            if (sender is PlayerCommandSender player)
            {

                var a = Player.Get(player.SenderId);
                BallGulagPlugin.pluginInstance.gulag.remove(a);
                
                
                a.SendConsoleMessage("Removed!","yellow");
            }
         
            return true;
        }

    }
}
