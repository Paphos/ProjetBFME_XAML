using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    [DataContract]
    public class EtatBatiment : IEquatable<EtatBatiment>
    {
        [DataMember]
        public int Pdv { get; set; }
        [DataMember]
        public int Cout { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int TpsDeConstruct { get; set; }
        [DataMember]
        public string Raccourci { get; set; }
        [DataMember]
        public string Utilite { get; set; }
        [DataMember]
        public string UnitesRecrutables { get; set; }
        [DataMember]
        public string Ameliorations { get; set; }
        [DataMember]
        public bool TourDeDefense { get; set; }
        [DataMember]
        public int Capacite { get; set; }
        [DataMember]
        public string BonusOctroyes { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\t\t\t\tPdv : {0}\n\t\t\t\tCout : {1}\n\t\t\t\tTpsDeConstruct : {2} sec.\n\t\t\t\tTour de défense : {3}\n\t\t\t\tCapacite : {4}\n",Pdv,Cout,TpsDeConstruct,TourDeDefense,Capacite);
            if (Description != null) { sb.AppendFormat("\t\t\t\tDescription : {0}\n", Description); }
            if (Raccourci != null) { sb.AppendFormat("\t\t\t\tRaccourci : {0}\n", Raccourci); }
            if (Utilite != null) { sb.AppendFormat("\t\t\t\tUtilite : {0}\n", Utilite); }
            if (UnitesRecrutables != null) { sb.AppendFormat("\t\t\t\tUnitesRecrutables : {0}\n", UnitesRecrutables); }
            if (Ameliorations != null) { sb.AppendFormat("\t\t\t\tAmeliorations : {0}\n", Ameliorations); }
            if (BonusOctroyes != null) { sb.AppendFormat("\t\t\t\tBonusOctroyes : {0}\n", BonusOctroyes); }
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

            return this.Equals(right as EtatBatiment);
        }

        public bool Equals(EtatBatiment other)
        {
            return (this.Pdv == other.Pdv);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
    }
}
