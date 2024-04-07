using System.Collections.Generic;
using CGVA.Analysis;

namespace BarelyFunctionnal.Analysis
{
    public class ClosureTree
    {
        public Closure Closure { get; }
        public ClosureTree? Parent { get; }
        public List<ClosureTree?> Children { get; } = new();

        public ClosureTree(Closure closure)
        {
            Closure = closure;
        }

        private ClosureTree(ClosureTree parent, Closure closure)
        {
            Parent = parent;
            Closure = closure;
        }

        public ClosureTree AddChild(Closure closure)
        {
            var child = new ClosureTree(this, closure);
            Children.Add(child);
            return child;
        }

        public IEnumerable<ClosureTree> GetSameClosureParents()
        {
            var current = Parent;
            while (current is not null)
            {
                if (current.Closure == Closure)
                    yield return current;
                current = current.Parent;
            }
        }

        public bool HasExtendedParentLoop()
        {
            foreach (var parent in GetSameClosureParents())
                foreach (var grandParent in parent.GetSameClosureParents())
                    if (HasExtendedParentLoop(grandParent, parent, grandParent, parent, this))
                        return true;
            return false;
        }

        public static bool HasExtendedParentLoop(ClosureTree grandParent, ClosureTree parent, ClosureTree stop0, ClosureTree stop1, ClosureTree stop2)
        {
            if (grandParent.Closure.Function == parent.Closure.Function)
            {
                if (grandParent == stop1 || parent == stop2)
                    return grandParent == stop1 && parent == stop2;

                for (var i = 0; i < grandParent.Children.Count; i++)
                {
                    var path1 = grandParent.Children[i];
                    var path2 = parent.Children[i];

                    if (path1 is not null && path2 is not null)
                        if (!HasExtendedParentLoop(path1, path2, stop0, stop1, stop2))
                            return false;
                }

                return true;
            }
            else
            {
                if (grandParent == stop0 || grandParent.Parent is null)
                    return false;

                return HasExtendedParentLoop(grandParent.Parent, parent, stop0, stop1, stop2);
            }
        }
    }
}
