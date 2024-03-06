using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Feature
    {
        public bool isResolved;

        public Feature(bool isResolved)
        {
            this.isResolved = isResolved;
        }

        public abstract void Resolve(List<Entity> allies);
    }
}
