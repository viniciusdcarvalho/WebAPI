using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Data;
using WebAPI.ViewModels.UsuariosViewModels;

namespace WebAPI.Controllers
{
    public class UsuariosController : ControllerBase
    {
        private readonly StoreDataContext _context;
        public UsuariosController(StoreDataContext context) => _context = context;
        // GET usuarios
        [Route("usuarios")]
        [HttpGet]
        public IEnumerable<ListUsuariosViewModel> Get()
        {
            return _context.Usuarios
                .Select(x => new ListUsuariosViewModel
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Celular = x.Celular
                })
                .AsNoTracking()
                .ToList();

        }

        // GET usuarios/5
        [Route("usuarios/{id}")]
        [HttpGet]
        public Usuarios Get(int id)
        {
            return _context.Usuarios.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("usuarios")]
        // POST api/values
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorUsuariosViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi poissivel cadastrar o usuario",
                    Data = model.Notifications
                };
            var usuarios = new Usuarios();
            usuarios.Id = model.Id;
            usuarios.Nome = model.Nome;
            usuarios.Celular = model.Celular;

            _context.Usuarios.Add(usuarios);
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Usuario cadastrado com sucesso",
                Data = usuarios
            };

        }
        [Route("usuarios")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorUsuariosViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi poissivel alterar o usuario",
                    Data = model.Notifications
                };
            var usuarios = _context.Usuarios.Find(model.Id);
            usuarios.Id = model.Id;
            usuarios.Nome = model.Nome;
            usuarios.Celular = model.Celular;

            _context.Entry<Usuarios>(usuarios).State = EntityState.Modified;
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Usuario alterado com sucesso",
                Data = usuarios
            };

        }

        // DELETE api/values/5
        [Route("usuarios/{id}")]
        [HttpDelete]
        public Usuarios Delete([FromBody]Usuarios usuarios)
        {
            _context.Usuarios.Remove(usuarios);
            _context.SaveChanges();

            return usuarios;
        }
    }
}