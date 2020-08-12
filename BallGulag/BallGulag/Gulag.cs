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

        public Gulag()
        {
            queue = new List<Player>();
        }

        public void AddInQueue(Player player)
        {
            if (player1 == null)
            {
                player1 = player;
            }
            else if (player2 == null)
            {
                player2 = player;
            }
            else queue.Add(player);

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

                    }
                }

            }
            else { player.SetRole(RoleType.ClassD); }

            player.Health = player.MaxHealth;
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
            if (player.UserId == player1.UserId || player.UserId == player2.UserId) return true;
            return false;
        }

        private void giveBall()
        {
            player1.Broadcast(10,BallGulag.pluginInstance.Config.msg);
            player2.Broadcast(10, BallGulag.pluginInstance.Config.msg);
            player1.AddItem(ItemType.SCP018);
            player2.AddItem(ItemType.SCP018);
        }

        
    }
}
