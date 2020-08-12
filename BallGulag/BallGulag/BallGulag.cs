using System;
using Exiled.API.Features;


namespace BallGulag
{
    class BallGulag : Plugin<Config>
    {
        private static readonly Lazy<BallGulag> LazyInstance = new Lazy<BallGulag>(() => new BallGulag());
        public static BallGulag pluginInstance => LazyInstance.Value;
        private Handlers.GulagEvent GulagEvent;

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
            //Exiled.Events.Handlers.Player.Died += GulagEvent.OnDeath;
            
        }
        public void UnRegister()
        {
            //Exiled.Events.Handlers.Scp914.UpgradingItems -= GulagEvent.OnUpgrading;
            //Exiled.Events.Handlers.Player.Died -= GulagEvent.OnPlayerDead;

            GulagEvent = null;
        }
    }
}