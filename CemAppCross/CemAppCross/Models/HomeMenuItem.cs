using System;
using System.Collections.Generic;
using System.Text;

namespace CemAppCross.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Porgramas,
        Notas,
        Postulaciones,
        SeleccionarFamilia
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
