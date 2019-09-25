namespace Demo.DefaultInterfaceMembers
{
    public interface IDestroyable
    {
        Entity GetEntity();
        Animator GetAnimator();

        public void Destroy()
        {
            Animator animator = GetAnimator();
            animator.Play(GetEntity(), Defaults.Animations.Death);
        }
    }
}
