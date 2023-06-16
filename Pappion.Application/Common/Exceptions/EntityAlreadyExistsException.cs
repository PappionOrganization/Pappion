namespace Pappion.Application.Common.Exceptions;

[Serializable]
public class EntityAlreadyExistsException : Exception
{
    public string EntityName { get; init; }

    public EntityAlreadyExistsException(string entityName, string message) : base(message)
    {
        EntityName = entityName;
    }
    public EntityAlreadyExistsException(string entityName) : base(BuildExceptionMessage(entityName))
    {
        EntityName = entityName;
    }

    private static string BuildExceptionMessage(string entityName) => $"Entity {entityName} already exists.";
}