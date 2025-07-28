using System;
using System.Runtime.InteropServices;

namespace ConexionSql.Utilidades
{
    public static class ImpresionZebra
    {
        // Estructura que describe el documento a imprimir (requerida por la API de Windows)
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;       // Nombre del documento (informativo)
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;    // Archivo de salida (null si se imprime directamente)
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;      // Tipo de datos (RAW para enviar ZPL crudo)
        }

        // Declaración de funciones nativas de Windows para la impresión

        [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] DOCINFOA pDocInfo);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        // Método principal que envía un string ZPL a una impresora Zebra configurada en el sistema
        public static bool EnviarAImpresora(string nombreImpresora, string contenidoZPL)
        {
            IntPtr pPrinter = IntPtr.Zero;  // Puntero al handle de la impresora
            IntPtr pBytes = IntPtr.Zero;    // Puntero a los datos a enviar
            try
            {
                // Abre la impresora especificada
                if (!OpenPrinter(nombreImpresora.Normalize(), out pPrinter, IntPtr.Zero))
                {
                    int error = Marshal.GetLastWin32Error();
                    Console.WriteLine($"OpenPrinter falló. Error de Windows: {error}");
                    return false;
                }

                // Define la información del documento a imprimir
                DOCINFOA docInfo = new DOCINFOA
                {
                    pDocName = "Etiqueta ZPL",
                    pDataType = "RAW",
                    pOutputFile = null
                };

                // Inicia el documento de impresión
                if (!StartDocPrinter(pPrinter, 1, docInfo))
                {
                    int error = Marshal.GetLastWin32Error();
                    Console.WriteLine($"StartDocPrinter falló. Error de Windows: {error}");
                    return false;
                }

                // Inicia la página de impresión
                if (!StartPagePrinter(pPrinter))
                {
                    int error = Marshal.GetLastWin32Error();
                    Console.WriteLine($"StartPagePrinter falló. Error de Windows: {error}");
                    return false;
                }

                // Convierte el contenido ZPL a un bloque de memoria ANSI
                pBytes = Marshal.StringToCoTaskMemAnsi(contenidoZPL);
                int dwWritten;

                // Envía los datos crudos (ZPL) a la impresora
                bool success = WritePrinter(pPrinter, pBytes, contenidoZPL.Length, out dwWritten);
                if (!success)
                {
                    int error = Marshal.GetLastWin32Error();
                    Console.WriteLine($"WritePrinter falló. Error de Windows: {error}");
                }

                // Finaliza la página y el documento
                EndPagePrinter(pPrinter);
                EndDocPrinter(pPrinter);

                return success;
            }
            finally
            {
                // Libera la memoria y cierra la impresora aunque haya ocurrido algún error
                if (pBytes != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pBytes);

                if (pPrinter != IntPtr.Zero)
                    ClosePrinter(pPrinter);
            }
        }
    }
}
