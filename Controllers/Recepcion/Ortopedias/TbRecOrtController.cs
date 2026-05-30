using ConexionSql.Data;
using ConexionSql.Models.Recepciones.Ortopedias;
using Microsoft.AspNetCore.Mvc;

namespace ConexionSql.Controllers.Recepcion.Ortopedias
{
    public class TbRecOrtController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbRecOrtController(ConexionSqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AbrirModalOrtopedias(int tbRecId)
        {
            var cabecera = _context.TbRec
                    .FirstOrDefault(x => x.TbRecId == tbRecId);
            var dto = new TbRecOrtDto
            {
                Cabecera = cabecera,
                TB_REC_ID = tbRecId,
                TB_REC_ORT_FEC = DateTime.Today,
                TB_REC_ORT_HOR_INI = new DateTime(1899, 12, 30, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            };

            ViewBag.ListaOrtopedias = _context.IbOrt
                .OrderBy(x => x.IbOrtDen)
                .ToList();

            ViewBag.ListaProfesionales = _context.IbPro
                .OrderBy(x => x.IbProApe)
                .ThenBy(x => x.IbProNom)
                .ToList();

            return PartialView(
                "~/Views/Recepcion/Ortopedias/Modals/_ModalRegistroOrtopedia.cshtml",
                dto
            );
        }

        [HttpPost]
        public IActionResult InsertarOrtopedias(TbRecOrtDto dto)
        {
            var fechaHoraActual = DateTime.Now;

            var cabecera = _context.TbRec
                .FirstOrDefault(x => x.TbRecId == dto.TB_REC_ID);


            var datosOrtopedia = _context.IbOrt
                .FirstOrDefault(x => x.IbOrtId == dto.TB_REC_ORT_ORT_ID);

            var datosProfesional = _context.IbPro
                .FirstOrDefault(x => x.IbProId == dto.TB_REC_ORT_PRO_ID);

            var cantidadTotalRecibida =
                (dto.TB_REC_ORT_CANT_REC_CIN ?? 0) +
                (dto.TB_REC_ORT_CANT_REC_INS ?? 0) +
                (dto.TB_REC_ORT_CANT_REC_EST ?? 0) +
                (dto.TB_REC_ORT_CANT_REC_VS ?? 0);

            var nuevaOrtopedia = new TbRecOrt
            {
                TbRecId = dto.TB_REC_ID,

                TbRecOrtPerId = cabecera?.TbRecPerId,
                TbRecOrtPerNom = cabecera?.TbRecPerNom,
                TbRecOrtPerApe = cabecera?.TbRecPerApe,
                TbRecOrtPerCarId = cabecera?.TbRecPerCarId,
                TbRecOrtPerCarDen = cabecera?.TbRecPerCarDen,

                TbRecOrtFec = DateTime.Today,

                TbRecOrtHorIni =
                    new DateTime(
                        1899,
                        12,
                        30,
                        fechaHoraActual.Hour,
                        fechaHoraActual.Minute,
                        fechaHoraActual.Second),

                TbRecOrtHorFin =
                    new DateTime(
                        1899,
                        12,
                        30,
                        fechaHoraActual.Hour,
                        fechaHoraActual.Minute,
                        fechaHoraActual.Second),

                TbRecOrtRegPcLog = Environment.MachineName,
                TbRecOrtRegPcUsr = Environment.UserName,

                TbRecOrtOrtId = dto.TB_REC_ORT_ORT_ID,
                TbRecOrtOrtDen = datosOrtopedia?.IbOrtDen ?? "NO REGISTRA",
                TbRecOrtOrtPer = dto.TB_REC_ORT_ORT_PER,

                TbRecOrtRem = dto.TB_REC_ORT_REM,

                TbRecOrtProId = dto.TB_REC_ORT_PRO_ID,
                TbRecOrtProNom = datosProfesional?.IbProNom,
                TbRecOrtProApe = datosProfesional?.IbProApe,

                TbRecOrtPac = dto.TB_REC_ORT_PAC,
                TbRecOrtFecProc = dto.TB_REC_ORT_FEC_PROC,
                TbRecOrtHorProc = dto.TB_REC_ORT_HOR_PROC,

                TbRecOrtObsRec = dto.TB_REC_ORT_OBS_REC,

                TbRecOrtCantRecCin = dto.TB_REC_ORT_CANT_REC_CIN ?? 0,
                TbRecOrtCantRecIns = dto.TB_REC_ORT_CANT_REC_INS ?? 0,
                TbRecOrtCantRecEst = dto.TB_REC_ORT_CANT_REC_EST ?? 0,
                TbRecOrtCantRecVs = dto.TB_REC_ORT_CANT_REC_VS ?? 0,

                TbRecOrtCantRec = cantidadTotalRecibida,

                TbRecOrtCantRecCinCq = 0,
                TbRecOrtCantRecCinDev = 0,

                TbRecOrtCantRecInsCq = 0,
                TbRecOrtCantRecInsDev = 0,

                TbRecOrtCantRecEstCq = 0,
                TbRecOrtCantRecEstDev = 0,

                TbRecOrtCantRecVsCq = 0,
                TbRecOrtCantRecVsDev = 0,

                TbRecOrtCantCq = 0,
                TbRecOrtCantDev = 0,

                TbRecOrtNum1 = 1,
                TbRecOrtNum2 = 2,
                TbRecOrtNum3 = 3,

                TbRecOrtTxt1 = "TXT",
                TbRecOrtTxt2 = "TXT",
                TbRecOrtTxt3 = "TXT",

                TbRecOrtMem1 = "MEM",
                TbRecOrtMem2 = "MEM",
                TbRecOrtMem3 = "MEM",

                TbRecOrtPerIdDevEst = 0,
                TbRecOrtPerNomDevEst = "NO REGISTRADO",
                TbRecOrtPerApeDevEst = "NO REGISTRADO",

                TbRecOrtPerCarIdDevEst = 0,
                TbRecOrtPerCarDenDevEst = "NO REGISTRADO",

                TbRecOrtDevEstPcLog = "NO REGISTRADO",
                TbRecOrtDevEstPcUsr = "NO REGISTRADO",

                TbRecOrtOrtPerDevEst = "NO REGISTRADO",

                TbRecOrtDevEstEst = false,

                TbRecOrtCantRecCinDevEst = 0,
                TbRecOrtCantRecInsDevEst = 0,
                TbRecOrtCantRecEstDevEst = 0,
                TbRecOrtCantRecVsDevEst = 0,
                TbRecOrtCantDevEst = 0
            };

            _context.TbRecOrt.Add(nuevaOrtopedia);

            _context.SaveChanges();


            return Json(new
            {
                success = true,
                tbRecOrtId = nuevaOrtopedia.TbRecOrtId,

                ortopedia = new
                {
                    TB_REC_ORT_ORT_ID = nuevaOrtopedia.TbRecOrtOrtId,
                    TB_REC_ORT_ORT_DEN = nuevaOrtopedia.TbRecOrtOrtDen,

                    TB_REC_ORT_PRO_ID = nuevaOrtopedia.TbRecOrtProId,
                    TB_REC_ORT_PRO_NOM = nuevaOrtopedia.TbRecOrtProNom,
                    TB_REC_ORT_PRO_APE = nuevaOrtopedia.TbRecOrtProApe,

                    TB_REC_ORT_PAC = nuevaOrtopedia.TbRecOrtPac,
                    TB_REC_ORT_REM = nuevaOrtopedia.TbRecOrtRem,

                    TB_REC_ORT_FEC_PROC = nuevaOrtopedia.TbRecOrtFecProc,
                    TB_REC_ORT_HOR_PROC = nuevaOrtopedia.TbRecOrtHorProc
                }
            });
        }


        [HttpGet]
        public IActionResult BuscarOrtopedias(string texto)
        {
            var lista = _context.IbOrt
                .Where(x => x.IbOrtDen.Contains(texto))
                .OrderBy(x => x.IbOrtDen)
                .Select(x => new
                {
                    id = x.IbOrtId,
                    denominacion = x.IbOrtDen
                })
                .Take(20)
                .ToList();

            return Json(lista);
        }

        [HttpGet]
        public IActionResult BuscarProfesionales(string texto)
        {
            var lista = _context.IbPro
                .Where(x =>
                    x.IbProApe.Contains(texto)
                    || x.IbProNom.Contains(texto))
                .OrderBy(x => x.IbProApe)
                .ThenBy(x => x.IbProNom)
                .Select(x => new
                {
                    id = x.IbProId,
                    denominacion =
                        x.IbProApe + " " + x.IbProNom
                })
                .Take(20)
                .ToList();

            return Json(lista);
        }
    }


}