using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDD;
using lib;

namespace ConsoleApplication1
{
    public class Test
    {
        public static void tester()
        {
            Manager manager = new Manager();

            Console.WriteLine("\n[Test #1]");
            #region Ajout de deux fois la même faction
            manager.AjouterFaction(new Faction("Lapins"));
            try
            {
                manager.AjouterFaction(new Faction("Lapins"));
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format("[Exception attrapée] {0}", e.Message));
                Console.ForegroundColor = ConsoleColor.White;
            }
            #endregion

            Console.WriteLine("[Test #2]");
            #region Ajout de deux fois le même type de bâtiment
            TypeBatiment caserne = new TypeBatiment("Caserne");
            manager.AjouterTypeBatiment(caserne);
            try
            {
                manager.AjouterTypeBatiment(caserne);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format("[Exception attrapée] {0}", e.Message));
                Console.ForegroundColor = ConsoleColor.White;
            }
            #endregion

            Console.WriteLine("[Test #3]");
            #region Ajout de deux bâtiments de même type dans la même faction
            manager.Factions[0].ajouterBatiment(caserne, "Caserne à lapins");
            try
            {
                manager.Factions[0].ajouterBatiment(caserne, "Centre d'entrainement de lapins");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format("[Exception attrapée] {0}", e.Message));
                Console.ForegroundColor = ConsoleColor.White;
            }
            #endregion

            Console.WriteLine("[Test #4]");
            #region Ajout de plus de 3 états à bâtiment
            manager.Factions[0].getBatiment(caserne).ajouterEtat(new EtatBatiment());
            manager.Factions[0].getBatiment(caserne).ajouterEtat(new EtatBatiment());
            manager.Factions[0].getBatiment(caserne).ajouterEtat(new EtatBatiment());
            try
            {
                manager.Factions[0].getBatiment(caserne).ajouterEtat(new EtatBatiment());
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format("[Exception attrapée] {0}", e.Message));
                Console.ForegroundColor = ConsoleColor.White;
            }
            #endregion

            Console.WriteLine("Affichage");
            #region Petit affichage
            foreach (TypeBatiment typ in manager.TypeBatiments)
            {
                Console.WriteLine(typ);
            }

            foreach (Faction fac in manager.Factions)
            {
                Console.WriteLine(fac);
            }
            #endregion

        }
    }
}
