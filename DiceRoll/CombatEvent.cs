
using System;

namespace Monobius
{
    public class CombatEvent : Event
    {
        public int RoundCounter = 0;

        public override void Execute(GameManagerV2 gm)
        {
            gm.Player.Vessel.ResetWeapons();
            Vessel enemyVessel = gm.Map.EnemyVessels[0];
            gm.Map.EnemyVessels.RemoveAt(0);

            while (!IsEventConcluded)
            {
                CombatRound(gm, enemyVessel);

                RoundCounter++;
                if (RoundCounter % Vessel.kWeaponCount == 0)
                {
                    gm.Player.Vessel.ResetWeapons();
                    enemyVessel.ResetWeapons();
                    gm.Dialog.Write("***WEAPONS HAVE BEEN RESET***");
                    gm.Dialog.Write("");
                }
            }

            if (gm.Map.EnemyVessels.Count == 0)
            {
                Win(gm);
            }
        }

        public void CombatRound(GameManagerV2 gm, Vessel enemyVessel)
        {

            int playerVesselWeaponIndex = -1;

            while (playerVesselWeaponIndex < 0)
            {
                gm.Dialog.Write("Current ASSETS Online: ");
                gm.Dialog.Write("----------------------");

                //RUNS THROUGH ARRAY AND LIST TO RETURN STILL VALID WEAPONS OR QUEUE WEAPON RESET//
                for (int i = 0; i < gm.Player.Vessel.weaponsReady.Count; i++)
                {
                    int weaponIndex = gm.Player.Vessel.weaponsReady[i];
                    gm.Dialog.Write(gm.Player.Vessel.Weapons[weaponIndex].Name);
                }

                gm.Dialog.Write("----------------------");
                gm.Dialog.SelectWeapon();
                string playerVesselWeaponSelection = gm.InGameControlRead();
                playerVesselWeaponIndex = gm.Player.Vessel.GetAvailableWeaponIndexByName(playerVesselWeaponSelection);

                if (playerVesselWeaponIndex < 0)
                {
                    gm.Dialog.SelectionError();
                }
            }

            int enemyVesselWeaponIndex = enemyVessel.GetRandomAvailableWeaponIndex(gm.Dice);

            string enemyVesselCurrentWeapon = enemyVessel.Weapons[enemyVesselWeaponIndex].Name;
            string playerVesselCurrentWeapon = gm.Player.Vessel.Weapons[playerVesselWeaponIndex].Name;
            int playerVesselDice = gm.Player.Vessel.Weapons[playerVesselWeaponIndex].Attack;
            int enemyVesselDice = enemyVessel.Weapons[playerVesselWeaponIndex].Attack;
            int playerVesselRollResult = gm.Dice.Roll(playerVesselDice);
            int enemyVesselRollResult = gm.Dice.Roll(enemyVesselDice);
            int playerVesselAttackBonus = gm.Player.AttackBonus;
            int playerVesselDefenseBonus = gm.Player.DefenseBonus;

            playerVesselRollResult += playerVesselAttackBonus;

            gm.Dialog.RollRecap(gm.Player.Name, enemyVessel.Name, playerVesselRollResult, enemyVesselRollResult, playerVesselCurrentWeapon, enemyVesselCurrentWeapon);

            //IF PLAYER ROLES HIGHER...//
            if (playerVesselRollResult > enemyVesselRollResult)
            {
                int dmg = playerVesselRollResult - enemyVesselRollResult;
                enemyVessel.Health -= dmg;
                gm.Dialog.Write("");
                gm.Dialog.Write("The " + enemyVessel.Name + " takes " + dmg + " damage.");

            }
            //IF ENEMY ROLES HIGHER...//
            else if (playerVesselRollResult < enemyVesselRollResult)
            {
                int dmg = enemyVesselRollResult - playerVesselRollResult;
                dmg -= playerVesselDefenseBonus;

                if (dmg > 0)
                {
                    gm.Player.Vessel.Health -= dmg;
                    gm.Dialog.Write("");
                    gm.Dialog.Write("The " + gm.Player.Vessel.Name + " takes " + dmg + " damage.");
                }
                else
                {
                    gm.Dialog.Write("Your shields absord the weak attack.");
                }


            }
            //IF BOTH SHIPS ROLL THE SAME//
            else
            {
                gm.Dialog.Write("");
                gm.Dialog.Write("Weapons cancel each other out.");
                gm.Dialog.Write("No one takes damage.");

            }

            gm.Dialog.RoundRecap(gm.Player.Vessel.Name, enemyVessel.Name, gm.Player.Vessel.Health, enemyVessel.Health);

            if (gm.Player.Vessel.Health <= 0)
            {
                gm.Dialog.Write(gm.Player.Vessel.Name + " was killed by the enemy.");
                gm.IsPlayerAlive = false;
                IsEventConcluded = true;
                Lose(gm);
            }

            if (enemyVessel.Health <= 0)
            {
                gm.Dialog.Write(enemyVessel.Name + " was killed by the enemy.");
                IsEventConcluded = true;
                Console.ReadLine();
            }
        }

        public void Lose(GameManagerV2 gm)
        {
            gm.IsGameRunning = false;
            Console.ReadLine();
        }

        public void Win(GameManagerV2 gm)
        {
            gm.IsGameRunning = false;
            Console.ReadLine();
        }
    }
}