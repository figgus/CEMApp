using System;
using System.Collections.Generic;
using System.Text;

namespace CemAppCross.Clases
{
    public class Notas
    {
        public int idNota { get; set; }
        public double calificacion { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> numeral { get; set; }
        public Nullable<int> idUsuarioFK { get; set; }
        public Nullable<int> idProgramaEstudiosFK { get; set; }

        public Usuario Usuario { get; set; }
    }
}
