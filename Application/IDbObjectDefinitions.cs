using gitqool.Application;

public interface IDbObjectDefinitionsRepository : IRepository<DbObjectDefinitions>
{
    
}

public interface IUnitOfWork
{
    IDbObjectDefinitionsRepository DbObjectDefinitions { get; }
}