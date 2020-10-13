using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.User;
using CrossCutting.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Domain;
using CrossCutting.Helpers;
using Domain.Dto.User;
using AutoMapper;

namespace ReactApi.Controllers
{
    /// <summary>
    /// UsersController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : BaseController
    {
        IUserService _userService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userService"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="uriService"></param>
        public UsersController(DbContext context, IUnitOfWork unitOfWork, IUriService uriService, IMapper mapper, IUserService userService) : base(context, unitOfWork, uriService, mapper)
        {
            _userService = userService;
        }


        /// <summary>
        /// Retornar todos os usuários
        /// </summary>
        /// <returns>Lista de usuários</returns>
        /// <response code="200">Retorna lista com todos usuários</response>
        /// <response code="401">Retorna quando não estiver autenticado.</response>
        [HttpGet]
        public ActionResult<PagedResponse<List<UserDto>>> GetUsuarios(int PageNumber, int PageSize)
        {
            var filter = AppDependencyResolver.Current.GetService<IPaginationFilter>().GetValidValues(PageNumber, PageSize);
            var route = Request.Path.Value;
            int countPages = 0;
            var pagedData = _userService.GetAll(filter, out countPages).ToList();
            PagedResponse<List<UserEntity>> pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, filter, countPages, _uriService, route);

            return Ok(pagedReponse);
        }
        /// Get api/v1/usuarios/id
        /// <summary>
        /// Retorna usuário conforme ID
        /// </summary>
        /// <returns>Lista de usuários</returns>
        /// <response code="200">Retorna o usuário conforme ID</response>
        /// <response code="401">Retorna quando não estiver autenticado.</response>
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<UserDto> GetUsuario(int id)
        {
            var usuario = _userService.GetById(id);

            if (usuario == null)
                return NotFound();

            return Ok(_mapper.Map<UserDto>(usuario));
        }

        /// Put api/v1/usuarios/id
        /// <summary>
        /// Altera dados do usuário
        /// </summary>
        /// <returns>Lista de usuários</returns>
        /// <response code="201">Retorna se o usuário foi criado com sucesso</response>
        /// <response code="400">Retorna se houve algum erro na criação do usuário.</response>
        [HttpPost]
        public ActionResult<UserDto> PostUsuario([FromBody] UserDtoCrud usuario)
        {
            var usuarioMap = _mapper.Map<UserEntity>(usuario);
            try
            {
                var result = _userService.Insert(ref usuarioMap);

                if (result.IsValid)
                {
                    _unitOfWork.Commit();
                    return CreatedAtAction("GetUsuario", new { id = usuarioMap.Id }, usuarioMap);
                }

                _unitOfWork.Rollback();
                return BadRequest(result);
            }
            catch (DbUpdateException ex)
            {
                _unitOfWork.Rollback();

                if (UsuarioExists(usuarioMap.Id))
                {
                    return Conflict(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return BadRequest(ex.Message);
            }
        }
        private bool UsuarioExists(int id)
        {
            return _userService.GetById(id) != null;
        }
    }
}
