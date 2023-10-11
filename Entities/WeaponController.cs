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
    }
}
