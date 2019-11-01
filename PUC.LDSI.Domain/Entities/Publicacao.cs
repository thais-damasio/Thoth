﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
   public class Publicacao : Entity
    {
       
        public Publicacao() : base()
        {

        }
        //Atributos
        [Display(Name = "Data Inicio")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Data Fim")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public DateTime DataFim { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Valor { get; set; }
        [ForeignKey("Avaliacao")]
        public int IdAvaliacao { get; set; }

        //Relacionamentos
        public Avaliacao Avaliacao { get; set; }
        public Turma Turma { get; set; }

    }
}
