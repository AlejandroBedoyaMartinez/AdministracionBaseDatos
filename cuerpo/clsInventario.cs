using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cuerpo
{
    public class clsInventario
    {
        public int id { get; set; }

        public int Areas_ID { get; set; }

        public String nombreCorto { get; set; }

        public String descirpcion { get; set; }

        public String serie { get; set; }

        public String color { get; set; }

        public String fechaAdquisicion { get; set; }

        public String tipoAdquision { get; set; }

        public String observaciones { get; set; }

        public clsInventario()
        {
            id = 0;
            nombreCorto = "";
            descirpcion = "";
            serie = "";
            color = "";
            fechaAdquisicion = "";
            tipoAdquision = "";
            observaciones = "";
            Areas_ID = 0;
        }

        public clsInventario(int id, string nombreCorto, string descirpcion, string serie, string color, string fechaAdquisicion, string tipoAdquision, string observaciones, int areas_ID)
        {
            this.id = id;
            this.nombreCorto = nombreCorto;
            this.descirpcion = descirpcion;
            this.serie = serie;
            this.color = color;
            this.fechaAdquisicion = fechaAdquisicion;
            this.tipoAdquision = tipoAdquision;
            this.observaciones = observaciones;
            Areas_ID = areas_ID;
        }
           
    }
}
