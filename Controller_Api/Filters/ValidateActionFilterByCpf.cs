﻿using ApiBanco.Core.Interfaces;
using ApiBanco.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Controller_Api.Filters
{
    public class ValidateActionFilterByCpf : ActionFilterAttribute
    {
        public ICadastroService _cadastroService;
        public ValidateActionFilterByCpf(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string cpf = (string)context.ActionArguments["cpf"];
            if (_cadastroService.ConsultarCadastroCliente(cpf) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}
