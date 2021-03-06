﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using MediatR;
using StructureMap;

namespace CommandAndQuery.DependencyInjection
{
    public class MediatorRegistry : Registry
    {
        public MediatorRegistry()
        {
            var assemblies = new[]
            {
                "CommandAndQuery.Command",
                "CommandAndQuery.Query",
                "CommandAndQuery"
            };
            
            Scan(scanner =>
            {
                foreach (var assembly in assemblies)
                {
                    scanner.Assembly(assembly);
                }
                scanner.AssemblyContainingType<IMediator>();
                
                scanner.WithDefaultConventions();
                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
            });
            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
        }
    }
}