using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TGV.Model
{
    [Table("TGV_VIAGEM")]
    public partial class Viagem
    {
    
        [Key]
        [DisplayName("Código")]
        [Column("CODIGO")]
        public int Codigo { get; set; }

        [DisplayName("Data e Hora da Viagem")]
        [Column("DATAHORA")]
        public DateTime DataHora { get; set; }

        [DisplayName("Local da Entrega")]
        [Column("LOCAL_ENTREGA")]
        public string LocalEntrega { get; set; }

        [DisplayName("Local da Saída")]
        [Column("LOCAL_SAIDA")]
        public string LocalSaida { get; set; }

        [DisplayName("KM Percurso")]
        [Column("KM_PERCURSO")]
        public float KmPercurso { get; set; }


        [DisplayName("Motorista")]
        [Column("MOTORISTA_CODIGO")]
        public int MOTORISTA_CODIGO { get; set; }

        [DisplayName("Motorista")]
        public virtual Motorista Motoristas { get; set; }


    }
}
