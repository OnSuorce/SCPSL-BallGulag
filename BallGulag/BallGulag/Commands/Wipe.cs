using System;

using CommandSystem;

using Exiled.API.Features;

using RemoteAdmin;

namespace BallGulag.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Wipe : ICommand
    {
        public string Command { get; set; } = BallGulag.pluginInstance.Config.wipeCommand;

        public string[] Aliases { get; set; } = null;

        public string Description { get; set; } = "clears the gulag killing everybody";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = " ";
            BallGulag.pluginInstance.Gulag.wipe();
            return true;
        }
    }
}
