using DataAccessLayerTest.Context;
using DomainLayer;
using System;
using System.Threading;

namespace DataAccessLayerTest;

public partial class ObjectMother : IDisposable
{
    public ObjectMother()
    {
        Thread.Sleep(100);

        ContextDB = DbContextForTests.CreerContext();

        ContextDB.Database.BeginTransaction();
    }

    protected AppSolutionDBContext ContextDB { get; private set; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        ContextDB.Database.RollbackTransaction();
    }
}
