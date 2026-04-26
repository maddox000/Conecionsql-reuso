//using System.Diagnostics;
//using System.Text.Json;
//using Conecionsql.Models;
//using Microsoft.AspNetCore.Mvc;
//using ConexionSql.Utilidades;
//using ConexionSql.Data;
//using Microsoft.EntityFrameworkCore;
//using ConexionSql.Models.Busqueda;
//using ConexionSql.Models.Equipos;
//using ConexionSql.Models.Materiales;
//using ConexionSql.Models.Sectores;

//namespace Conecionsql.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;
//        private readonly ConexionSqlContext _context;

  

//        public HomeController(ILogger<HomeController> logger, ConexionSqlContext context)
//        {
//            _logger = logger;
//            _context = context;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }

//        public IActionResult PruebaMenu()
//        {
//            return View();
//        }

//        public IActionResult TestLayout()
//        {
//            return View();
//        }

//        public async Task<IActionResult> AreaSistema(string? tipo = null)
//        {
//            var tipoNormalizado = (tipo ?? "personal").Trim().ToLowerInvariant();
//            var vm = tipoNormalizado switch
//            {
//                "equipos" => await BuildAreaSistemaEquiposVmAsync(),
//                "productos" => await BuildAreaSistemaProductosVmAsync(),
//                "proveedores" => await BuildAreaSistemaProveedoresVmAsync(),
//                "profesionales" => await BuildAreaSistemaProfesionalesVmAsync(),
//                "sectores" => await BuildAreaSistemaSectoresVmAsync(),
//                _ => await BuildAreaSistemaPersonalVmAsync()
//            };

//            ViewData["Title"] = vm.Titulo;
//            return View(vm);
//        }

//        private async Task<AreaSistemaIndexVm> BuildAreaSistemaPersonalVmAsync()
//        {
//            var filas = await _context.IbPers
//                .AsNoTracking()
//                .Where(p => p.IbPerProf != true)
//                .OrderBy(p => p.IbPerApe)
//                .ThenBy(p => p.IbPerNom)
//                .Select(p => new AreaSistemaRowVm
//                {
//                    Id = p.IbPerId.ToString(),
//                    Principal = ((p.IbPerApe ?? string.Empty) + ", " + (p.IbPerNom ?? string.Empty)).Trim(' ', ','),
//                    Secundaria = string.IsNullOrWhiteSpace(p.IbPerCarDen) ? "-" : p.IbPerCarDen,
//                    Terciaria = string.IsNullOrWhiteSpace(p.IbSecDen) ? "-" : p.IbSecDen
//                })
//                .Take(12)
//                .ToListAsync();

//            return new AreaSistemaIndexVm
//            {
//                TipoSeleccionado = "personal",
//                Titulo = "Area de sistema - Personal",
//                ColumnaPrincipal = "Nombre",
//                ColumnaSecundaria = "Cargo",
//                ColumnaTerciaria = "Seccion",
//                MensajeSinDatos = "No hay personal cargado.",
//                Filas = filas,
//                Kpis = new List<AreaSistemaKpiVm>
//                {
//                    new() { Etiqueta = "Personal", Valor = await _context.IbPers.CountAsync(p => p.IbPerProf != true) },
//                    new() { Etiqueta = "Cargos", Valor = await _context.IbPerCar.CountAsync() },
//                    new() { Etiqueta = "Unidades", Valor = await _context.IbPerUni.CountAsync() },
//                    new() { Etiqueta = "Sectores", Valor = await _context.IbSectores.CountAsync() }
//                },
//                Acciones = new List<AreaSistemaActionVm>
//                {
//                    new() { Texto = "Gestionar personal", Href = Url.Action("Index", "IbPer") ?? "#", CssClass = "btn btn-primary btn-sm" },
//                    new() { Texto = "Nuevo personal", Href = Url.Action("InsertIbPer", "IbPer") ?? "#", CssClass = "btn btn-outline-primary btn-sm" },
//                    new() { Texto = "Edicion masiva", Href = Url.Action("IbPerEdit", "IbPer") ?? "#", CssClass = "btn btn-outline-secondary btn-sm" }
//                }
//            };
//        }

//        private async Task<AreaSistemaIndexVm> BuildAreaSistemaEquiposVmAsync()
//        {
//            var filas = await _context.IbEqu
//                .AsNoTracking()
//                .OrderBy(e => e.IbEquId)
//                .Select(e => new AreaSistemaRowVm
//                {
//                    Id = e.IbEquId.ToString(),
//                    Principal = string.IsNullOrWhiteSpace(e.IbEquTeqDen) ? "-" : e.IbEquTeqDen,
//                    Secundaria = string.IsNullOrWhiteSpace(e.IbEquMarDen) ? "-" : e.IbEquMarDen,
//                    Terciaria = string.IsNullOrWhiteSpace(e.IbEquMod) ? "-" : e.IbEquMod,
//                    NumeroSerie = string.IsNullOrWhiteSpace(e.IbEquSer) ? "-" : e.IbEquSer,
//                    Ocultar = e.IbEquOcu
//                })
//                .Take(100)
//                .ToListAsync();

