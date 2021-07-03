using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TGV.Model
{
    [Table("TGV_MOTORISTA")]
    public partial class Motorista
    {

        public Motorista()
        {
            this.Caminhoes = new HashSet<Caminhao>();
            this.Viagens = new HashSet<Viagem>();
        }

        [Required]
        [Key]
        [DisplayName("Código")]
        [Column("CODIGO")]
        public int Codigo { get; set; }

        [DisplayName("Nome completo")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Rua")]
        [Column("RUA")]
        public string Rua { get; set; } 

        [DisplayName("Nº")]
        [Column("NUMERO")]
        public string Numero { get; set; } 

        [DisplayName("Bairro")]
        [Column("BAIRRO")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        [Column("CIDADE")]
        public string Cidade { get; set; }

        [DisplayName("UF")]
        [Column("ESTADO")]
        public string Estado { get; set; }

        [DisplayName("CEP")]
        [Column("CEP")]
        public string Cep { get; set; }
      
       
        [ForeignKey("MOTORISTA_CODIGO")]
        public virtual ICollection<Caminhao> Caminhoes { get; set; }


        [ForeignKey("MOTORISTA_CODIGO")]
        public virtual ICollection<Viagem> Viagens { get; set; }
     
        


    }
}
