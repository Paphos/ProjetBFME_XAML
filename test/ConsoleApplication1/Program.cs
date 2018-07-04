using BDD;
using lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //static Manager manager = creationManager();

        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.DataMgr = new Fake();
            manager.Load();
            
            manager.DataMgr = new XMLDataMgr();
            manager.Save();

            Manager man2 = new Manager();
            man2.DataMgr = new XMLDataMgr();
            man2.Load();
             
            foreach (Faction f in man2.Factions)
            {
                Console.WriteLine(f);
            }

            foreach (TypeBatiment tb in man2.TypeBatiments)
            {
                Console.WriteLine(tb);
            }



            //AffichageMenu();
        }

        /*
        public static Manager creationManager()
        {
            Manager manager = new Manager();
            manager.DataMgr = new Fake();
            manager.Load();
            return manager;
        }

        public static void ChangedName(object sender, NameFactionChangedEventArgs args) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("La Faction s'appelle {0}", (sender as Faction).Nom);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void AffichageMenu() 
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("***************         M E N U         *************** \n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("     1. Modification des Factions ");
            Console.WriteLine("     2. Modification des Types de Bâtiments ");
            Console.WriteLine("     3. Modification des Bâtiments ");
            Console.WriteLine("     4. Modification des Etats des Bâtiments");
            Console.WriteLine("     5. Lancement du Test");
            Console.WriteLine("     6. Lancement du Linq");
            Console.WriteLine("     7. Lancement de l'événement\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saisissez un numéro entre 1 et 7");
            Console.ForegroundColor = ConsoleColor.White;
            string saisie = Console.ReadLine();
            int numchoisi = int.Parse(saisie);
            switch (numchoisi)
            {
                case 1:
                    AffichageMenuFaction();
                    break;
                case 2:
                    AffichageMenuTypeBatiment();
                    break;
                case 3:
                    AffichageMenuBatiment();
                    break;
                case 4:
                    AffichageMenuEtatsBatiment();
                    break;
                case 5:
                    Test.tester();
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le début de la faction de que vous recherchez :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieDeb = Console.ReadLine();
                    var linq = manager.RechercheFaction(saisieDeb);
                    foreach (var f in linq)
                    {
                       Console.WriteLine(f);
                    }
                    AffichageMenu();
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nouveau nom de la faction {0}:", manager.Factions[0]);
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieFac = Console.ReadLine();
                    manager.Factions[0].NameChanged += ChangedName;
                    manager.Factions[0].Nom = saisieFac;
                    AffichageMenu();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Le numéro saisi n'est pas compris entre 1 et 7, saisissez de nouveau un numéro.");
                    AffichageMenu();
                    break;
            }
        }

        public static void AffichageMenuFaction()
        {
            Console.WriteLine("***************         M E N U         ***************");
            Console.WriteLine("   ***         MODIFICATION DES FACTIONS         *** `\n");
            Console.WriteLine("     1. Ajouter une Faction");
            Console.WriteLine("     2. Supprimer une Faction");
            Console.WriteLine("     3. Affichage des Factions");
            Console.WriteLine("     4. Retour au Menu Principal \n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saisissez un numéro entre 1 et 4");
            Console.ForegroundColor = ConsoleColor.White;
            string saisieF = Console.ReadLine();
            int f = int.Parse(saisieF);
            switch (f)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom de la faction à créer :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomFC = Console.ReadLine();
                    manager.AjouterFaction(new Faction(saisieNomFC));
                    AffichageMenuFaction();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom de la faction à supprimer :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomFS = Console.ReadLine();
                    manager.SupprimerFaction(new Faction(saisieNomFS));
                    AffichageMenuFaction();
                    break;
                case 3 :
                    foreach (Faction fac in manager.Factions)
                    {
                        fac.NameChanged += ChangedName;
                        Console.WriteLine(fac);
                    }
                    AffichageMenuFaction();
                    break;
                case 4:
                    AffichageMenu();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Le numéro saisi n'est pas compris entre 1 et 4, saisissez de nouveau un numéro.");
                    Console.ForegroundColor = ConsoleColor.White;
                    AffichageMenuFaction();
                    break;
            }
        }

        public static void AffichageMenuTypeBatiment()
        {
            Console.WriteLine("***************         M E N U         ***************");
            Console.WriteLine("   ***    MODIFICATION DES TYPES DE BATIMENTS    *** `\n");
            Console.WriteLine("     1. Ajouter un type de bâtiment");
            Console.WriteLine("     2. Supprimer un type de bâtiment");
            Console.WriteLine("     3. Affichage des types de bâtiments");
            Console.WriteLine("     4. Retour au Menu Principal \n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saisissez un numéro entre 1 et 4");
            Console.ForegroundColor = ConsoleColor.White;
            string saisieF = Console.ReadLine();
            int f = int.Parse(saisieF);
            switch (f)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom du type de bâtiment à créer :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomTBC = Console.ReadLine();
                    manager.AjouterTypeBatiment(new TypeBatiment(saisieNomTBC));
                    AffichageMenuTypeBatiment();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom du type de bâtiment à supprimer :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomTBS = Console.ReadLine();
                    manager.SupprimerTypeBatiment(new TypeBatiment(saisieNomTBS));
                    AffichageMenuTypeBatiment();
                    break;
                case 3:
                    foreach (TypeBatiment typ in manager.TypeBatiments)
                    {
                        Console.WriteLine(typ);
                    }
                    AffichageMenuTypeBatiment();
                    break;
                case 4:
                    AffichageMenu();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Le numéro saisi n'est pas compris entre 1 et 4, saisissez de nouveau un numéro.");
                    Console.ForegroundColor = ConsoleColor.White;
                    AffichageMenuTypeBatiment();
                    break;
            }
        }

        public static void AffichageMenuBatiment()
        {
            Console.WriteLine("***************         M E N U         ***************");
            Console.WriteLine("   ***         MODIFICATION DES BATIMENTS        *** `\n");
            Console.WriteLine("     1. Ajouter un bâtiment");
            Console.WriteLine("     2. Supprimer un bâtiment");
            Console.WriteLine("     3. Affichage des bâtiments");
            Console.WriteLine("     4. Retour au Menu Principal \n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saisissez un numéro entre 1 et 4");
            Console.ForegroundColor = ConsoleColor.White;
            string saisieF = Console.ReadLine();
            int f = int.Parse(saisieF);
            switch (f)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom de la faction à laquelle vous souhaitez ajouter un bâtiment");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomFC = Console.ReadLine();
                    int i= manager.Factions.IndexOf(new Faction(saisieNomFC));
                    if (i < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La faction est inexistante");
                        Console.ForegroundColor = ConsoleColor.White;
                        AffichageMenuBatiment();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le type de bâtiment auquel vous souhaitez asssocier un bâtiment");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomTBBC = Console.ReadLine();
                    if (!(manager.TypeBatiments.Contains(new TypeBatiment(saisieNomTBBC)))) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Le type de bâtiment est inexistant");
                        Console.ForegroundColor = ConsoleColor.White;
                        AffichageMenuBatiment();
                    }
                    if (manager.Factions[i].Batiments.ContainsKey(new TypeBatiment(saisieNomTBBC)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Un bâtiment est déjà associé à ce Type de bâtiment");
                        Console.ForegroundColor = ConsoleColor.White;
                        AffichageMenuBatiment();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom du bâtiment à créer pour la faction '{0}' :", saisieNomTBBC);
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomBC = Console.ReadLine();
                    manager.Factions[i].ajouterBatiment(new TypeBatiment(saisieNomTBBC), saisieNomBC);
                    AffichageMenuBatiment();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom de la faction à laquelle vous souhaitez supprimer un bâtiment");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomFS = Console.ReadLine();
                    int p= manager.Factions.IndexOf(new Faction(saisieNomFS));
                    if (p < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La faction est inexistante");
                        Console.ForegroundColor = ConsoleColor.White;
                        AffichageMenuBatiment();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom du Type de bâtiment dont le bâtiment est à supprimer :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomTBBS = Console.ReadLine();
                    if (!manager.TypeBatiments.Contains(new TypeBatiment(saisieNomTBBS)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Le type de bâtiment est inexistant");
                        Console.ForegroundColor = ConsoleColor.White;
                        AffichageMenuBatiment();
                    }
                    manager.Factions[p].supprimerBatiment(new TypeBatiment(saisieNomTBBS));
                    AffichageMenuBatiment();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom de la faction à laquelle vous souhaitez afficher le(s) bâtiment(s)");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomFA = Console.ReadLine();
                    int m= manager.Factions.IndexOf(new Faction(saisieNomFA));
                    if (m < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La faction est inexistante");
                        Console.ForegroundColor = ConsoleColor.White;
                        AffichageMenuBatiment();
                    }
                    foreach(Batiment bat in manager.Factions[m].Batiments.Values)
                    { 
                    Console.WriteLine(bat);
                    }
                    AffichageMenuBatiment();
                    break;
                case 4:
                    AffichageMenu();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Le numéro saisi n'est pas compris entre 1 et 4, saisissez de nouveau un numéro.");
                    Console.ForegroundColor = ConsoleColor.White;
                    AffichageMenuBatiment();
                    break;
            }
        }

        public static void AffichageMenuEtatsBatiment()
        {
            Console.WriteLine("***************         M E N U         ***************");
            Console.WriteLine("   ***    MODIFICATION DES ETATS DES BATIMENTS   *** `\n");
            Console.WriteLine("     1. Ajouter un état à un bâtiment");
            Console.WriteLine("     2. Supprimer un état à un bâtiment");
            Console.WriteLine("     3. Affichage des états d'un bâtiments");
            Console.WriteLine("     4. Retour au Menu Principal \n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saisissez un numéro entre 1 et 4");
            Console.ForegroundColor = ConsoleColor.White;
            string saisieF = Console.ReadLine();
            int f = int.Parse(saisieF);
            switch (f)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom de la faction à laquelle vous souhaiter ajouter un état d'un bâtiment :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomFC = Console.ReadLine();
                    int i= manager.Factions.IndexOf(new Faction(saisieNomFC));
                    if (i < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La faction est inexistante");
                        Console.ForegroundColor = ConsoleColor.White;
                        AffichageMenuEtatsBatiment();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom du type du bâtiment auquel vous souhaiter ajouter un état d'un bâtiment :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomTBC = Console.ReadLine();
                    if (!manager.TypeBatiments.Contains(new TypeBatiment(saisieNomTBC))) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Le type de bâtiment est inexistant");
                        Console.ForegroundColor = ConsoleColor.White;
                        AffichageMenuEtatsBatiment();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nombre de points de vie:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisiePV = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Capacité :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieCapacite = Console.ReadLine();
                    manager.Factions[i].Batiments[new TypeBatiment(saisieNomTBC)].ajouterEtat(new EtatBatiment());
                    int u = manager.Factions[i].Batiments[new TypeBatiment(saisieNomTBC)].Count;
                    manager.Factions[i].Batiments[new TypeBatiment(saisieNomTBC)][u].Pdv = int.Parse(saisiePV);
                    manager.Factions[i].Batiments[new TypeBatiment(saisieNomTBC)][u].Capacite = int.Parse(saisieCapacite);
                    AffichageMenuEtatsBatiment();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom de la faction à laquelle vous souhaiter supprimer un état d'un bâtiment :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomFS = Console.ReadLine();
                    int y= manager.Factions.IndexOf(new Faction(saisieNomFS));
                    if (y < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La faction est inexistante");
                        Console.ForegroundColor = ConsoleColor.White;
                        AffichageMenuEtatsBatiment();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom du Type de bâtiment dont le bâtiment est à supprimer :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomTBBS = Console.ReadLine();
                    if (!manager.TypeBatiments.Contains(new TypeBatiment(saisieNomTBBS))) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Le type de bâtiment est inexistant");
                        Console.ForegroundColor = ConsoleColor.White;
                        AffichageMenuEtatsBatiment();
                    }
                    manager.Factions[y].supprimerBatiment(new TypeBatiment(saisieNomTBBS));
                    AffichageMenuEtatsBatiment();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Saisissez le nom de la faction à laquelle vous souhaitez afficher le/les état(s) d'un bâtiment :");
                    Console.ForegroundColor = ConsoleColor.White;
                    string saisieNomF = Console.ReadLine();
                    int o = manager.Factions.IndexOf(new Faction(saisieNomF));
                    if (o < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La faction est inexistante");
                        Console.ForegroundColor = ConsoleColor.White;
                        AffichageMenuEtatsBatiment();
                    }
                    foreach (Batiment bat in manager.Factions[o].Batiments.Values)
                    {
                        Console.WriteLine(bat);
                    }
                    AffichageMenuEtatsBatiment();
                    break;
                case 4:
                    AffichageMenu();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Le numéro saisi n'est pas compris entre 1 et 4, saisissez de nouveau un numéro.");
                    Console.ForegroundColor = ConsoleColor.White;
                    AffichageMenuEtatsBatiment();
                    break;
            }
        }

        */

    }
}

