using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Views
{
    public class SpawnButtonView : MonoBehaviour, ISpawnButtonView
    {
        [SerializeField] private bool _buttonClicked;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClickButton);
        }

        private void OnClickButton()
        {
            _buttonClicked = true;
        }

        public bool ButtonClicked
        {
            get
            {
                bool tempValue = _buttonClicked;
                _buttonClicked = false;
                return tempValue;
            }
        }
        
    }
}