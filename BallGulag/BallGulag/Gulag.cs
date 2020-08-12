using Exiled.API.Features;
using System;
using System.Collections;
using System.Collections.Generic;


namespace BallGulag
{
    class Gulag
    {
        Player player1;
        Player player2;
        List<Player> queue;
        List<Player> alreadyBeenInGulag;

        public Gulag()
        {
            queue = new List<Player>();
            alreadyBeenInGulag = new List<Player>();
        }

        public Player[] GetPlayersInGulag()
        {
            Player[] players = { player1, player2 };
            return players;
        }

        public void wipe()
        {       
            player1.Hurt(player1.MaxHealth);
            player2.Hurt(player2.MaxHealth);
            player1.ShowHint("Gulag wiped from admins");
            player2.ShowHint("Gulag wiped from admins");
        }

        private bool hasBeenInGulag(Player player)
        {
            Log.Info($"started has been in gulag");
            foreach (var playr in alreadyBeenInGulag)
            {
                if(playr.UserId == player.UserId)
                {
                    return true;
                }
            }
            Log.Info($"finished has been in gulag");
            return false;
        }
        public void AddInQueue(Player player)
        {
            Log.Info($"started add in queue");
            if (hasBeenInGulag(player))
            {
                return;
            }
            queue.Add(player);

            player.Broadcast(5, "You are in queue for the <color=red>Gulag</color>");

            if (queue.Count == 2)
            {
                start();
            }
        }

        private void start()
        {
            player1 = queue[0];
            player2 = queue[1];

            player1.SetRole(RoleType.Tutorial);
            player2.SetRole(RoleType.Tutorial);
            giveBall();

        }

        private void respawnWinner(Player player)
        {

            if (Map.IsLCZDecontaminated)

            {
                foreach (var room in Map.Rooms)
                {
                    if (room.Name == "HCZ_049")
                    {
                        player.SetRole(RoleType.ClassD);
                        player.Position = room.Position;
                        player.AddItem(ItemType.GunProject90);
                        player.SetAmmo(Exiled.API.Enums.AmmoType.Nato9, 100);
                        player.AddItem(ItemType.Radio);
                        player.AddItem(ItemType.Flashlight);
                        player.AddItem(ItemType.KeycardChaosInsurgency);

                    }
                }

            }
            else
            {
                player.SetRole(RoleType.Scientist);
                player.AddItem(ItemType.GunUSP);
                player.SetAmmo(Exiled.API.Enums.AmmoType.Nato556, 100);     
                player.AddItem(ItemType.Flashlight);
                player.AddItem(ItemType.KeycardJanitor);
            }


            player.Health = player.MaxHealth;
            var players = Player.List;
            foreach(Player playr in players)
            {
                playr.SendConsoleMessage($"GulagPlugin: {player.Nickname} Escaped form the gulag", "red");
            }
        }

        public void getWinner(Player dead)
        {
            if(dead.UserId == player1.UserId)
            {
                respawnWinner(player2);

            }else if(dead.UserId == player2.UserId)
            {
                respawnWinner(player1);
            }
        }

        public bool isInGulag(Player player)
        {
            if (player1 != null)
            {
                if (player.UserId == player1.UserId)
                {
                    return true;
                }
            }
            if(player2 != null)
            {
                if (player.UserId == player2.UserId)
                {
                    return true;
                }
            }
            
            return false;
        }

        private void giveBall()
        {
            player1.Broadcast(10,BallGulagPlugin.pluginInstance.Config.msg);
            player2.Broadcast(10, BallGulagPlugin.pluginInstance.Config.msg);
            player1.AddItem(ItemType.SCP018);
            player2.AddItem(ItemType.SCP018);
        }

        
    }
}
