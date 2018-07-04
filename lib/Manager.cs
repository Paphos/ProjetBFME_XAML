using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lib
{
    [DataContract]
    public class Manager
    {
        public IDataManager DataMgr { get; set; }

        [DataMember]
        public ObservableCollection<TypeBatiment> TypeBatiments { get; private set; }

        [DataMember]
        public ObservableCollection<Faction> Factions { get; private set; }

        public Manager(){
            Factions = new ObservableCollection<Faction>();
            TypeBatiments = new ObservableCollection<TypeBatiment>();
        }

        public void AjouterFaction(Faction f)
        {
            if (Factions.Contains(f))
            {
                throw new Exception("Cette faction est déjà présente dans la liste.");
            }
            Factions.Add(f);
        }

        public void SupprimerFaction(Faction f)
        {
            Factions.Remove(f);
        }

        public void AjouterTypeBatiment(TypeBatiment tb)
        {
            if (TypeBatiments.Contains(tb))
            {
                throw new Exception("Ce type de bâtiment est déjà présent dans la liste.");
            }
            TypeBatiments.Add(tb);
        }

        public void SupprimerTypeBatiment(TypeBatiment tb)
        {
            TypeBatiments.Remove(tb);
            foreach (Faction f in Factions)
            {
                if (f.contientBatimentDeType(tb))
                {
                    f.supprimerBatiment(tb);
                }
            }
        }

        public void Save()
        {
            DataMgr.Save(this);
        }

        public void Load()
        {
            Manager tmp;
            DataMgr.Load(out tmp);

            this.Factions = tmp.Factions;
            this.TypeBatiments = tmp.TypeBatiments;
        }

        public IEnumerable<Faction> RechercheFaction(string texte)
        {
            var linq = Factions.Where(f => f.Nom.StartsWith(texte));
            return linq;
        }

    }
}
