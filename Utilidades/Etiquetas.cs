using ConexionSql.Models.IbPer;

namespace ConexionSql.Utilidades
{
    public static class Etiquetas
    {
        public static string Personal(IbPer persona)
        {
            return
                "^XA\n" +
                "^PW480\n" +
                "^LL360\n" +
                "^CF0,50\n" +
                "^FO0,30^FB480,1,0,C^FDBAXEN^FS\n" +
                "^CF0,30\n" +
                $"^FO0,150^FB480,1,0,C^FD{persona.IbPerNom} {persona.IbPerApe}^FS\n" +
                "^XZ";
        }

        public static string RecepcionDetalle(
            string material,
            int cantidad,
            DateTime fecha,
            TimeSpan hora,
            int nroRecepcion,
            int idDetalle)
        {
            return
                "^XA\n" +
                "^CI28\n" +
                "^PW480\n" +
                "^LL360\n" +

                "^CF0,30\n" + // Fuente más chica para permitir más texto
                "^FO30,20^FB420,2,0,C^FD" + material + "^FS\n" + // Forzar 2 líneas centradas

                "^CF0,26\n" +
                $"^FO30,100^FD CANTIDAD: {cantidad}^FS\n" +
                $"^FO30,130^FD FECHA: {fecha:dd/MM/yyyy}^FS\n" +
                $"^FO30,160^FD HORA: {hora:hh\\:mm}^FS\n" +
                $"^FO30,190^FD RECEPCION N°{nroRecepcion}^FS\n" +

                "^BY2,2,60\n" +
                "^FO100,230^BCN,60,Y,N,N\n" +
                $"^FD{idDetalle}^FS\n" +

                "^CF0,24\n" +
                $"^FO30,300^FD ID: {idDetalle}^FS\n" +

                "^XZ";
        }
    }
}
