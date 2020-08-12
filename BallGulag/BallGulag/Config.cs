using System.Collections.Generic;
using System.ComponentModel;

using Exiled.API.Features;
using Exiled.API.Interfaces;
namespace BallGulag
{
    class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Message to display to players on gulag start, supports Unity  rich text")]
        public string msg { get; set; } = "Wellcome to the <color=red>gulag</color>, Use the ball to kill your enemy and survive";

        [Description("Command to kill everyone in the gulag ")]
        public string wipeCommand { get; set; } = "wipegulag";
    }
}
