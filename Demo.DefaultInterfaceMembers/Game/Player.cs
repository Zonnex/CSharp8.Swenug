namespace Demo.DefaultInterfaceMembers
{
    public class Player : Entity
    {
        private Animator animator;

        public Animator GetAnimator()
        {
            return animator;
        }

        public Entity GetEntity()
        {
            return this;
        }
    }
}
