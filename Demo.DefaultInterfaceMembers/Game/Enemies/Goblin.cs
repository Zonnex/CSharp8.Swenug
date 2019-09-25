using System;

namespace Demo.DefaultInterfaceMembers
{
    public class Goblin : Enemy
    {
        public Goblin(Animator animator) : base(animator)
        {
        }

        protected override Animation DeathAnimation => throw new NotImplementedException();
    }
}
