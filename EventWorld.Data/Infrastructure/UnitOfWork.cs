using EventWorld.Data.Context;

namespace EventWorld.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventWorldDataContext context;

        public UnitOfWork(EventWorldDataContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
