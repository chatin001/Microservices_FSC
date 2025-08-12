using Microservices.Web.Models;
using Microservices.Web.Models.Dependencia;
using Microservices.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Microservices.Web.Controllers
{
    public class DependenciaController : Controller
    {
        private readonly IDependenciaService _dependenciaService;
        public DependenciaController(IDependenciaService dependenciaService)
        {
            _dependenciaService = dependenciaService;
        }

        [HttpGet]
        public async Task<IActionResult> DependenciaIndex()
        {
            List<DependenciaDto>? list = new();
            ResponseDto? responseDto = await _dependenciaService.GetAllDependenciasAsync();

            if (responseDto != null && responseDto.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<DependenciaDto>>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = responseDto?.Message ?? "Error al obtener las Dependencias.";
            }

            return View(list);
        }

        #region Create Dependencia

        [HttpGet]
        public async Task<IActionResult> DependenciaCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DependenciaCreate(DependenciaRegisterDto dependenciaDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto responseDto = await _dependenciaService.CreateDependenciaAsync(dependenciaDto);
                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = responseDto.Message ?? "Dependencia creado correctamente.";
                    return RedirectToAction(nameof(DependenciaIndex));
                }
                else
                {
                    TempData["error"] = responseDto?.Message ?? "Error al crear el Dependencia.";
                }
            }

            return View(dependenciaDto);
        }

        #endregion

        #region Update Dependencia

        [HttpGet]
        public async Task<IActionResult> DependenciaEdit(int dependenciaId)
        {
            ResponseDto? responseDto = await _dependenciaService.GetDependenciaByIdAsync(dependenciaId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                DependenciaDto? dependenciaDto = JsonConvert.DeserializeObject<DependenciaDto>(Convert.ToString(responseDto.Result));
                if (dependenciaDto != null)
                {
                    return View(new DependenciaRegisterDto
                    {
                        DependenciaId = dependenciaDto.DependenciaId,
                        DependenciaName = dependenciaDto.DependenciaName,
                        DependenciaAbrev = dependenciaDto.DependenciaAbrev
                    });
                }
                else
                {
                    TempData["error"] = "Dependencia no encontrado.";
                }
            }
            else
            {
                TempData["error"] = responseDto?.Message ?? "Error al obtener la Dependencia.";
            }

            return RedirectToAction(nameof(DependenciaIndex));
        }
        [HttpPost]
        public async Task<IActionResult> DependenciaEdit(DependenciaRegisterDto dependenciaDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto responseDto = await _dependenciaService.UpdateDependenciaAsync(dependenciaDto);
                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = responseDto.Message ?? "Dependencia actualizado correctamente.";
                    return RedirectToAction(nameof(DependenciaIndex));
                }
                else
                {
                    TempData["error"] = responseDto?.Message ?? "Error al actualizar el Dependencia.";
                }
            }
            return View(dependenciaDto);
        }
        #endregion

        #region Delete Dependencia

        [HttpGet]
        public async Task<IActionResult> DependenciaDelete(int dependenciaId)
        {
            ResponseDto? responseDto = await _dependenciaService.GetDependenciaByIdAsync(dependenciaId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                DependenciaDto? dependenciaDto = JsonConvert.DeserializeObject<DependenciaDto>(Convert.ToString(responseDto.Result));
                return View(dependenciaDto);
            }
            else
            {
                TempData["error"] = responseDto?.Message ?? "Error al obtener la Dependencia";
            }

            return RedirectToAction(nameof(DependenciaIndex));

        }
        [HttpPost]
        public async Task<IActionResult> DependenciaDelete(DependenciaDto dependenciaDto)
        {
            ResponseDto? responseDto = await _dependenciaService.DeleteDependenciaAsync(dependenciaDto.DependenciaId);
            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["success"] = responseDto.Message ?? "Dependencia eliminado correctamente.";
                return RedirectToAction(nameof(DependenciaIndex));
            }
            else
            {
                TempData["error"] = responseDto?.Message ?? "Error al eliminar la  Dependencia.";
            }
            return View(dependenciaDto);
        }

        #endregion






    }
}
