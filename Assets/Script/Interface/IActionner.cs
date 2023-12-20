
namespace Interface
{
    public interface IActionner
    {
        public bool State {  get; }
        public delegate void StateUpdate();
        public event StateUpdate OnStateUpdate;
    }
}
