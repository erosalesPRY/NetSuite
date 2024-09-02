using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class CTestOracle
    {
        public void Prueba()
        {
            (new TestOracle()).Prueba();
        }
        public DataTable Prueba2()
        {
            return (new TestOracle()).Prueba2();
        }
        public DataTable Listar(string Criterio)
        {
            return (new TestOracle()).Listar(Criterio);
        }

    }
}
