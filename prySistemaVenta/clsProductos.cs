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
    class clsProductos : clsConexion
    {
        public string nombre;
        public float precio;
        public int categoria;
        public int numExistencia;
        public int marca;
        public string descripcion;
        public int id;


        public override void Agregar()
        {
           
            try
            {

                operaciones = new MySqlCommand("sp_AgregarProducto", conectar);
                operaciones.CommandType = CommandType.StoredProcedure;
                operaciones.Parameters.AddWithValue("$nombre", this.nombre);
                operaciones.Parameters.AddWithValue("$precio", this.precio);
                operaciones.Parameters.AddWithValue("$categoria", this.categoria);
                operaciones.Parameters.AddWithValue("$numExistencia", this.numExistencia);
                operaciones.Parameters.AddWithValue("$Marca_Id", this.marca);
                operaciones.Parameters.AddWithValue("$descripcion", this.descripcion);


                operaciones.ExecuteNonQuery();


            }
            catch (Exception e)
            {

                MessageBox.Show("Error al guardar :( " + e.Message);
            }
                


        }
        public override void Eliminar()
        {
            if (id != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Desea Eliminar este producto (ツ)", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {

                        operaciones = new MySqlCommand("sp_EliminarProducto", conectar);
                        operaciones.CommandType = CommandType.StoredProcedure;
                        operaciones.Parameters.AddWithValue("$id", id);
                        operaciones.ExecuteNonQuery();
                        

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Datos no validos  ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleciones un registro  ", "Mesage", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }



        }

        public override void Actualizar()
        {
            try
            {

                operaciones = new MySqlCommand("sp_ActualizarrProducto", conectar);
                operaciones.CommandType = CommandType.StoredProcedure;
                operaciones.Parameters.AddWithValue("$id", id);
                operaciones.Parameters.AddWithValue("$nombre", this.nombre);
                operaciones.Parameters.AddWithValue("$precio", this.precio);
                operaciones.Parameters.AddWithValue("$categoria", this.categoria);
                operaciones.Parameters.AddWithValue("$numExistencia", this.numExistencia);
                operaciones.Parameters.AddWithValue("$Marca_Id", this.marca);
                operaciones.Parameters.AddWithValue("$descripcion", this.descripcion);


                operaciones.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                MessageBox.Show("Error al Actualizar  :( " + e.Message);
            }

        }


        public override void Consultar()
        {

            Tabla = new DataTable();
            operaciones = new MySqlCommand("sp_showData", conectar);
            operaciones.CommandType = CommandType.StoredProcedure;
            Consultas = new MySqlDataAdapter(operaciones);
            Consultas.Fill(Tabla);
        }


        public override void Buscar()
        {
            try
            {
                Tabla = new DataTable();
                operaciones = new MySqlCommand("sp_buscarProductos", conectar);
                operaciones.CommandType = CommandType.StoredProcedure;
                operaciones.Parameters.AddWithValue("buscar_nom", this.nombre);
                Consultas = new MySqlDataAdapter(operaciones);
                Consultas.Fill(Tabla);


            }
            catch (Exception e)
            {

                MessageBox.Show("Error al BUSCAR :( " + e.Message);
            }


        }
        



    }
}