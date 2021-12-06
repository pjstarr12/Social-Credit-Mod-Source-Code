using UnityEngine; 
using System.Collections;
//https://discord.gg/ZJaTzsCfGQ (my discord server)
namespace Mod
{
    public class Mod
    {
        public static void Main()
        { 
            var Credit = 300f;
            var Penalty = 1f; //define stats
            ModAPI.OnDeath += (sender, life) => { //called whenever something dies
                Credit -= 20f * Penalty; //negates 20 credit with some penalty
                Penalty += 0.1f; //penalty increases
                ModAPI.Notify("-20 Social Credit. Current credit: " + "\n <color=orange>" + Mathf.Round(Credit * 10) / 10); //tells the user that they fked up
                if (Credit < -2500f) {  //if your credit is lower then -2500 then
                    Application.Quit(); //the game quits
                }
            };

            ModAPI.OnGunShot += (sender, gun) => {
                Credit -= 5 * Penalty;
                Penalty += 0.03f;
                ModAPI.Notify("-5 Social Credit. Current credit: " + "\n <color=orange>" + Mathf.Round(Credit * 10) / 10);
                if (Credit < -2500f) { 
                    Application.Quit();
                }
            };
            ModAPI.OnItemSpawned += (sender, args) => {
                Credit += 1;
                ModAPI.Notify("+1 Social Credit. Current credit: " + "\n <color=orange>" + Mathf.Round(Credit * 10) / 10);
                if (Credit < -2500f) { 
                    Application.Quit();
                }
            };
        }
    }
}
//https://discord.gg/ZJaTzsCfGQ (my discord server)