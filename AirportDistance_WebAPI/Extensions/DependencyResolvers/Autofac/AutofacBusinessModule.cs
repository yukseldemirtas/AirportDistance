using AirportDistance_WebAPI.Models;
using AirportDistance_WebAPI.Services.Abstract;
using AirportDistance_WebAPI.Services.Concrete;
using AirportDistance_WebAPI.Services.HttpClient.Abstract;
using AirportDistance_WebAPI.Services.HttpClient.Concrete;
using AirportDistance_WebAPI.Models.Validations;
using Autofac;
using FluentValidation;

namespace AirportDistance_WebAPI.Extensions.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<AirportDistanceService>().As<IAirportDistanceService>();
			builder.RegisterType<AirportHttpClientService>().As<IAirportHttpClientService>();


		}

	}
}
