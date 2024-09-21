using System;

/// <summary>
/// Represents errors that occur during student information system operations.
/// </summary>
public class StudentInfoSystemException : Exception
{
    public StudentInfoSystemException() { }
    public StudentInfoSystemException(string message) : base(message) { }
    public StudentInfoSystemException(string message, Exception inner) : base(message, inner) { }
}

/// <summary>
/// Represents errors that occur during validation.
/// </summary>
public class ValidationException : StudentInfoSystemException
{
    public ValidationException(string message) : base(message) { }
}

/// <summary>
/// Represents errors that occur when an entity already exists.
/// </summary>
public class EntityAlreadyExistsException : StudentInfoSystemException
{
    public EntityAlreadyExistsException(string message) : base(message) { }
}

/// <summary>
/// Represents errors that occur when an entity is not found.
/// </summary>
public class EntityNotFoundException : StudentInfoSystemException
{
    public EntityNotFoundException(string message) : base(message) { }
}