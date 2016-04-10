using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class UnitOfWorkFactory
    {
        private ISession _session;

        [ImportingConstructor]
        public UnitOfWorkFactory(ISession session)
        {
            _session = session;
        }

        public UnitOfWork Create<TContext>() where TContext : IDbContext
        {
            var dbContext =(IDbContext)Activator.CreateInstance(typeof(TContext),_session.WorkingDirectory);

            var uow = new UnitOfWork(dbContext);

            return uow;
        }
    }
}
