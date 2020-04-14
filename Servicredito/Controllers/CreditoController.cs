namespace Servicredito.Controllers
{
    public class CreditoController
    {
        
        private readonly CreditosServices _creditoServices;
        public IConfiguration Configuration { get; }
        public PersonaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _creditoServices = new CreditosServices(connectionString);
        }
        // GET: api/credito
        [HttpGet]
        public IEnumerable<creditoViewModel> Gets()
        {
            var creditos = _creditoServices.ConsultarTodos().Select(p=> new creditoViewModel(p));
            return creditos;
        }

        // GET: api/credito/5
        [HttpGet("{identificacion}")]
        public ActionResult<creditoViewModel> Get(string identificacion)
        {
            var credito = _creditoServices.BuscarxIdentificacion(identificacion);
            if (credito == null) return NotFound();
            var creditoViewModel = new creditoViewModel(credito);
            return creditoViewModel;
        }
    }
}
