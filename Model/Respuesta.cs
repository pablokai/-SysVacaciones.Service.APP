using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysVacacionesMODEL
{
    public class Respuesta<T>
    {
        public List<T> Lsita {  get; set; }
        public Respuesta()
        {
            this.Lsita = new List<T>();
        }
    }
}
