using System;
using System.ComponentModel.DataAnnotations;

namespace ConexionSql.Models.Recepciones
{
    public class TbRecFormDto
    {
        public DateTime TbRecFec { get; set; }

        [Display(Name = "Hora Inicio")]
        public DateTime TbRecHorIni { get; set; }

        [Display(Name = "Hora Fin")]
        public DateTime TbRecHorFin { get; set; }

        public int TbRecPerId { get; set; }
        public string TbRecPerNom { get; set; }
        public int TbRecPerCarId { get; set; }
        public string TbRecPerCarDen { get; set; }

        public int TbRecSecOriId { get; set; }
        public string TbRecSecOriDen { get; set; }

        public int TbRecSecDesId { get; set; }
        public string TbRecSecDesDen { get; set; }
    }
}