//            return new AreaSistemaIndexVm
//            {
//                TipoSeleccionado = "equipos",
//                Titulo = "Area de sistema - Equipos",
//                ColumnaPrincipal = "Denominación",
//                ColumnaSecundaria = "Marca",
//                ColumnaTerciaria = "Modelo",
//                ColumnaCuarta = "Número de Serie",
//                ColumnaQuinta = "Ocultar",
//                MensajeSinDatos = "No hay equipos cargados.",
//                Filas = filas,
//                Kpis = new List<AreaSistemaKpiVm>
//                {
//                    new() { Etiqueta = "Equipos", Valor = await _context.IbEqu.CountAsync() },
//                    new() { Etiqueta = "Tipos", Valor = await _context.IbEquPti.CountAsync() },
//                    new() { Etiqueta = "Marcas", Valor = await _context.IbEqu.Where(e => !string.IsNullOrWhiteSpace(e.IbEquMarDen)).Select(e => e.IbEquMarDen).Distinct().CountAsync() },
//                    new() { Etiqueta = "Con serie", Valor = await _context.IbEqu.CountAsync(e => !string.IsNullOrWhiteSpace(e.IbEquSer)) }
//                },
//                Acciones = new List<AreaSistemaActionVm>
//                {
//                    new() { Texto = "Nuevo", Href = Url.Action("CrearEquipo", "Home") ?? "#", CssClass = "btn btn-secondary btn-sm" },
//                    new() { Texto = "Exportar", Href = "#", CssClass = "btn btn-secondary btn-sm" },
//                    new() { Texto = "Editar", Href = "#", CssClass = "btn btn-secondary btn-sm" },
//                    new() { Texto = "Cerrar", Href = Url.Action("Index", "Home") ?? "#", CssClass = "btn btn-secondary btn-sm" }
//                }
//            };
//        }

//        [HttpPost]
//        [IgnoreAntiforgeryToken]
//        public async Task<IActionResult> ActualizarEstadoEquipo(int id, bool ocultar)
//        {
//            var equipo = await _context.IbEqu.FindAsync(id);
//            if (equipo == null)
//                return Json(new { success = false, message = "Equipo no encontrado" });

//            equipo.IbEquOcu = ocultar;
//            await _context.SaveChangesAsync();
//            return Json(new { success = true });
//        }

//        [HttpPost]
//        public async Task<IActionResult> GuardarEstadosEquipos(IFormCollection form)
//        {
//            var equipos = await _context.IbEqu.ToListAsync();
//            foreach (var equipo in equipos)
//            {
//                var checkboxName = $"equipoOculto_{equipo.IbEquId}";
//                equipo.IbEquOcu = form.ContainsKey(checkboxName);
//            }
            
//            await _context.SaveChangesAsync();
//            TempData["mensaje"] = "Estados de equipos guardados correctamente";
//            return RedirectToAction(nameof(AreaSistema), new { tipo = "equipos" });
//        }

//        public async Task<IActionResult> CrearEquipo()
//        {
//            return View();
//        }

//        public async Task<IActionResult> EditarEquipo(int id)
//        {
//            var equipo = await _context.IbEqu
//                .AsNoTracking()
//                .FirstOrDefaultAsync(e => e.IbEquId == id);

//            if (equipo == null)
//                return NotFound();

//            var dto = new IbEquDto
//            {
//                IbEquId = equipo.IbEquId,
//                IbEquTeqId = equipo.IbEquTeqId,
//                IbEquTeqDen = equipo.IbEquTeqDen,
//                IbEquPtiId = equipo.IbEquPtiId,
//                IbEquPtiDen = equipo.IbEquPtiDen,
//                IbEquMarId = equipo.IbEquMarId,
//                IbEquMarDen = equipo.IbEquMarDen,
//                IbEquMod = equipo.IbEquMod,
//                IbEquSer = equipo.IbEquSer,
//                IbEquNum = equipo.IbEquNum,
//                IbEquAlt = equipo.IbEquAlt,
//                IbEquAnc = equipo.IbEquAnc,
//                IbEquPro = equipo.IbEquPro,
//                IbEquPorc = equipo.IbEquPorc,
//                IbEquCap = equipo.IbEquCap,
//                IbEquCapu = equipo.IbEquCapu,
//                IbEquCagCant = equipo.IbEquCagCant,
//                IbEquCagVal = equipo.IbEquCagVal,
//                IbEquCag = equipo.IbEquCag,
//                IbEquCaiCant = equipo.IbEquCaiCant,
//                IbEquCaiVal = equipo.IbEquCaiVal,
//                IbEquCai = equipo.IbEquCai,
//                IbEquCelCant = equipo.IbEquCelCant,
//                IbEquCelVal = equipo.IbEquCelVal,
//                IbEquCel = equipo.IbEquCel,
//                IbEquCesCant = equipo.IbEquCesCant,
//                IbEquCesVal = equipo.IbEquCesVal,
//                IbEquCes = equipo.IbEquCes,
//                IbEquPteCant = equipo.IbEquPteCant,
//                IbEquPteVal = equipo.IbEquPteVal,
//                IbEquPte = equipo.IbEquPte,
//                IbEquPco = equipo.IbEquPco,
//                IbEquPcoCoef = equipo.IbEquPcoCoef,
//                IbEquPve = equipo.IbEquPve,
//                IbEquOcu = equipo.IbEquOcu,
//                Usuario = "NO REGISTRADO",
//                Cargo = "NO REGISTRADO",
//                TipoCiclo = equipo.IbEquPtiDen
//            };

