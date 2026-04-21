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
        string sector,
        string material,
        DateTime fechaRecepcion,
        DateTime vencimiento,
        int nroRecepcion,
        int idDetalle,
        string codigoReuso,
        string tipoMaterial)
        {

            string lineaReuso = (!string.IsNullOrWhiteSpace(codigoReuso) && codigoReuso != "1")
            ? $"^FO20,145^FDCod reuso {codigoReuso}^FS\n"
            : "";

            return
                "^XA\n" +                     // 🔹 INICIO ETIQUETA

                "^CI28\n" +                  // 🔹 Codificación UTF-8 (acentos)

                "^PW480\n" +                // 🔹 ANCHO etiqueta (6 cm aprox)
                "^LL360\n" +                // 🔹 ALTO etiqueta (4.5 cm aprox)

                "^LH20,0\n" +                // 🔹 ORIGEN (0,0)- esta linea mueve todo

                //"^FO10,10^GB460,340,2^FS\n" +
                // 🔹 BORDE GENERAL
                // 10,10 = posición
                // 460 ancho / 340 alto
                // 2 = grosor línea

                // =============================
                // 🟦 RECEPCIÓN + NÚMERO + FECHA
                // =============================
                "^CF0,22\n" +              // 🔹 Tamaño de letra

                "^FO20,30^FDRecepcion^FS\n" +
                // 🔹 Texto fijo "Recepcion"

                $"^FO150,30^FD{nroRecepcion}^FS\n" +
                // 🔹 Número de recepción

                $"^FO320,30^FD{fechaRecepcion:dd/MM/yyyy}^FS\n" +
                // 🔹 Fecha

                // =============================
                // 🟦 SECTOR
                // =============================
                "^CF0,22\n" +

                $"^FO20,60^FDSector {sector}^FS\n" +
                // 🔹 Sector (QUIROFANO, etc.)

                // =============================
                // 🟦 MATERIAL
                // =============================
                "^CF0,24\n" +              // 🔹 Un poco más grande

                $"^FO20,90^FD{material}^FS\n" +
                // 🔹 Nombre del material

                // 👉 SI se corta el texto → subir tamaño o mover Y

                // =============================
                // 🟦 TEXTO REUSABLE
                // =============================
                "^CF0,24\n" +

                $"^FO20,120^FD{tipoMaterial}^FS\n" +
                // 🔹 Texto fijo
                lineaReuso +

                // =============================
                // 🟦 FRANJA NEGRA (VENCIMIENTO)
                // =============================
                "^FO20,190^GB440,28,28^FS\n" +
                // 🔹 Rectángulo negro
                // 440 ancho
                // 28 alto
                // 28 grosor → relleno

                "^CF0,22\n" +

                "^FO25,193^FR^FDVencimiento^FS\n" +
                // 🔹 Texto blanco (FR invierte)

                $"^FO300,193^FR^FD{vencimiento:dd/MM/yyyy}^FS\n" +
                // 🔹 Fecha vencimiento

                // =============================
                // 🟦 ID (arriba del código de barras)
                // =============================
                "^CF0,20\n" +

                $"^FO190,300^FD{idDetalle}^FS\n" +
                // 🔹 Número visible

                // =============================
                // 🟦 CÓDIGO DE BARRAS
                // =============================
                "^BY3,2,55\n" +
                // 🔹 Config barcode
                //"^BY4,2,55\n" BY ancho, espacio, alto
                // 2 = grosor barra
                // 55 = altura

                "^FO60,320^BCN,45,N,N,N^FD" + idDetalle + "^FS\n" +
                // 🔹 Barcode
                // 95,240 = posición
                // 45 = altura

                "^XZ";                     // 🔹 FIN ETIQUETA
        }

        public static string RecepcionDetalleCompleto(
        string sector,
        string material,
        DateTime fechaRecepcion,
        int nroRecepcion,
        int idDetalle,
        int cantidad)
        {
            return
                "^XA\n" +

                "^CI28\n" +
                "^PW480\n" +
                "^LL360\n" +

                "^LH20,0\n" +

                // =============================
                // 🟦 CABECERA
                // =============================
                "^CF0,22\n" +

                "^FO20,30^FDRecepcion^FS\n" +
                $"^FO150,30^FD{nroRecepcion}^FS\n" +
                $"^FO320,30^FD{fechaRecepcion:dd/MM/yyyy}^FS\n" +

                // =============================
                // 🟦 SECTOR
                // =============================
                "^CF0,22\n" +
                $"^FO20,60^FDSector {sector}^FS\n" +

                // =============================
                // 🟦 MATERIAL
                // =============================
                "^CF0,24\n" +
                $"^FO20,90^FD{material}^FS\n" +

                // =============================
                // 🟦 UNIDADES
                // =============================
                "^CF0,22\n" +
                $"^FO20,120^FDUnidades contenidas: {cantidad} Unid^FS\n" +

                // =============================
                // 🟦 RECUADRO COMPLETO (CORREGIDO)
                // =============================
                "^FO20,150^GB440,40,40^FS\n" +   // 🔹 fondo negro (relleno)
                "^CF0,26\n" +
                "^FO30,158^FR^FDPRIORIDAD DE PROCESO^FS\n" +  // 🔹 texto blanco

                // =============================
                // 🟦 ID
                // =============================
                "^CF0,20\n" +
                $"^FO190,300^FD{idDetalle}^FS\n" +

                // =============================
                // 🟦 BARCODE
                // =============================
                "^BY3,2,55\n" +
                $"^FO60,320^BCN,45,N,N,N^FD{idDetalle}^FS\n" +

                "^XZ";
        }

        public static string RecepcionDetalleIncompleto(
        string sector,
        string material,
        DateTime fechaRecepcion,
        int nroRecepcion,
        int idDetalle,
        int cantidad,
        string detalleFaltante)
        {
            return
                "^XA\n" +

                "^CI28\n" +
                "^PW480\n" +
                "^LL360\n" +

                "^LH20,0\n" +

                // =============================
                // 🟦 CABECERA
                // =============================
                "^CF0,22\n" +

                "^FO20,30^FDRecepcion^FS\n" +
                $"^FO150,30^FD{nroRecepcion}^FS\n" +
                $"^FO320,30^FD{fechaRecepcion:dd/MM/yyyy}^FS\n" +

                // =============================
                // 🟦 SECTOR
                // =============================
                "^CF0,22\n" +
                $"^FO20,60^FDSector {sector}^FS\n" +

                // =============================
                // 🟦 MATERIAL
                // =============================
                "^CF0,24\n" +
                $"^FO20,90^FD{material}^FS\n" +

                // =============================
                // 🟦 COD ETIQUETA
                // =============================
                "^CF0,22\n" +
                $"^FO20,120^FDCod etiquet {idDetalle}^FS\n" +

                // =============================
                // 🟦 CONTENIDO
                // =============================
                $"^FO20,140^FDContenido {cantidad} Unid^FS\n" +

                // =============================
                // 🟦 FRANJA NEGRA (TÍTULO)
                // =============================
                "^FO20,170^GB460,28,28^FS\n" +
                "^CF0,24\n" +
                "^FO25,173^FR^FDElementos faltantes:^FS\n" +

                // =============================
                // 🟦 DETALLE FALTANTE (MEM_1)
                // =============================
                "^CF0,20\n" +
                $"^FO20,205^FD{detalleFaltante}^FS\n" +

                // =============================
                // 🟦 ID
                // =============================
                "^CF0,20\n" +
                $"^FO190,300^FD{idDetalle}^FS\n" +

                // =============================
                // 🟦 BARCODE
                // =============================
                "^BY3,2,55\n" +
                $"^FO60,320^BCN,45,N,N,N^FD{idDetalle}^FS\n" +

                "^XZ";
        }


        public static string RecepcionDetallePrioridadProceso(
        string sector,
        string material,
        DateTime fechaRecepcion,
        int nroRecepcion,
        int idDetalle)
        {
            return
                "^XA\n" +

                "^CI28\n" +
                "^PW480\n" +
                "^LL360\n" +

                "^LH20,0\n" +

                // =============================
                // 🟦 CABECERA
                // =============================
                "^CF0,22\n" +

                "^FO20,30^FDRecepcion^FS\n" +
                $"^FO150,30^FD{nroRecepcion}^FS\n" +
                $"^FO320,30^FD{fechaRecepcion:dd/MM/yyyy}^FS\n" +

                // =============================
                // 🟦 SECTOR
                // =============================
                "^CF0,22\n" +
                $"^FO20,60^FDSector {sector}^FS\n" +

                // =============================
                // 🟦 MATERIAL
                // =============================
                "^CF0,24\n" +
                $"^FO20,90^FD{material}^FS\n" +

                // =============================
                // 🟦 FRANJA NEGRA PRIORIDAD
                // =============================
                "^FO20,150^GB410,80,80^FS\n" +     // 🔴 relleno completo (alto=grosor)
                "^CF0,40\n" +                      // 🔴 texto más grande
                "^FO20,180^FB410,1,0,C^FR^FDPRIORIDAD DE PROCESO^FS\n"+

                // =============================
                // 🟦 ID
                // =============================
                "^CF0,20\n" +
                $"^FO190,300^FD{idDetalle}^FS\n" +

                // =============================
                // 🟦 BARCODE
                // =============================
                "^BY3,2,55\n" +
                $"^FO60,320^BCN,45,N,N,N^FD{idDetalle}^FS\n" +

                "^XZ";
        }

        public static string RecepcionDetalleReprocesadoSinUso(
        string sector,
        string material,
        DateTime fechaRecepcion,
        int nroRecepcion,
        int idDetalle)
        {
            return
                "^XA\n" +

                "^CI28\n" +
                "^PW480\n" +
                "^LL360\n" +

                "^LH20,0\n" +

                // =============================
                // 🟦 CABECERA
                // =============================
                "^CF0,22\n" +

                "^FO20,30^FDRecepcion^FS\n" +
                $"^FO150,30^FD{nroRecepcion}^FS\n" +
                $"^FO320,30^FD{fechaRecepcion:dd/MM/yyyy}^FS\n" +

                // =============================
                // 🟦 SECTOR
                // =============================
                "^CF0,22\n" +
                $"^FO20,60^FDSector {sector}^FS\n" +

                // =============================
                // 🟦 MATERIAL
                // =============================
                "^CF0,24\n" +
                $"^FO20,90^FD{material}^FS\n" +

                // =============================
                // 🟦 FRANJA NEGRA (DOBLE TEXTO)
                // =============================
                "^FO20,150^GB410,80,80^FS\n" +   // 🔴 fondo negro grande

                "^CF0,35\n" +
                "^FO20,160^FB410,1,0,C^FR^FDMATERIAL^FS\n" +  // 🔴 línea 1

                "^CF0,35\n" +
                "^FO25,195^FB410,1,0,C^FR^FDREPROCESADO SIN USO^FS\n" +  // 🔴 línea 2

                // =============================
                // 🟦 ID
                // =============================
                "^CF0,20\n" +
                $"^FO190,300^FD{idDetalle}^FS\n" +

                // =============================
                // 🟦 BARCODE
                // =============================
                "^BY3,2,55\n" +
                $"^FO60,320^BCN,45,N,N,N^FD{idDetalle}^FS\n" +

                "^XZ";
        }
    }


}
