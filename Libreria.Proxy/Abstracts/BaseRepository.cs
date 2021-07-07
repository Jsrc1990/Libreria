namespace Libreria.Proxy
{
    /// <summary>
    /// Define la clase repositorio base
    /// </summary>
    public class BaseRepository
    {
        /// <summary>
        /// Define el conector
        /// </summary>
        protected readonly WebClientConnector webClientConnector;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        public BaseRepository()
        {
            webClientConnector = new WebClientConnector();
        }
    }
}