//            return View(dto);
//        }

//        public async Task<IActionResult> ViewEquipo(int id)
//        {
//            var equipo = await _context.IbEqu
//                .AsNoTracking()
//                .FirstOrDefaultAsync(e => e.IbEquId == id);

//            if (equipo == null)
//                return NotFound();

//            var dto = new IbEquDto
//            {
//                IbEquId = equipo.IbEquId,
//                IbEquTeqId = equipo.IbEquTeqId,
//                IbEquTeqDen = equipo.IbEquTeqDen,
//                IbEquPtiId = equipo.IbEquPtiId,
//                IbEquPtiDen = equipo.IbEquPtiDen,
//                IbEquMarId = equipo.IbEquMarId,
//                IbEquMarDen = equipo.IbEquMarDen,
//                IbEquMod = equipo.IbEquMod,
//                IbEquSer = equipo.IbEquSer,
//                IbEquNum = equipo.IbEquNum,
//                IbEquAlt = equipo.IbEquAlt,
//                IbEquAnc = equipo.IbEquAnc,
//                IbEquPro = equipo.IbEquPro,
//                IbEquPorc = equipo.IbEquPorc,
//                IbEquCap = equipo.IbEquCap,
//                IbEquCapu = equipo.IbEquCapu,
//                IbEquCagCant = equipo.IbEquCagCant,
//                IbEquCagVal = equipo.IbEquCagVal,
//                IbEquCag = equipo.IbEquCag,
//                IbEquCaiCant = equipo.IbEquCaiCant,
//                IbEquCaiVal = equipo.IbEquCaiVal,
//                IbEquCai = equipo.IbEquCai,
//                IbEquCelCant = equipo.IbEquCelCant,
//                IbEquCelVal = equipo.IbEquCelVal,
//                IbEquCel = equipo.IbEquCel,
//                IbEquCesCant = equipo.IbEquCesCant,
//                IbEquCesVal = equipo.IbEquCesVal,
//                IbEquCes = equipo.IbEquCes,
//                IbEquPteCant = equipo.IbEquPteCant,
//                IbEquPteVal = equipo.IbEquPteVal,
//                IbEquPte = equipo.IbEquPte,
//                IbEquPco = equipo.IbEquPco,
//                IbEquPcoCoef = equipo.IbEquPcoCoef,
//                IbEquPve = equipo.IbEquPve,
//                IbEquOcu = equipo.IbEquOcu,
//                Usuario = "NO REGISTRADO",
//                Cargo = "NO REGISTRADO",
//                TipoCiclo = equipo.IbEquPtiDen
//            };

//            return View(dto);
//        }

//        [HttpPost]
//        public async Task<IActionResult> EliminarDeListados(int id)
//        {
//            var equipo = await _context.IbEqu.FindAsync(id);
            
//            if (equipo == null)
//                return NotFound();

//            // Cambiar el estado de oculto/eliminado
//            equipo.IbEquOcu = !equipo.IbEquOcu;
            
//            _context.IbEqu.Update(equipo);
//            await _context.SaveChangesAsync();

//            return RedirectToAction("ViewEquipo", new { id = id });
//        }

//        [HttpPost]
//        public async Task<IActionResult> GuardarEquipo(
//            int id, string denominacion, string? marca, string? modelo, string? numeroSerie,
//            int? numero, int? alturaCamara, int? anchoCamara, int? profundidad,
//            int? capacidadCarga, int? capacidadTotal, int? porcentajeCamara, int? capacidadUtil,
//            int? consumoAgua, int? consumoAire, int? consumoElectricidad, int? consumoEsterilizante, int? consumoControles,
//            int? valoresLbs, int? valoresLi, int? valoresKw,
//            int? costoProceso, int? coefGanancia, int? precioVenta)
//        {
//            var equipo = id > 0
//                ? await _context.IbEqu.FindAsync(id)
//                : new IbEqu();

//            if (equipo == null)
//                return NotFound();

//            equipo.IbEquTeqDen = denominacion;
//            equipo.IbEquMarDen = marca;
//            equipo.IbEquMod = modelo;
//            equipo.IbEquSer = numeroSerie;
//            equipo.IbEquNum = numero;
//            equipo.IbEquAlt = alturaCamara ?? 0;
//            equipo.IbEquAnc = anchoCamara ?? 0;
//            equipo.IbEquPro = profundidad ?? 0;
//            equipo.IbEquCap = capacidadCarga ?? 0;
//            equipo.IbEquCapu = capacidadTotal;
//            equipo.IbEquPorc = porcentajeCamara;
//            equipo.IbEquCag = consumoAgua;
//            equipo.IbEquCai = consumoAire?.ToString();
//            equipo.IbEquCel = consumoElectricidad;
//            equipo.IbEquCes = consumoEsterilizante;
//            equipo.IbEquPte = consumoControles;
//            equipo.IbEquCagCant = valoresLbs;
//            equipo.IbEquCaiCant = valoresLi;
//            equipo.IbEquCelCant = valoresKw;
//            equipo.IbEquPco = costoProceso;
//            equipo.IbEquPcoCoef = coefGanancia;
//            equipo.IbEquPve = precioVenta;

