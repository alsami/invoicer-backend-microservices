﻿using System;
using System.Reflection;
using Autofac;
using Invoicer.Common.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Invoicer.Common
{
    public class RepositoryModule : Autofac.Module
    {
        public Assembly ExecutingAssembly { get; set; }
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ExecutingAssembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ExecutingAssembly)
                .AsClosedTypesOf(typeof(IDbContext<>))
                .AsSelf()
                // Db context is not thread-safe. If you get more than one instance running async, you end up having task canceled exception
                .InstancePerDependency();
        }
    }
}
