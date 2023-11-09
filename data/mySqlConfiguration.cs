namespace PempleadosService.data
{
    public class mySqlConfiguration
    {
        public mySqlConfiguration(string conectionString)
        {
            ConectionString = conectionString;
        }
        public string ConectionString { get; set; }

    }
}
