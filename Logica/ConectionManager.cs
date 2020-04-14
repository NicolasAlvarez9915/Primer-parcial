namespace Logica
{
    public class ConectionManager
    {
        
        public GuardarCreditosResponse(Credito credito)
        {
            Error = false;
            Credito = credito;
        }
        public GuardarCreditosResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Creditos Credito { get; set; }
    }
}