using System;

namespace DoomSurvivors.Entities
{
    public class ItemAction
    {
        private Action<Player> action;
        private Sound sound;

        public ItemAction(Action<Player> action, Sound sound)
        {
            this.action = action;
            this.sound = sound;
        }

        public void Invoke(Player player)
        {
            this.action(player);
            this.sound.PlayOnce();
        }
    }
}