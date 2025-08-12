
using Microservices.Web.Models;
using Microservices.Web.Models.Grado;
using Microservices.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Microservices.Web.Controllers
{
    public class GradoController : Controller
    {
        private readonly IGradoService _gradoService;

        public GradoController(IGradoService gradoService)
        {
            _gradoService = gradoService;
        }

        #region Index
        [HttpGet]
        public async Task<IActionResult> GradoIndex()
        {

            List<GradoDto>? list = new();
            ResponseDto? response = await _gradoService.GetAllGradoAsync();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<GradoDto>>(Convert.ToString(response.Result));
            }
            else
            {
                //tempdata-Ventanita error (?? simbolo si lo de la izq no lo trae )
                TempData["error"] = response?.Message ?? "Error obteniendo los Grados.";
            }
            return View(list);
        }
        #endregion




        #region Create
        [HttpGet]
        public async Task<IActionResult> GradoCreate()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GradoCreate(GradoRegisterDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? responseDto = await _gradoService.CreateGradoAsync(model);
                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Grado creado correctamente.";
                    return RedirectToAction(nameof(GradoIndex));
                }
                else
                {
                    TempData["error"] = responseDto?.Message ?? "Error creando el Grado.";
                }
            }
            return View(model);
        }

        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> GradoUpdate(int gradoId)
        {
            ResponseDto? responseDto = await _gradoService.GetGradoByIdAsync(gradoId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                GradoDto? grado = JsonConvert.DeserializeObject<GradoDto>(Convert.ToString(responseDto.Result));
                if (grado != null)
                {
                    var gradoRegister = new GradoRegisterDto()
                    {
                        GradoId = grado.GradoId,
                        GradoCode = grado.GradoCode,
                        GradoName = grado.GradoName,
                        GradoAbrev = grado.GradoAbrev,
                    };
                    return View(gradoRegister);
                }
                else
                {
                    TempData["error"] = "Error procesando los datos del Grado.";
                    return RedirectToAction(nameof(GradoIndex));
                }
            }
            else
            {
                TempData["error"] = responseDto?.Message ?? "Error obteniendo el Grado.";
                return RedirectToAction(nameof(GradoIndex));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GradoUpdate(GradoRegisterDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? responseDto = await _gradoService.UpdateGradoAsync(model);
                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Grado actualizado exitosamente.";
                    return RedirectToAction(nameof(GradoIndex));
                }
                else
                {
                    TempData["error"] = responseDto?.Message ?? "Error actualizando el Grado.";
                }
            }
            return View(model);
        }

        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> GradoDelete(int gradoId)
        {
            ResponseDto? responseDto = await _gradoService.GetGradoByIdAsync(gradoId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                GradoDto? grado = JsonConvert.DeserializeObject<GradoDto>(Convert.ToString(responseDto.Result));
                return View(grado);
            }
            else
            {
                TempData["error"] = responseDto?.Message ?? "Error obteniendo el Grado.";
                return RedirectToAction(nameof(GradoIndex));
            }
        }

        [HttpPost]
        public async Task<IActionResult> GradoDelete(GradoRegisterDto model)
        {
            ResponseDto? responseDto = await _gradoService.DeleteGradoAsync(model.GradoId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["success"] = "Grados eliminado correctamente.";
                return RedirectToAction(nameof(GradoIndex));
            }
            else
            {
                TempData["error"] = responseDto?.Message ?? "Error eliminando el Grado.";
                return View(model);
            }
        }

        #endregion

    }
}
