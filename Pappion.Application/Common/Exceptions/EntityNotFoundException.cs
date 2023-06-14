namespace Pappion.Application.Common.Exceptions;

[Serializable]
public class EntityNotFoundException : Exception
{
    public string EntityName { get; init; }
    public Guid? EntityId { get; set; }

    public EntityNotFoundException(string entityName, string message) : base(message)
    {
        EntityName = entityName;
    }

    public EntityNotFoundException(string entityName) : base(BuildExceptionMessage(entityName))
    {
        EntityName = entityName;
    }

    public EntityNotFoundException(string entityName, Guid entityId) : base(BuildExceptionMessage(entityName, entityId))
    {
        EntityName = entityName;
        EntityId = entityId;
    }

    private static string BuildExceptionMessage(string entityName) => $"Entity {entityName} not found.";
    private static string BuildExceptionMessage(string entityName, Guid entityId) => $"Entity {entityName} with id: {entityId} not found.";
}