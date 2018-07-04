using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib;


namespace BDD
{
    public class Fake : IDataManager
    {
        public void Load(out Manager manager)
        {
            manager = new Manager();

            TypeBatiment caserne = new TypeBatiment("Caserne","Permet de recruter des soldats");
            TypeBatiment caserne_elite = new TypeBatiment("Caserne d'élite");
            TypeBatiment archerie = new TypeBatiment("Archerie","Permet de recruter des unités capable d'attaquer à distance");
            TypeBatiment machines = new TypeBatiment("Machines de guerre","Permet de recruter des engins de siège");
            TypeBatiment forge = new TypeBatiment("Forge","Permet l'amélioration des armes et des armures");
            TypeBatiment forteresse = new TypeBatiment("Forteresse","Permet de recruter les héros et les bâtisseurs");
            Faction elfes = new Faction("Elfes","f_elfes.jpg");
            Faction nains = new Faction("Nains","f_nains.jpg");
            Faction isengard = new Faction("Isengard");
            Faction mordor = new Faction("Mordor","f_orcs.jpg");
            Faction gobelins = new Faction("Gobelins","f_gobelins.jpg");
            Faction hommes = new Faction("Hommes","f_hommes.jpg");

            mordor.ajouterBatiment(caserne, "Puits à Orcs");
            mordor.getBatiment(caserne).Image = "default.jpg";
            EtatBatiment etat001 = new EtatBatiment();
            etat001.Pdv = 5000;
            etat001.TpsDeConstruct = 45;
            etat001.UnitesRecrutables = "Epéistes orcs";
            mordor.getBatiment(caserne).ajouterEtat(etat001);

            EtatBatiment etat002 = new EtatBatiment();
            etat002.Pdv = 7000;
            etat002.TourDeDefense = true;
            etat002.TpsDeConstruct = 30;
            etat002.UnitesRecrutables = "Epéistes orcs, Archers orcs";
            etat002.BonusOctroyes = "Flèches enflammées";
            mordor.getBatiment(caserne).ajouterEtat(etat002);


            mordor.ajouterBatiment(caserne_elite, "Cage à trolls");
            creationEtatAvecImage(mordor, caserne_elite, "default.jpg");
            
            gobelins.ajouterBatiment(caserne, "Antre des araignées");
            creationEtatAvecImage(gobelins, caserne, "default.jpg");
            
            hommes.ajouterBatiment(caserne, "Caserne du Gondor");
            creationEtatAvecImage(hommes, caserne, "hommes/hom_caserne.jpg");

            hommes.ajouterBatiment(archerie, "Archerie du Gondor");
            creationEtatAvecImage(hommes, archerie, "hommes/hom_archerie.jpg");

            hommes.ajouterBatiment(machines, "Ecurie");
            creationEtatAvecImage(hommes, machines, "default.jpg");

            hommes.ajouterBatiment(forteresse, "Forteresse du Gondor");
            creationEtatAvecImage(hommes, forteresse, "hommes/hom_forteresse.jpg");

            isengard.ajouterBatiment(forteresse, "Forteresse de l'Isengard");
            creationEtatAvecImage(isengard, forteresse, "isengard/ise_forteresse.jpg");

            manager.AjouterFaction(hommes);
            manager.AjouterFaction(gobelins);
            manager.AjouterFaction(mordor);
            manager.AjouterFaction(elfes);
            manager.AjouterFaction(nains);
            manager.AjouterFaction(isengard);
            manager.AjouterTypeBatiment(caserne);
            manager.AjouterTypeBatiment(caserne_elite);
            manager.AjouterTypeBatiment(archerie);
            manager.AjouterTypeBatiment(forteresse);
            manager.AjouterTypeBatiment(forge);
            manager.AjouterTypeBatiment(machines);
        }

        public void Save(Manager manager)
        {
        }

        public void creationEtatAvecImage(Faction f, TypeBatiment tb, string image)
        {
            EtatBatiment etat = new EtatBatiment();
            f.getBatiment(tb).Image = image;
            f.getBatiment(tb).ajouterEtat(etat);
        }

    }
}
