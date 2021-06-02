using TMPro;
using UnityEngine;

namespace Board
{
    public class BoardElement : MonoBehaviour
    {
        private static Vector3 offset = new Vector3(.5f, 0, .5f);
        private static Vector3 positionModifier = new Vector3(1, 1, -1);
        
        public TextMeshProUGUI number;

        private IBoardElementState state;

        public void Setup(IBoardElementState state)
        {
            this.state = state;
            state.OnStateNumberChanged += UpdateUI;
            UpdateUI();
            SetPosition();
        }

        private void OnDestroy()
        {
            state.OnStateNumberChanged -= UpdateUI;
        }

        private void UpdateUI()
        {
            number.text = state.Number.ToString();
        }

        private void SetPosition()
        {
            Vector3 position = new Vector3(state.Position.z, state.Position.y, state.Position.x);
            transform.position = position + offset;
        }

        public void Destroy()
        {
            Destroy(this);
        }
    }
}
