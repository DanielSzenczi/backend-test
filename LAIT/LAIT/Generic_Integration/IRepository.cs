using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAIT.Generic_Integration
{
    public interface IRepository<Entity>
    {
        public Task<Entity> Get(string id);
        public IEnumerable<Entity> List();
        public Task<string> Create(Entity entity);
        public Task<string> Delete(string id);
        public Task<string> Update(Entity entity);

    }
}
