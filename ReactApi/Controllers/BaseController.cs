using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ReactApi.Controllers
{
    /// <summary>
    /// Controle base
    /// </summary>
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="uriService"></param>
        /// <param name="mapper"></param>
        public BaseController(DbContext context, IUnitOfWork unitOfWork, IUriService uriService, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _uriService = uriService;
            _mapper = mapper;
        }
        /// <summary>
        /// AutoMapper
        /// </summary>
        protected IMapper _mapper;
        /// <summary>
        /// Base de dados
        /// </summary>
        protected DbContext _context;
        /// <summary>
        /// Unidade de trabalho
        /// </summary>
        protected IUnitOfWork _unitOfWork;

        /// <summary>
        /// Uri Service
        /// </summary>
        protected IUriService _uriService;
    }
}