//            if (id <= 0)
//                _context.IbEqu.Add(equipo);
//            else
//                _context.IbEqu.Update(equipo);

//            await _context.SaveChangesAsync();
//            return Json(new { success = true, message = "Equipo guardado correctamente" });
//        }

//        [HttpPost]
//        [IgnoreAntiforgeryToken]
//        public async Task<IActionResult> ModificarProducto([FromBody] JsonElement data)
//        {
//            try
//            {
//                int productoId = data.GetProperty("id").GetInt32();
//                string codigo = data.GetProperty("codigo").GetString() ?? "";
//                string denominacion = data.GetProperty("denominacion").GetString() ?? "";
//                string tipo = data.GetProperty("tipo").GetString() ?? "";
//                string ubicacion = data.GetProperty("ubicacion").GetString() ?? "";
//                int contenido = data.GetProperty("contenido").GetInt32();
//                string catalogo = data.GetProperty("catalogo").GetString() ?? "";
//                bool controlado = data.GetProperty("controlado").GetBoolean();
//                bool oculto = data.GetProperty("oculto").GetBoolean();

//                // Buscar el producto en la base de datos
//                var producto = await _context.IbMat.FindAsync(productoId);
//                if (producto == null)
//                    return Json(new { success = false, message = "Producto no encontrado" });

//                // Actualizar los campos
//                producto.IB_MAT_PR = codigo;
//                producto.IB_MAT_DEN = denominacion;
//                producto.IB_MAT_MTI_DEN = tipo;
//                producto.IB_MAT_PTE1_UBI_DEN = ubicacion;
//                producto.IB_MAT_CON_UNID = contenido;
//                producto.IB_MAT_CON_OPC = controlado;
//                producto.IB_MAT_OCU = oculto;

//                // Guardar los cambios
//                _context.IbMat.Update(producto);
//                await _context.SaveChangesAsync();

//                return Json(new { success = true, message = "Producto modificado exitosamente", id = productoId });
//            }
//            catch (Exception ex)
//            {
//                return Json(new { success = false, message = $"Error al modificar producto: {ex.Message}" });
//            }
//        }

//        // ========== PROVEEDORES ==========

//        [HttpGet]
//        public async Task<IActionResult> InsertProveedor()
//        {
//            var maxId = await _context.IbProv.AnyAsync()
//                ? await _context.IbProv.MaxAsync(p => p.IbProvId)
//                : 0;
//            ViewBag.SiguienteCodigo = (maxId + 1).ToString("D4");
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> InsertProveedor(string denominacion)
//        {
//            if (string.IsNullOrWhiteSpace(denominacion))
//            {
//                var maxId2 = await _context.IbProv.AnyAsync()
//                    ? await _context.IbProv.MaxAsync(p => p.IbProvId)
//                    : 0;
//                ViewBag.SiguienteCodigo = (maxId2 + 1).ToString("D4");
//                ViewBag.Error = "La denominación es obligatoria.";
//                return View();
//            }

//            var nuevo = new IbProv
//            {
//                IbProvDen = denominacion.Trim().ToUpper(),
//                IbProvOcu = false
//            };
//            _context.IbProv.Add(nuevo);
//            await _context.SaveChangesAsync();

//            return Content("<div><script>window.BaxenShell.navigate('/Home/AreaSistema?tipo=proveedores', true);</script></div>", "text/html");
//        }

//        [HttpGet]
//        public async Task<IActionResult> EditarProveedores()
//        {
//            var proveedores = await _context.IbProv
//                .OrderBy(p => p.IbProvId)
//                .ToListAsync();
//            return View(proveedores);
//        }

//        [HttpPost]
//        public async Task<IActionResult> EditarProveedores(List<IbProv> proveedores)
//        {
//            if (proveedores != null)
//            {
//                foreach (var item in proveedores)
//                {
//                    var entity = await _context.IbProv.FindAsync(item.IbProvId);
//                    if (entity != null)
//                    {
//                        entity.IbProvDen = item.IbProvDen?.Trim().ToUpper();
//                        entity.IbProvOcu = item.IbProvOcu;
//                    }
//                }
//                await _context.SaveChangesAsync();
//            }

//            return Content("<div><script>window.BaxenShell.navigate('/Home/AreaSistema?tipo=proveedores', true);</script></div>", "text/html");
//        }

