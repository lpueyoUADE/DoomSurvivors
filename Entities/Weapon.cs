using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Entities
{
    public enum WeaponID
    {
        Chainsaw,
        Pistol,
        Shotgun,
        SuperShotgun,
        Minigun,
        RocketLauncher,
        PlasmaRifle,
        BFG
    }

    public enum Mechanism
    {
        SemiAutomatic,
        Automatic
    }
    public class Weapon
    {
        private WeaponID weaponID;
        private Mechanism mechanism;
        private int ammo;
        private float cooldown;
        
        public Weapon(WeaponID weaponID, Mechanism mechanism, int ammo, float cooldown)
        {
            this.weaponID = weaponID;
            this.mechanism = mechanism;
            this.ammo = ammo;
            this.cooldown = cooldown;
        }
        
        public void Shoot() {
            Console.WriteLine("PUM");
        }
    }
}
