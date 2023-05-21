using UnityEngine;

namespace Garden
{
    public class PhaseController: MonoBehaviour
    {
        private Phase _currentPhase = Phase.Entering;

        private void Start()
        {
            PhaseControllerProxy.Initialize(this);
        }

        public Phase CurrentPhase()
        {
            return _currentPhase;
        }

        public void NextPhase()
        {
            switch (_currentPhase)
            {
                case Phase.Entering:
                    _currentPhase = Phase.Exploring;
                    return;
                case Phase.Exploring:
                    _currentPhase = Phase.Escaping;
                    return;
                case Phase.Escaping:
                    SceneController.LoadNext();
                    return;
            }
        }
    }
}