using System.Collections.Generic;
using System.ComponentModel;

using Exiled.API.Features;
using Exiled.API.Interfaces;
namespace BallGulag
{
    class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}
