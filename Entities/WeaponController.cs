using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSurvivors.Entities
{
    public class WeaponController
    {
        private List<Weapon> weapons;
        private int selectedWeapon;
        public Weapon CurrentWeapon => weapons[selectedWeapon];
        public WeaponController()
        {
            this.weapons = new List<Weapon>();
            this.selectedWeapon = -1;
        }

        public WeaponController(List<Weapon> weapons) {
            this.weapons = weapons;
            this.selectedWeapon = 0;
        }

        public void SelectWeapon(int weaponID) { 
            if( weaponID < 0 || weaponID > this.weapons.Count)
            {
                throw new ArgumentOutOfRangeException("Weapon index out of bounds");
            }

            selectedWeapon = weaponID;
        }

        internal void AddWeapon(Weapon weapon)
        {
            this.weapons.Add(weapon);
            this.selectedWeapon = this.weapons.Count - 1;
        }
    }
}
