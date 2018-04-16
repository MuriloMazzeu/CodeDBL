using Mazzsoft.CodeDBL.Core.Shared.Attributes;

namespace Mazzsoft.CodeDBL.Core.Shared.Bases
{
    public class Entity
    {
        public bool WasMapped { get; private set; }

        public Entity()
        {
            WasMapped = GetType().IsDefined(typeof(TableAttribute), false);
        }
    }
}
