namespace Logica
{
    public class CreditoService
    {
        private readonly ConnectionManager _conexion;
        private readonly CreditoRepository _repositorio;
        public CreditosServices(string connectionString){
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new CreditoRepository(_conexion);
        }

        public List<Credito> ConsultarTodos()
        {
            _conexion.Open();
            List<Credito> credito = _repositorio.ConsultarTodos();
            _conexion.Close();
            return credito;
        }

        public GuardarCreditoResponse Guardar(Credito credito)
        {
            try
            {
                credito.CalcularTotal();
                _conexion.Open();
                _repositorio.Guardar(credito);
                _conexion.Close();
                return new GuardarCreditoResponse(credito);
            }
            catch (Exception e)
            {
                return new GuardarCreditoResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

    }
}