//        private async Task<AreaSistemaIndexVm> BuildAreaSistemaProductosVmAsync()
//        {
//            var filas = await _context.IbMat
//                .AsNoTracking()
//                .OrderBy(m => m.IB_MAT_DEN)
//                .ThenBy(m => m.IB_MAT_ID)
//                .Select(m => new AreaSistemaRowVm
//                {
//                    Id = m.IB_MAT_ID.ToString(),
//                    CodigoProducto = string.IsNullOrWhiteSpace(m.IB_MAT_PR) ? "-" : m.IB_MAT_PR,
//                    Principal = string.IsNullOrWhiteSpace(m.IB_MAT_DEN) ? "-" : m.IB_MAT_DEN,
//                    Secundaria = string.IsNullOrWhiteSpace(m.IB_MAT_MTI_DEN) ? "-" : m.IB_MAT_MTI_DEN,
//                    Terciaria = string.IsNullOrWhiteSpace(m.IB_MAT_MAR_DEN) ? "-" : m.IB_MAT_MAR_DEN,
//                    UbicacionFisica = string.IsNullOrWhiteSpace(m.IB_MAT_PTE1_UBI_DEN) ? "-" : m.IB_MAT_PTE1_UBI_DEN,
//                    Contenido = m.IB_MAT_CON_UNID.HasValue ? m.IB_MAT_CON_UNID.ToString() : "-",
//                    Controlado = m.IB_MAT_CON_OPC,
//                    Ocultar = m.IB_MAT_OCU
//                })
//                .Take(50)
//                .ToListAsync();

//http://localhost:5000/Home/EditarSectores            // Calcular siguiente código de producto
//            var ultimoCodigo = await _context.IbMat
//                .AsNoTracking()
//                .Where(m => m.IB_MAT_PR != null && m.IB_MAT_PR.StartsWith("PR-"))
//                .Select(m => m.IB_MAT_PR)
//                .ToListAsync();

//            int maxNumero = 0;
//            foreach (var cod in ultimoCodigo)
//            {
//                var parteNumerica = cod!.Substring(3);
//                if (int.TryParse(parteNumerica, out int num) && num > maxNumero)
//                    maxNumero = num;
//            }
//            var siguienteCodigo = $"PR-{(maxNumero + 1).ToString("D4")}";

//            return new AreaSistemaIndexVm
//            {
//                TipoSeleccionado = "productos",
//                Titulo = "Area de sistema - Productos medicos",
//                SiguienteCodigoProducto = siguienteCodigo,
//                ColumnaPrincipal = "Código Producto",
//                ColumnaSecundaria = "Denominación",
//                ColumnaTerciaria = "Tipo",
//                ColumnaCuarta = "Ubicación",
//                ColumnaQuinta = "Contenido",
//                MensajeSinDatos = "No hay productos medicos cargados.",
//                Filas = filas,
//                Kpis = new List<AreaSistemaKpiVm>
//                {
//                    new() { Etiqueta = "Productos", Valor = await _context.IbMat.CountAsync() },
//                    new() { Etiqueta = "Tipos", Valor = await _context.IbMat.Where(m => !string.IsNullOrWhiteSpace(m.IB_MAT_MTI_DEN)).Select(m => m.IB_MAT_MTI_DEN).Distinct().CountAsync() },
//                    new() { Etiqueta = "Ubicaciones", Valor = await _context.IbMat.Where(m => !string.IsNullOrWhiteSpace(m.IB_MAT_PTE1_UBI_DEN)).Select(m => m.IB_MAT_PTE1_UBI_DEN).Distinct().CountAsync() },
//                    new() { Etiqueta = "Controlados", Valor = await _context.IbMat.CountAsync(m => m.IB_MAT_CON_OPC) }
//                }
//            };
//        }

//        private async Task<AreaSistemaIndexVm> BuildAreaSistemaProveedoresVmAsync()
//        {
//            var filas = await _context.IbProv
//                .AsNoTracking()
//                .OrderBy(p => p.IbProvId)
//                .Select(p => new AreaSistemaRowVm
//                {
//                    Id = p.IbProvId.ToString(),
//                    Principal = string.IsNullOrWhiteSpace(p.IbProvDen) ? "-" : p.IbProvDen,
//                    Ocultar = p.IbProvOcu
//                })
//                .ToListAsync();

//            return new AreaSistemaIndexVm
//            {
//                TipoSeleccionado = "proveedores",
//                Titulo = "Información Básica - Proveedores",
//                ColumnaPrincipal = "Proveedor",
//                MensajeSinDatos = "No hay proveedores cargados.",
//                Filas = filas,
//                Kpis = new List<AreaSistemaKpiVm>
//                {
//                    new() { Etiqueta = "Proveedores", Valor = await _context.IbProv.CountAsync() },
//                    new() { Etiqueta = "Activos", Valor = await _context.IbProv.CountAsync(p => !p.IbProvOcu) },
//                    new() { Etiqueta = "Inhabilitados", Valor = await _context.IbProv.CountAsync(p => p.IbProvOcu) }
//                }
//            };
//        }

