using System;
using Exiled.API.Features;


namespace BallGulag
{
    class BallGulagPlugin : Plugin<Config>
    {
        private static readonly Lazy<BallGulagPlugin> LazyInstance = new Lazy<BallGulagPlugin>(() => new BallGulagPlugin());
        public static BallGulagPlugin pluginInstance => LazyInstance.Value;
        private Handlers.GulagEvent GulagEvent;
        public Gulag gulag;
        

        public override void OnEnabled()
        {

            Register();
        }
        public override void OnDisabled()
        {
            UnRegister();
        }
        public void Register()
        {
            
            GulagEvent = new Handlers.GulagEvent();
            
            //Exiled.Events.Handlers.Scp914.UpgradingItems += GulagEvent;
            Exiled.Events.Handlers.Player.Died += GulagEvent.onPlayerDeath;
            Exiled.Events.Handlers.Player.Spawning += GulagEvent.onSpawn;
            
        }
        public void UnRegister()
        {
            //Exiled.Events.Handlers.Scp914.UpgradingItems -= GulagEvent.OnUpgrading;
            Exiled.Events.Handlers.Player.Died -= GulagEvent.onPlayerDeath;
            Exiled.Events.Handlers.Player.Spawning -= GulagEvent.onSpawn;

            GulagEvent = null;
            

        }
    }
}