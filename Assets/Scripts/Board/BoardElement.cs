using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Board
{
    public class BoardElement : MonoBehaviour
    {
        private static Vector3 offset = new Vector3(.5f, 0, .5f);
        
        public TextMeshProUGUI number;
        public Material doneMaterial;
        public MeshRenderer meshRenderer;

        private IBoardElementState state;

        public void Setup(IBoardElementState state)
        {
            this.state = state;
            state.OnStateNumberChanged += OnNumberChanged;
            UpdateUI();
            SetPosition();
        }

        private void OnDestroy()
        {
            state.OnStateNumberChanged -= OnNumberChanged;
        }

        private void OnNumberChanged()
        {
            UpdateUI();
            UpdateMaterial();
        }

        private void UpdateUI()
        {
            number.text = state.Number.ToString();
        }

        private void UpdateMaterial()
        {
            if(state.Number != 0)
                return;

            meshRenderer.material = doneMaterial;
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