//        private async Task<AreaSistemaIndexVm> BuildAreaSistemaProfesionalesVmAsync()
//        {
//            var filas = await _context.IbPers
//                .AsNoTracking()
//                .Where(p => p.IbPerProf == true)
//                .OrderBy(p => p.IbPerApe)
//                .ThenBy(p => p.IbPerNom)
//                .Select(p => new AreaSistemaRowVm
//                {
//                    Id = p.IbPerId.ToString(),
//                    Principal = string.IsNullOrWhiteSpace(p.IbPerApe) ? "-" : p.IbPerApe,
//                    Secundaria = string.IsNullOrWhiteSpace(p.IbPerNom) ? "-" : p.IbPerNom,
//                    SectorEntrega = string.IsNullOrWhiteSpace(p.IbSecDen) ? "-" : p.IbSecDen,
//                    Ocultar = p.IbPerOcu == true
//                })
//                .ToListAsync();

//            return new AreaSistemaIndexVm
//            {
//                TipoSeleccionado = "profesionales",
//                Titulo = "Area de sistema - Profesionales",
//                ColumnaPrincipal = "Apellido",
//                ColumnaSecundaria = "Nombre",
//                ColumnaTerciaria = "Inhabilitado",
//                MensajeSinDatos = "No hay profesionales cargados.",
//                Filas = filas,
//                Kpis = new List<AreaSistemaKpiVm>
//                {
//                    new() { Etiqueta = "Personal", Valor = await _context.IbPers.CountAsync(p => p.IbPerProf == true) },
//                    new() { Etiqueta = "Habilitados", Valor = await _context.IbPers.CountAsync(p => p.IbPerProf == true && p.IbPerOcu != true) },
//                    new() { Etiqueta = "Inhabilitados", Valor = await _context.IbPers.CountAsync(p => p.IbPerProf == true && p.IbPerOcu == true) },
//                    new() { Etiqueta = "Sectores", Valor = await _context.IbSectores.CountAsync() }
//                }
//            };
//        }

//        private async Task<AreaSistemaIndexVm> BuildAreaSistemaSectoresVmAsync()
//        {
//            var filas = await _context.IbSectores
//                .AsNoTracking()
//                .OrderBy(s => s.IbSecDen)
//                .ThenBy(s => s.IbSecId)
//                .Select(s => new AreaSistemaRowVm
//                {
//                    Id = s.IbSecId.ToString(),
//                    Principal = string.IsNullOrWhiteSpace(s.IbSecDen) ? "-" : s.IbSecDen,
//                    SectorDestino = string.IsNullOrWhiteSpace(s.IbSecDesDen) ? "-" : s.IbSecDesDen,
//                    Trasladados = s.IbSecTraOpc,
//                    Ocultar = s.IbSecOcu
//                })
//                .ToListAsync();

//            return new AreaSistemaIndexVm
//            {
//                TipoSeleccionado = "sectores",
//                Titulo = "Area de sistema - Sectores",
//                ColumnaPrincipal = "Sector",
//                ColumnaSecundaria = "Sector de Destino",
//                ColumnaTerciaria = "Estado",
//                MensajeSinDatos = "No hay sectores cargados.",
//                Filas = filas,
//                Kpis = new List<AreaSistemaKpiVm>
//                {
//                    new() { Etiqueta = "Total Sectores", Valor = await _context.IbSectores.CountAsync() },
//                    new() { Etiqueta = "Con destino", Valor = await _context.IbSectores.Where(s => !string.IsNullOrWhiteSpace(s.IbSecDesDen)).CountAsync() },
//                    new() { Etiqueta = "Con trasladados", Valor = await _context.IbSectores.CountAsync(s => s.IbSecTraOpc) },
//                    new() { Etiqueta = "Ocultos", Valor = await _context.IbSectores.CountAsync(s => s.IbSecOcu) }
//                }
//            };
//        }

//        public async Task<IActionResult> EditarSectores()
//        {
//            var sectores = await _context.IbSectores
//                .OrderBy(s => s.IbSecDen)
//                .ThenBy(s => s.IbSecId)
//                .ToListAsync();
            
//            // Pasar también la lista de destinos disponibles al ViewBag
//            ViewBag.SectoresDestino = await _context.IbSectores
//                .Where(s => !s.IbSecOcu)
//                .OrderBy(s => s.IbSecDen)
//                .Select(s => new { s.IbSecId, s.IbSecDen })
//                .ToListAsync();
            
//            return View(sectores);
//        }

//        [HttpPost]
//        public async Task<IActionResult> GuardarSectores(IFormCollection form)
//        {
//            try
//            {
//                var trasladadosIds = form["Trasladados"]
//                    .Select(x => int.TryParse(x, out var id) ? id : (int?)null)
//                    .Where(x => x.HasValue)
//                    .Select(x => x.Value)
//                    .ToList();

//                var ocultosIds = form["Ocultar"]
//                    .Select(x => int.TryParse(x, out var id) ? id : (int?)null)
//                    .Where(x => x.HasValue)
//                    .Select(x => x.Value)
//                    .ToList();

//                var sectores = await _context.IbSectores.ToListAsync();
                
//                foreach (var sector in sectores)
//                {
//                    // Actualizar checkboxes
//                    sector.IbSecTraOpc = trasladadosIds.Contains(sector.IbSecId);
//                    sector.IbSecOcu = ocultosIds.Contains(sector.IbSecId);

