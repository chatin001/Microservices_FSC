using AutoMapper;
using Microservices.Services.DependenciasAPI.Data;
using Microservices.Services.DependenciasAPI.Models;
using Microservices.Services.DependenciasAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Services.DependenciasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class DependenciaAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;
        private readonly IMapper _mapper;

        public DependenciaAPIController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Dependencia> dependenciaList = _db.Dependencias.Where(x => x.IsActive).ToList();
                _response.Result = _mapper.Map<IEnumerable<DependenciaDto>>(dependenciaList);
                _response.Message = "Dependencia obtenidos correctamente";


            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetById(int id)
        {
            try
            {
                Dependencia? dependencia = _db.Dependencias.FirstOrDefault(u => u.DependenciaId == id && u.IsActive);
                if (dependencia != null)
                {
                    _response.Result = _mapper.Map<DependenciaDto>(dependencia);
                    _response.Message = $"Dependencia {dependencia.DependenciaName} obtenido correctamente";
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Dependencia {dependencia?.DependenciaName} no encontrado";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }


        [HttpGet]
        [Route("GetByName/{name}")]
        public ResponseDto GetByName(string name)
        {
            try
            {
                Dependencia? dependencia = _db.Dependencias.FirstOrDefault(u => u.DependenciaName == name && u.IsActive);
                if (dependencia != null)
                {
                    _response.Result = _mapper.Map<DependenciaDto>(dependencia);
                    _response.Message = $"Dependencia {dependencia.DependenciaName} obtenido correctamente";
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = $"Dependencia {name} no encontrado";
                }

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }




        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ResponseDto Post([FromBody] DependenciaRegisterDto dependenciaDto)
        {
            try
            {
                if (dependenciaDto != null)
                {
                    var newDependencia = new Dependencia()
                    {
                        DependenciaName = dependenciaDto.DependenciaName,
                        DependenciaAbrev = dependenciaDto.DependenciaAbrev,
                        IsActive = true
                    };

                    _db.Dependencias.Add(newDependencia);
                    _db.SaveChanges();

                    _response.Result = dependenciaDto;
                    _response.Message = $"Dependencia {dependenciaDto.DependenciaName} creado correctamente";
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = "La Dependencia no puede ser nulo";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public ResponseDto Put([FromBody] DependenciaRegisterDto dependenciaDto)
        {
            try
            {
                if (dependenciaDto != null)
                {
                    Dependencia? dependencia = _db.Dependencias.FirstOrDefault(u => u.DependenciaId == dependenciaDto.DependenciaId && u.IsActive);

                    if (dependencia != null)
                    {
                        dependencia.DependenciaName = dependenciaDto.DependenciaName;
                        dependencia.DependenciaAbrev = dependenciaDto.DependenciaAbrev;
                    }
                    _db.SaveChanges();

                    _response.Result = dependenciaDto;
                    _response.Message = $"Dependencia {dependenciaDto.DependenciaName} actualizado correctamente";
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = "la Dependencia no puede ser nulo";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.IsSuccess = false;
                    _response.Message = "El id de la dependencia no es valido";
                }
                else
                {
                    Dependencia? dependencia = _db.Dependencias.FirstOrDefault(u => u.DependenciaId == id && u.IsActive);
                    if (dependencia != null)
                    {
                        dependencia.IsActive = false;
                        _db.Dependencias.Update(dependencia);
                        _db.SaveChanges();

                        _response.Result = true;
                        _response.Message = $"Dependencia {dependencia.DependenciaName} eliminado correctamente";
                    }
                    else
                    {
                        _response.IsSuccess = false;
                        _response.Message = $"Dependencia con nombre {dependencia?.DependenciaName} no encontrado";
                    }
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }




    }
}
