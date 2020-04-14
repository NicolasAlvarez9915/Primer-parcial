namespace Entity
{
    public class Credito
    {
         public string IdenificacionCliente {get;set;}
        public int TasaInteres {get; set;}
        public int Tiempo { get; set; }

        public double Total { get; set; }

        public void CalcularTotal(){
            Total = 100;
        }
    }
}