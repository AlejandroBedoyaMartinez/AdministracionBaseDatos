using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cuerpo
{
    public class clsAreas
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String ubicacion { get; set; }

        public clsAreas()
        {
            id = 0;
            nombre = "";
            ubicacion = "";
        }

        public clsAreas(int id, string nombre, string ubicacion)
        {
            this.id = id;
            this.nombre = nombre;
            this.ubicacion = ubicacion;
        }

    }
}