//                    // Actualizar Sector nombre si fue editado
//                    var nombreKey = $"SectorNombre_{sector.IbSecId}";
//                    if (form.ContainsKey(nombreKey))
//                    {
//                        var nuevoNombre = form[nombreKey].FirstOrDefault();
//                        if (!string.IsNullOrWhiteSpace(nuevoNombre) && nuevoNombre != "-")
//                        {
//                            sector.IbSecDen = nuevoNombre.Trim().ToUpper();
//                        }
//                    }

//                    // Actualizar Sector Destino si fue seleccionado
//                    var destinoKey = $"SectorDestino_{sector.IbSecId}";
//                    if (form.ContainsKey(destinoKey))
//                    {
//                        var destinoIdStr = form[destinoKey].FirstOrDefault();
//                        if (!string.IsNullOrWhiteSpace(destinoIdStr) && int.TryParse(destinoIdStr, out var destinoId))
//                        {
//                            // Obtener el nombre del sector destino
//                            var sectorDestino = sectores.FirstOrDefault(s => s.IbSecId == destinoId);
//                            if (sectorDestino != null)
//                            {
//                                sector.IbSecDesId = destinoId;
//                                sector.IbSecDesDen = sectorDestino.IbSecDen;
//                            }
//                        }
//                        else
//                        {
//                            // Limpiar el destino
//                            sector.IbSecDesId = null;
//                            sector.IbSecDesDen = null;
//                        }
//                    }
//                }

//                await _context.SaveChangesAsync();

//                return Content("<div><script>window.BaxenShell.navigate('/Home/AreaSistema?tipo=sectores', true);</script></div>", "text/html");
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error al guardar sectores");
//                return BadRequest("Error al guardar los datos");
//            }
//        }

//        public async Task<IActionResult> CrearSector()
//        {
//            // Calcular siguiente código
//            var maxId = await _context.IbSectores.AnyAsync()
//                ? await _context.IbSectores.MaxAsync(s => s.IbSecId)
//                : 0;
//            ViewBag.SiguienteCodigo = (maxId + 1).ToString("D4");

//            // Obtener sectores disponibles para destino
//            ViewBag.SectoresDestino = await _context.IbSectores
//                .Where(s => !s.IbSecOcu)
//                .OrderBy(s => s.IbSecDen)
//                .Select(s => new { s.IbSecId, s.IbSecDen })
//                .ToListAsync();

//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> GuardarNuevoSector(string sectorNombre, int? sectorDestino, bool trasladados, bool ocultar)
//        {
//            try
//            {
//                if (string.IsNullOrWhiteSpace(sectorNombre))
//                {
//                    var maxId = await _context.IbSectores.AnyAsync()
//                        ? await _context.IbSectores.MaxAsync(s => s.IbSecId)
//                        : 0;
//                    ViewBag.SiguienteCodigo = (maxId + 1).ToString("D4");
//                    ViewBag.SectoresDestino = await _context.IbSectores
//                        .Where(s => !s.IbSecOcu)
//                        .OrderBy(s => s.IbSecDen)
//                        .Select(s => new { s.IbSecId, s.IbSecDen })
//                        .ToListAsync();
//                    ViewBag.Error = "El nombre del sector es obligatorio.";
//                    return View("CrearSector");
//                }

//                // Obtener el siguiente ID
//                var maxId2 = await _context.IbSectores.AnyAsync()
//                    ? await _context.IbSectores.MaxAsync(s => s.IbSecId)
//                    : 0;
//                int nuevoId = maxId2 + 1;

//                // Obtener datos del sector destino si existe
//                int? destinoId = null;
//                string? destinoDen = null;
//                if (sectorDestino.HasValue && sectorDestino > 0)
//                {
//                    var secDestino = await _context.IbSectores.FirstOrDefaultAsync(s => s.IbSecId == sectorDestino.Value);
//                    if (secDestino != null)
//                    {
//                        destinoId = secDestino.IbSecId;
//                        destinoDen = secDestino.IbSecDen;
//                    }
//                }

//                // Crear nuevo sector
//                var nuevoSector = new IbSec
//                {
//                    IbSecDen = sectorNombre.Trim().ToUpper(),
//                    IbSecDesId = destinoId,
//                    IbSecDesDen = destinoDen,
//                    IbSecTraOpc = trasladados,
//                    IbSecOcu = ocultar
//                };

//                _context.IbSectores.Add(nuevoSector);
//                await _context.SaveChangesAsync();

//                return Content("<div><script>window.BaxenShell.navigate('/Home/AreaSistema?tipo=sectores', true);</script></div>", "text/html");
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error al guardar nuevo sector");
//                var maxId = await _context.IbSectores.AnyAsync()
//                    ? await _context.IbSectores.MaxAsync(s => s.IbSecId)
//                    : 0;
//                ViewBag.SiguienteCodigo = (maxId + 1).ToString("D4");
//                ViewBag.SectoresDestino = await _context.IbSectores
//                    .Where(s => !s.IbSecOcu)
//                    .OrderBy(s => s.IbSecDen)
//                    .Select(s => new { s.IbSecId, s.IbSecDen })
//                    .ToListAsync();
//                ViewBag.Error = "Error al guardar el sector.";
//                return View("CrearSector");
//            }
//        }

