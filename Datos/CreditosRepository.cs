namespace Datos
{
    public class CreditosRepository
    {
        private readonly SqlConection _connection;
        private readonly List<Credito> _Creditos = new List<Credito>();

        public CreditosRepository(ConnectionManager connection){
            _connection = connection._conexion;
        }

        public void Guardar(Credito credito){
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Persona (IdentificacionCliente,Total) 
                                        values (@Identificacion,@Total)";
                command.Parameters.AddWithValue("@Identificacion", creditos.IdentificacionCliente);
                command.Parameters.AddWithValue("@Total", creditos.Total);
                var filas = command.ExecuteNonQuery();
            }


        }

        public List<Creditos> ConsultarTodo(){
            SqlDataReader dataReader;
            List<Credito> creditos = new List<Credito>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Creditos ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Credito credito = DataReaderMapToCreditos(dataReader);
                        Creditos.Add(credito);
                    }
                }
            }
            return Creditos;

        }

        private credito DataReaderMapToCreditos(SqlDataReader dataReader)
{
            if(!dataReader.HasRows) return null;
            Creditos credito = new Creditos();
            credito.IdentificacionCliente = (string)dataReader["IdentificacionCliente"];
            credito.Total = (int)dataReader["Total"];
            return credito;
}


    }
}