using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace prySistemaVenta
{
    class clsConexion
    {

        public MySqlConnection conectar;
        public MySqlCommand operaciones;
        public MySqlDataAdapter Consultas;
        public DataTable Tabla;




        public void AbrirConexion()
        {

            try
            {
                string CadenaConexion = @"server=localhost;userid=root;password=;database=db_abarrotes";
                conectar = new MySqlConnection(CadenaConexion);
                conectar.Open();

            }catch(Exception e)
            {
                MessageBox.Show("No se pudo conectar" + e.Message);
             }
        }


        public virtual void Agregar() { }
        public virtual void Actualizar() { }
        public virtual void Eliminar() { }
        public virtual void Consultar() {}
        public virtual void Buscar() { }

    }
}
