namespace Servicredito.models
{
    public class CreditoModel
    {
        public class CreditoInputModel
    {
        public string IdentificacionCliente { get; set; }
        public double Total { get; set; }
    }

    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {

        }
        public PersonaViewModel(Credito credito)
        {
            IdentificacionCliente = credito.IdentificacionCliente;
            Total = credito.Total;
        }
    }

    }
}