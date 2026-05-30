using ConexionSql.Data;
using ConexionSql.Models.Recepciones.Ortopedias;
using Microsoft.AspNetCore.Mvc;
using ConexionSql.Models.Recepciones;
using System;
using System.Linq;
using ConexionSql.Models.Recepciones.Profesionales;

namespace ConexionSql.Controllers.Recepcion.Profesionales
{
    public class TbRecProfesionalController : Controller
    {
        private readonly ConexionSqlContext _context;

        public TbRecProfesionalController(ConexionSqlContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertarProfesional(TbRecOrtDto dto)
        {
            var fechaHoraActual = DateTime.Now;

            var cabecera = _context.TbRec
                .FirstOrDefault(x => x.TbRecId == dto.TB_REC_ID);

            var datosProfesional = _context.IbPro
                .FirstOrDefault(x => x.IbProId == dto.TB_REC_ORT_PRO_ID);

            var cantidadTotalRecibida =
                (dto.TB_REC_ORT_CANT_REC_CIN ?? 0) +
                (dto.TB_REC_ORT_CANT_REC_INS ?? 0) +
                (dto.TB_REC_ORT_CANT_REC_EST ?? 0) +
                (dto.TB_REC_ORT_CANT_REC_VS ?? 0);

            var nuevoProfesional = new TbRecOrt
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

                // PROFESIONAL PARTICULAR
                TbRecOrtOrtId = 1,
                TbRecOrtOrtDen = "PROFESIONAL PARTICULAR",

                // Access guarda acá el nombre visible del profesional
                TbRecOrtOrtPer =
                    datosProfesional != null
                    ? $"{datosProfesional.IbProApe}, {datosProfesional.IbProNom}"
                    : "NO REGISTRADO",

                TbRecOrtProId = dto.TB_REC_ORT_PRO_ID,
                TbRecOrtProNom = datosProfesional?.IbProNom,
                TbRecOrtProApe = datosProfesional?.IbProApe,

                TbRecOrtPac = dto.TB_REC_ORT_PAC,

                // Fecha entrega → FEC_PROC
                TbRecOrtFecProc = dto.TB_REC_ORT_FEC_PROC,
                TbRecOrtHorProc = dto.TB_REC_ORT_HOR_PROC,

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
                TbRecOrtNum2 = 1,
                TbRecOrtNum3 = 1,

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

            _context.TbRecOrt.Add(nuevoProfesional);

            _context.SaveChanges();

            return Json(new
            {
                success = true,
                tbRecOrtId = nuevoProfesional.TbRecOrtId,

                profesional = new
                {
                    TB_REC_ORT_ID = nuevoProfesional.TbRecOrtId,

                    TB_REC_ORT_ORT_ID = 1,
                    TB_REC_ORT_ORT_DEN = "NO REGISTRADO",

                    TB_REC_ORT_PRO_ID = nuevoProfesional.TbRecOrtProId,
                    TB_REC_ORT_PRO_NOM = nuevoProfesional.TbRecOrtProNom,
                    TB_REC_ORT_PRO_APE = nuevoProfesional.TbRecOrtProApe,

                    TB_REC_ORT_PAC = !string.IsNullOrWhiteSpace(nuevoProfesional.TbRecOrtPac)
                    ? nuevoProfesional.TbRecOrtPac
                    : "NO REGISTRADO",

                    TB_REC_ORT_REM = "0",

                    TB_REC_ORT_FEC_PROC = nuevoProfesional.TbRecOrtFecProc,
                    TB_REC_ORT_HOR_PROC = nuevoProfesional.TbRecOrtHorProc
                }
            });
        }

        [HttpGet]
        public IActionResult AbrirModalProfesional(int tbRecId)
        {
            var cabecera = _context.TbRec
                .FirstOrDefault(x => x.TbRecId == tbRecId);

                        var dto = new TbRecProfDto
                        {
                            Cabecera = cabecera,
                            TB_REC_ID = tbRecId
                        };

            return PartialView(
                "~/Views/Recepcion/Profesionales/Modals/_ModalRegistroProfesional.cshtml",
                dto
            );

        }
    }
}
