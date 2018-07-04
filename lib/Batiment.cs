using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    [DataContract]
    public class Batiment : IEquatable<Batiment>
    {
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        private List<EtatBatiment> Etats = new List<EtatBatiment>();
        [DataMember]
        public int Count { get; private set; }
        [DataMember]
        public string Image { get; set; }

        public Batiment()
        {
        }

        /// <summary>
        /// Constructeur de la classe Batiment
        /// </summary>
        /// <param name="nom">Nom du batiment</param>
        public Batiment(string nom)
        {
            Nom = nom;
        }

        /// <summary>
        /// Si le nombre d'état est inférieur au nombre d'état max(3), alors on ajoute un état à la liste Etats
        /// </summary>
        /// <param name="etat">Etat à ajouter</param>
        public void ajouterEtat(EtatBatiment etat)
        {
            if (Count >= 3)
            {
                throw new Exception("Un batiment ne peut pas avoir plus de 3 états");
            }
            Etats.Add(etat);
            Count = Etats.Count;
        }

        public void ajouterEtat()
        {
            if (Count >= 3)
            {
                throw new Exception("Un batiment ne peut pas avoir plus de 3 états");
            }
            Etats.Add(new EtatBatiment());
            Count = Etats.Count;
        }


        /// <summary>
        /// Si le nombre d'état est supérieur au nombre d'état minimum (1), alors on supprime le dernier état de la liste Etats.
        /// </summary>
        public void supprimerEtat()
        {
            if (Count == 0)
            {
                throw new Exception("Le batiment n'a aucun état à supprimer.");
            }
            Etats.RemoveAt(Count-1);
            Count = Etats.Count;

        }

        /// <summary>
        /// retourne l'EtatBatiment à l'indice donnée
        /// </summary>
        /// <param name="index">indice</param>
        /// <returns></returns>
        public EtatBatiment this[int index]{
            get{
                if(index < 1 && index > Count){
                    throw new IndexOutOfRangeException();
                }
                return Etats[index-1];
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\t\t<Batiment> {0}\n", Nom);

            int i = 1;
            foreach(EtatBatiment etat in Etats)
            {
                sb.AppendFormat("\t\t\tEtat {0}\n", i);
                sb.AppendFormat("{0}\n", etat);
                i++;
            }
            return sb.ToString();
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

            return this.Equals(right as Batiment);
        }

        /// <summary>
        /// checks if this Batiment is equal to the other Batiment
        /// </summary>
        /// <param name="other">the other Batiment to be compared with</param>
        /// <returns>true if equals</returns>
        public bool Equals(Batiment other)
        {
            return (this.Nom == other.Nom);
        }
 
    }

}