//        public IActionResult Placeholder(string id, string title)
//        {
//            ViewData["Title"] = string.IsNullOrWhiteSpace(title) ? "Modulo en construccion" : title;
//            ViewBag.PlaceholderId = id;
//            return View();
//        }

//        [HttpGet("/Placeholder/{id?}")]
//        public IActionResult PlaceholderDirect(string id, string title)
//        {
//            ViewData["Title"] = string.IsNullOrWhiteSpace(title) ? "Modulo en construccion" : title;
//            ViewBag.PlaceholderId = id;
//            return View("Placeholder");
//        }

//        //metodo para la impresion
//        [HttpPost]
//        public IActionResult ImprimirEtiqueta()
//        {
//            string zpl = "^XA" +
//               "^PW480" +                      // Ancho de 6 cm convertido a 480 puntos
//               "^LL360" +                      // Largo de 4.5 cm convertido a 360 puntos
//               "^CF0,60" +                     // Fuente grande (60 puntos) para BAXEN
//               "^FO0,30^FB480,1,0,C^FDBAXEN^FS" +    // BAXEN centrado, 30px desde arriba
//               "^CF0,30" +                     // Fuente m�s chica (30 puntos) para las otras dos l�neas
//               "^FO0,150^FB480,1,0,C^FDImpresora Zebra^FS" + // Segunda l�nea centrada
//               "^FO0,220^FB480,1,0,C^FDse logro la impresion^FS" + // Tercera l�nea centrada
//               "^XZ";



//            string impresora = "ZDesigner GK420t"; // <-- Ac� pon� el nombre real de tu impresora

//            try
//            {
//                ImpresionZebra.EnviarAImpresora(impresora, zpl);
//                return Content("Etiqueta enviada a la impresora.");
//            }
//            catch (Exception ex)
//            {
//                return Content($"Error al imprimir: {ex.Message}");
//            }
//        }

//        // GET: Home/ExportarProfesionales?modo=pdf|impresora
//        [HttpGet]
//        public async Task<IActionResult> ExportarProfesionales(string modo)
//        {
//            var profesionales = await _context.IbPers
//                .AsNoTracking()
//                .Where(p => p.IbPerProf == true)
//                .OrderBy(p => p.IbPerApe)
//                .ThenBy(p => p.IbPerNom)
//                .Select(p => new
//                {
//                    Codigo = p.IbPerId.ToString().PadLeft(5, '0'),
//                    Apellido = string.IsNullOrWhiteSpace(p.IbPerApe) ? "-" : p.IbPerApe,
//                    Nombre = string.IsNullOrWhiteSpace(p.IbPerNom) ? "-" : p.IbPerNom,
//                    Sector = string.IsNullOrWhiteSpace(p.IbSecDen) ? "-" : p.IbSecDen,
//                    Inhabilitado = p.IbPerOcu == true
//                })
//                .ToListAsync();

//            var filas = "";
//            foreach (var p in profesionales)
//            {
//                filas += $"<tr><td>{p.Codigo}</td><td>{p.Apellido}</td><td>{p.Nombre}</td><td>{p.Sector}</td><td style='text-align:center'>{(p.Inhabilitado ? "Sí" : "No")}</td></tr>\n";
//            }

//            var autoprint = modo == "impresora" ? "<script>window.onload=function(){window.print();}</script>" : "";

//            var html = $@"<!DOCTYPE html>
//<html>
//<head>
//<meta charset='utf-8'/>
//<title>Listado de Profesionales</title>
//<style>
//    body {{ font-family: Arial, sans-serif; margin: 20px; color: #2c3e50; }}
//    h2 {{ text-align: center; margin-bottom: 4px; }}
//    .fecha {{ text-align: center; font-size: 0.85rem; color: #666; margin-bottom: 16px; }}
//    table {{ width: 100%; border-collapse: collapse; font-size: 0.85rem; }}
//    th {{ background-color: #2c3e50; color: white; padding: 8px; text-align: left; }}
//    td {{ padding: 6px 8px; border-bottom: 1px solid #ddd; }}
//    tr:nth-child(even) {{ background-color: #f9f9f9; }}
//    .total {{ margin-top: 12px; font-size: 0.85rem; color: #555; }}
//    @media print {{
//        body {{ margin: 0; }}
//        button {{ display: none !important; }}
//    }}
//</style>
//{autoprint}
//</head>
//<body>
//<h2>Listado de Profesionales</h2>
//<div class='fecha'>Fecha de emisión: {DateTime.Now:dd/MM/yyyy HH:mm}</div>
//<table>
//<thead><tr><th>Código</th><th>Apellido</th><th>Nombre</th><th>Sector entrega</th><th style='text-align:center'>Inhabilitado</th></tr></thead>
//<tbody>
//{filas}
//</tbody>
//</table>
//<div class='total'>Total de profesionales: {profesionales.Count}</div>
//</body>
//</html>";

//            return Content(html, "text/html");
//        }

//    }
//}
