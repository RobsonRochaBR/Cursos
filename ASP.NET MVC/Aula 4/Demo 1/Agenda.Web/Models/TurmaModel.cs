﻿using System;
using System.ComponentModel.DataAnnotations;
using Agenda.Dados;

namespace Agenda.Web.Models
{
    public class TurmaModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Local { get; set; }

        [Required]
        public int ProfessorId { get; set; }

        [Required]
        public int CursoId { get; set; }
    }
}