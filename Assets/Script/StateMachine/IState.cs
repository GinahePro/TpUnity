using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.BaseStateMachine
{
    public interface IState : IUpdatable
    {
        public StateMachine StateMachine { get; set; }
        public void OnEnter();
        public void OnLeave();
    }
}
