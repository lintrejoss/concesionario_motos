using Dominio.Nucleo;
namespace ut_presentacion.Nucleo
{
    public class Configuracion
    {
        private static Dictionary<string, string>? Marcas= null;
        public static string ObtenerValor(string clave)
        {
            string respuesta = "";
            if (Marcas== null)
                Cargar();
            respuesta = Marcas![clave].ToString();
            return respuesta;
        }
        public static void Cargar()
        {
            if (!File.Exists(DatosGenerales.ruta_json))
                return;
            Marcas= new Dictionary<string, string>();
            StreamReader jsonStream = File.OpenText(DatosGenerales.ruta_json);
            var json = jsonStream.ReadToEnd();
            Marcas= JsonConversor.ConvertirAObjeto<Dictionary<string,
           string>>(json)!;
        }
    }
}
