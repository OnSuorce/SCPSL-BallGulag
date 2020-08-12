using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;

namespace BallGulag.Handlers
{
    class GulagEvent
    {
        public Gulag GulagRef;



        public GulagEvent()
        {
            GulagRef = new Gulag();
            BallGulagPlugin.pluginInstance.gulag = GulagRef;
        }
        public void onPlayerDeath(DiedEventArgs ev) 
        {
            try
            {
                Log.Info($"{ev.Target}");
                Log.Info($"{ev.Killer}");
                if (!(GulagRef.hasBeenInGulag(ev.Target) || GulagRef.isInGulag(ev.Target)))
                    {
                        Log.Info($"{ev.Target.Nickname} dead");
                        GulagRef.AddInQueue(ev.Target);
                
                }
                if (GulagRef.isInGulag(ev.Target))
                {
                        GulagRef.getWinner(ev.Target);

                }
            }catch(Exception ex)
            {
                Log.Info(ex.ToString());
            }
            
        }

        bool flag = true;
        public void onSpawn(SpawningEventArgs ev)
        {
            if (flag)
            {
                flag = false;
                return;
            }

            if (GulagRef.isInQueue(ev.Player)) 
            {
                GulagRef.remove(ev.Player);
            }
        }
        

    }
}
