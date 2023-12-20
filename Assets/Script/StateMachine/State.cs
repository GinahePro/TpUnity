using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.BaseStateMachine
{
    public abstract class State<T> : IState where T : StateContext
    {
        protected T _context;
        public StateMachine StateMachine { get; set ; }

        public State(T context)
        {
            _context = context;
        }
        public abstract void OnEnter();

        public abstract void OnLeave();

        public abstract void CustomUpdate();
    }
}
