namespace Demo.DefaultInterfaceMembers
{
    public abstract class Enemy : Entity
    {
        private readonly Animator animator;
        protected abstract Animation DeathAnimation { get; }

        protected Enemy(Animator animator)
        {
            this.animator = animator;
        }

        public virtual void Destroy()
        {
            animator.Play(this, DeathAnimation);
        }
    }
}
