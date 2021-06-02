using Board;
using UnityEngine;

namespace PlayerController
{
    public class PlayerController
    {
        private static Vector3 offset = new Vector3(.5f, 0, .5f);

        private BoardState state;
        private Transform player;
        
        public void Setup(BoardState state)
        {
            this.state = state;
            player = SceneElements.Instance.player;
            SetPosition();
        }
        
        public void Move(Vector2Int move)
        {
            state.playerPosition += move;
            SetPosition();
        }

        private void SetPosition()
        {
            player.position = new Vector3(state.playerPosition.x, 0, state.playerPosition.y) + offset;
        }
    }
}
