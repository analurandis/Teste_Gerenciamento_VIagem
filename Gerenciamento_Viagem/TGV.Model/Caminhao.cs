using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TGV.Model
{
    [Table("TGV_CAMINHAO")]
    public partial class Caminhao
    {
        public Caminhao()
        {
            this.Viagens = new HashSet<Viagem>();
        }
        
        [Key]
        [DisplayName("Código")]
        [Column("CODIGO")]
        public int Codigo { get; set; }

        [DisplayName("Marca")]
        [Column("MARCA")]
        public string Marca { get; set; }

        [DisplayName("Modelo")]
        [Column("MODELO")]
        public string Modelo { get; set; }

        [DisplayName("Placa")]
        [Column("PLACA")]
        public string Placa { get; set; }

        [DisplayName("Eixo")]
        [Column("EIXO")]
        public int Eixo { get; set; }

        [DisplayName("Peso")]
        [Column("PESO")]
        public float Peso { get; set; }

        [DisplayName("Motorista")]
        [Column("MOTORISTA_CODIGO")]
        public int MOTORISTA_CODIGO { get; set; }

        [DisplayName("Motorista")]
        public virtual Motorista Motorista { get; set; }


        [ForeignKey("CAMINHAO_CODIGO")]
        public virtual ICollection<Viagem> Viagens { get; set; }

    }
}
