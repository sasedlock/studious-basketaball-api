﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web.Http;
using CommandAndQuery.Command.CommandHandlers;
using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.DependencyInjection;
using CommandAndQuery.Domain.Models;
using MediatR;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using StructureMap;

namespace CommandAndQuery
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Configure StructureMap
            var container = new Container(cfg =>
            {
                cfg.AddRegistry<MediatorRegistry>();
            });

            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
