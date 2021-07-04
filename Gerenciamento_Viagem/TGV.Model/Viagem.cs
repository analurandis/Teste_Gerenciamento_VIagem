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

        [Required(ErrorMessage = "A data da viagem é obigatório")] 
        [DisplayName("Data e Hora da Viagem")]
        [Column("DATAHORA")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O local de entrega  é obigatório")]
        [DisplayName("Local da Entrega")]
        [Column("LOCAL_ENTREGA")]
        public string LocalEntrega { get; set; }

        [Required(ErrorMessage = "O local de saída  é obigatório")]
        [DisplayName("Local da Saída")]
        [Column("LOCAL_SAIDA")]
        public string LocalSaida { get; set; }

        [Required(ErrorMessage = "A quilometragem do percurso é obrigatório ")]
        [DisplayName("KM Percurso")]
        [Column("KM_PERCURSO")]
        public float KmPercurso { get; set; }

        [Required(ErrorMessage = "O motorista é obrigatório ")]
        [DisplayName("Motorista")]
        [Column("MOTORISTA_CODIGO")]
        public int MOTORISTA_CODIGO { get; set; }

        [DisplayName("Motorista")]
        public virtual Motorista Motoristas { get; set; }

        [Required(ErrorMessage = "O caminhão é obrigatório ")]
        [DisplayName("Caminhão")]
        [Column("CAMINHAO_CODIGO")]
        public int CAMINHAO_CODIGO { get; set; }

        [DisplayName("Caminhão")]
        public virtual Caminhao Caminhao { get; set; }


    }
}
