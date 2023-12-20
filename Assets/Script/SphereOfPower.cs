using UnityEngine;
using Assets.Script.BaseStateMachine;
using Assets.Script.SphereStateMachine;

public class SphereOfPower : MonoBehaviour
{
    StateMachine sphereStateMachine;
    void Start()
    {
        SphereOfPowerContext sphereContext = new SphereOfPowerContext();
        sphereStateMachine = new StateMachine(new Stocked(sphereContext));
    }

    // Update is called once per frame
    void Update()
    {


    }

    public bool Catch()
    {
        return false;
    }
}
