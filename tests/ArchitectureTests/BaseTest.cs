using System.Reflection;
using Application.Abstractions.Messaging;
using Domain.Entities.Users;
using Infrastructure.Database;
using Web.Api;

namespace ArchitectureTests;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1515:Consider making the type internal", Justification = "Required to be public for xUnit tests")]
public abstract class BaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(User).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(ICommand).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;
    protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
}
