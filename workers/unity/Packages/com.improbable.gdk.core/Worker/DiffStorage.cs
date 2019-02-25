using System;
using System.Collections.Generic;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Gdk.Core
{
    public interface IComponentDiffStorage
    {
        Type[] GetEventTypes();
        Type GetUpdateType();
        uint GetComponentId();

        void Clear();
        void RemoveEntityComponent(long entityId);

        List<EntityId> GetComponentsAdded();
        List<EntityId> GetComponentsRemoved();
    }

    public interface ICommandDiffStorage
    {
        uint GetComponentId();
        uint GetCommandId();

        Type GetRequestType();
        Type GetResponseType();

        void Clear();
        void RemoveRequests(long entityId);
    }

    public interface IDiffComponentAddedStorage<T> where T : ISpatialComponentUpdate
    {
        void AddEntityComponent(long entityId, T component);
    }

    public interface IDiffAuthorityStorage : IComponentDiffStorage
    {
        void AddAuthorityChange(AuthorityChangeReceived authorityChange);
        ReceivedMessagesSpan<AuthorityChangeReceived> GetAuthorityChanges();
        ReceivedMessagesSpan<AuthorityChangeReceived> GetAuthorityChanges(EntityId entityId);
    }

    public interface IDiffUpdateStorage<T> : IComponentDiffStorage
        where T : ISpatialComponentUpdate
    {
        void AddUpdate(ComponentUpdateReceived<T> update);
        ReceivedMessagesSpan<ComponentUpdateReceived<T>> GetUpdates();
        ReceivedMessagesSpan<ComponentUpdateReceived<T>> GetUpdates(EntityId entityId);
    }

    public interface IDiffEventStorage<T> : IComponentDiffStorage
        where T : IEvent
    {
        void AddEvent(ComponentEventReceived<T> ev);
        ReceivedMessagesSpan<ComponentEventReceived<T>> GetEvents();
        ReceivedMessagesSpan<ComponentEventReceived<T>> GetEvents(EntityId entityId);
    }

    public interface IDiffCommandRequestStorage<T> : ICommandDiffStorage
        where T : struct, IReceivedCommandRequest
    {
        void AddRequest(T request);
        ReceivedMessagesSpan<T> GetRequests();
    }

    public interface IDiffCommandResponseStorage<T> : ICommandDiffStorage
        where T : struct, IReceivedCommandResponse
    {
        void AddResponse(T response);
        ReceivedMessagesSpan<T> GetResponses();
    }
}
