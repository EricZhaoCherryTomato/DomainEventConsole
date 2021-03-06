﻿using Autofac;

namespace DomainEventConsoleApp
{
    public class EventModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppointmentCreatedEvent>()
                .As<IEvent>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AppointmentHanlder>()
                .As<IEventHandles<AppointmentCreatedEvent>>()
                .InstancePerLifetimeScope();
        }
    }
}