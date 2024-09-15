using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Visita.Application.Commands;
using Visita.Application.DTOs;
using Visita.Application.Queries;
using Visita.Data;
using Visita.Data.Repository;
using Visita.Domain;
using System.Collections.Generic;

namespace Visita.Application
{
    public static class VisitaConfig
    {
        public static void AddVisitaConfiguration(this IServiceCollection services)
        {
            // Commands
            services.AddScoped<IRequestHandler<AdicionarVisitaCommand, ValidationResult>, VisitaCommandHandler>();

            //Query
            services.AddScoped<IRequestHandler<VisitaPaginadoQuery, IEnumerable<VisitaPaginadoResult>>, VisitaQueryHandler>();
            services.AddScoped<IVisitaRepository, VisitaRepository>();
            
            services.AddScoped<VisitaContext>();
        }
    }
}
