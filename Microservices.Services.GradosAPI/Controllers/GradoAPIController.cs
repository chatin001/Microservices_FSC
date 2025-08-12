using AutoMapper;
using Microservices.Services.GradosAPI.Data;
using Microservices.Services.GradosAPI.Models;
using Microservices.Services.GradosAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Services.GradosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GradoAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;
        private readonly IMapper _mapper;

        public GradoAPIController(ApplicationDbContext db, IMapper mapper)
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
                IEnumerable<Grado> gradoList = _db.Grados.Where(x => x.IsActive).ToList();
                _response.Result = _mapper.Map<IEnumerable<GradoDto>>(gradoList);
                _response.Message = "Grados obtenidos con Exito...";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error al obtener los grados {ex.Message}";
            }
            return _response;
        }


        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Grado? grado = _db.Grados.FirstOrDefault(x => x.GradoId == id);
                if (grado != null)
                {
                    _response.Result = _mapper.Map<GradoDto>(grado);
                    _response.Message = $"Grados {id} No encontrado..";
                }
                else
                {
                    _response.Result = grado;
                    _response.Message = "Grado obtenido con exito";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Ocurrio un error al obtener el Grado con id{id}:{ex.Message}";
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Grado? grado = _db.Grados.FirstOrDefault(x => x.GradoCode == code && x.IsActive);
                if (grado != null)
                {
                    _response.Result = _mapper.Map<GradoDto>(grado);
                    _response.Message = $"Grado {grado.GradoCode} recuperado con exito";
                }
                else
                {
                    _response.Result = false;
                    _response.Message = "Codigo de Grado no enconrado";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Ocurrio un error al obtener el grado con id{code}:{ex.Message}";
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ResponseDto Post([FromBody] GradoRegisterDto gradoDto)
        {
            try
            {
                if (gradoDto != null)
                {
                    var newGrado = new Grado()
                    {
                        GradoCode = gradoDto.GradoCode,
                        GradoName = gradoDto.GradoName,
                        GradoAbrev = gradoDto.GradoAbrev,
                        IsActive = true
                    };
                    _db.Grados.Add(newGrado);
                    _db.SaveChanges();

                    _response.Result = newGrado.GradoId;
                    _response.Message = $"Cupon {gradoDto.GradoCode} creado con exito";
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = "Cupon ingresado no es valido";
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Ocurrio un error al crear el cupon: {ex.Message}";
            }
            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public ResponseDto Put([FromBody] GradoRegisterDto gradoDto)
        {
            try
            {
                if (gradoDto != null && gradoDto.GradoId > 0)
                {
                    Grado? grado = _db.Grados.FirstOrDefault(x => x.GradoId == gradoDto.GradoId && x.IsActive);
                    if (grado != null)
                    {
                        grado.GradoCode = gradoDto.GradoCode;
                        grado.GradoName = gradoDto.GradoName;
                        grado.GradoAbrev = gradoDto.GradoAbrev;
                    }
                    else
                    {
                        _response.IsSuccess = false;
                        _response.Message = "Cupon no encontrado o no esta activo";
                        return _response;
                    }

                    _db.SaveChanges();

                    _response.Result = _mapper.Map<GradoDto>(grado);
                    _response.Message = $"Grado {gradoDto.GradoCode} actualizado con exito";
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = "Cupon ingresado no es valido o no tiene un ID valido";
                }

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Ocurrio un error al actualizar el cupon {gradoDto.GradoCode}: {ex.Message}";
            }

            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]

        public ResponseDto Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.IsSuccess = false;
                    _response.Message = "ID de grado no valido";

                }
                else
                {

                    Grado? grado = _db.Grados.FirstOrDefault(x => x.GradoId == id && x.IsActive);
                    if (grado != null)
                    {
                        grado.IsActive = false;
                        _db.SaveChanges();

                        _response.Message = $"Grado {grado.GradoCode} eliminado con exito";
                        _response.Result = _mapper.Map<GradoDto>(grado);
                    }
                    else
                    {
                        _response.IsSuccess = false;
                        _response.Message = $"Grado Eliminado con exito ";
                    }
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = $"Ocurrio un error al eliminar el Grado{id}:{ex.Message}";
            }
            return _response;
        }

    }
}
