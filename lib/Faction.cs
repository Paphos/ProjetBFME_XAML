using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    [DataContract]
    public class Faction
    {
        #region L'évènement
        public event EventHandler<NameFactionChangedEventArgs> NameChanged;

        protected virtual void OnNameChanged(NameFactionChangedEventArgs args)
        {
            if (NameChanged != null)
            {
                NameChanged(this, args);
            }
        }
        #endregion

        [DataMember]
        private string mNom;
        [DataMember]
        public string Nom
        {
            get { return mNom; }
            set { 
                mNom = value;
                OnNameChanged(new NameFactionChangedEventArgs(value));
                }
        }

        [DataMember]
        public string Image{get;set;}

        [DataMember]
        private Dictionary<TypeBatiment, Batiment> Batiments { get; set; }

        public Faction(string nom) : this(nom,null){}
        
        public Faction(string nom, string image)
        {
            Batiments = new Dictionary<TypeBatiment, Batiment>();
            Nom = nom;
            Image = image;
        }

        public void ajouterBatiment(TypeBatiment tb, string nomBatiment)
        {
            Batiments.Add(tb,new Batiment(nomBatiment));
        }

        public void supprimerBatiment(TypeBatiment tb)
        {
            Batiments.Remove(tb);
        }

        public bool contientBatimentDeType(TypeBatiment tb)
        {
            return Batiments.ContainsKey(tb);
        }

        public Batiment getBatiment(TypeBatiment tb)
        {
            return Batiments[tb];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<Faction> {0} {1}\n", Nom, Image);
            foreach(KeyValuePair<TypeBatiment,Batiment> pair in Batiments){
                sb.AppendFormat("{0}\n{1}", pair.Key, pair.Value);
            }
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode() * 31;
        }

        public override bool Equals(object right)
        {
            if (object.ReferenceEquals(right, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, right))
            {
                return true;
            }

            if (this.GetType() != right.GetType())
            {
                return false;
            }

            return this.Equals(right as Faction);
        }

        public bool Equals(Faction other)
        {
            return (this.Nom.ToLower() == other.Nom.ToLower());
        }
    }
}
