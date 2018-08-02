using System;
using System.Collections.Generic;
using System.Linq;
using Improbable.Gdk.Core.MonoBehaviours;
using Unity.Entities;
using UnityEngine;

namespace Improbable.Gdk.Core
{
    public class ReaderWriterFactory
    {
        private const string ComponentIdAttributeNotFoundError
            = "ReaderWriterCreator found with no Component ID attribute.";
        private const string NoReaderWriterCreatorFoundForComponentIdError
            = "No ReaderWriterCreator found for given ComponentId.";

        private readonly EntityManager entityManager;
        private readonly ILogDispatcher logger;
        private readonly Dictionary<uint, IReaderWriterCreator> componentIdToReaderWriterCreator = new Dictionary<uint, IReaderWriterCreator>();

        public ReaderWriterFactory(EntityManager entityManager, ILogDispatcher logger)
        {
            this.entityManager = entityManager;
            this.logger = logger;

            FindReaderWriterCreators();
        }

        private void FindReaderWriterCreators()
        {
            var creatorTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(IReaderWriterCreator).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
                .ToList();

            foreach (var creatorType in creatorTypes)
            {
                var componentIdAttribute =
                    (ComponentIdAttribute)Attribute.GetCustomAttribute(creatorType, typeof(ComponentIdAttribute), false);
                if (componentIdAttribute == null)
                {
                    logger.HandleLog(LogType.Error, new LogEvent(ComponentIdAttributeNotFoundError)
                        .WithField(LoggingUtils.LoggerName, GetType())
                        .WithField("ReaderWriterCreatorType", creatorType));
                    continue;
                }
                var componentId = componentIdAttribute.Id;
                var readerWriterCreator = (IReaderWriterCreator)Activator.CreateInstance(creatorType);
                componentIdToReaderWriterCreator[componentId] = readerWriterCreator;
            }
        }

        internal IReaderInternal CreateReaderWriter(uint componentId, Entity entity)
        {
            if (!componentIdToReaderWriterCreator.ContainsKey(componentId))
            {
                logger.HandleLog(LogType.Error, new LogEvent(NoReaderWriterCreatorFoundForComponentIdError)
                    .WithField(LoggingUtils.LoggerName, GetType())
                    .WithField("ComponentId", componentId));
                return null;
            }

            return componentIdToReaderWriterCreator[componentId].CreateReaderWriter(entity, entityManager, logger);
        }
    }
}
