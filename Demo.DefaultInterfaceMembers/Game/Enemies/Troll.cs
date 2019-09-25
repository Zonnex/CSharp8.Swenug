using System;

namespace Demo.DefaultInterfaceMembers
{
    public class Troll : Enemy
    {
        public Troll(Animator animator) : base(animator)
        {
        }

        protected override Animation DeathAnimation => throw new NotImplementedException();
    }
}
