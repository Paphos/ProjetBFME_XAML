using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    [DataContract]
    public class TypeBatiment : IEquatable<TypeBatiment>
    {
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Description { get; set; }


        public TypeBatiment(string nom) : this(nom,null){}

        public TypeBatiment(string nom, string description)
        {
            Nom = nom;
            Description = description;
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode() * 31;
        }

        public override string ToString()
        {
            return string.Format("\t<TypeBatiment> {0} {1}", Nom, Description);
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

            return this.Equals(right as TypeBatiment);
        }

        public bool Equals(TypeBatiment other)
        {
            return (this.Nom.ToLower() == other.Nom.ToLower());
        }
    }
}
    