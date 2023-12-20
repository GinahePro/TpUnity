using UnityEngine;

namespace Assets.Script.BaseStateMachine
{
    public class StateMachine : IUpdatable
    {
        IState currentState;

        public StateMachine(IState currentState)
        {
            this.currentState = currentState;
            currentState.StateMachine = this;
            currentState.OnEnter();
        }

        public void changeState(IState state)
        {
            Debug.Log(state.ToString());
            currentState.OnLeave();
            currentState = state;
            currentState.StateMachine = this;
            currentState.OnEnter();
        }

        public void CustomUpdate()
        {
            currentState.CustomUpdate();
        }
    }
}
