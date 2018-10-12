using System;
using System.Collections.Generic;
using System.Text;

namespace CemAppCross.Clases
{
    public class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Notas = new HashSet<Notas>();
        }

        public int idUsuario { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string pnombre { get; set; }
        public string snombre { get; set; }
        public string appat { get; set; }
        public string apmat { get; set; }
        public string email { get; set; }
        public string fonoCelular { get; set; }
        public string fonoFijo { get; set; }
        public Nullable<int> tipoUsuario { get; set; }
        public Nullable<int> alumnoRegular { get; set; }
        public int idCarrera { get; set; }
        public int idInstitucion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Notas> Notas { get; set; }
    }
}
