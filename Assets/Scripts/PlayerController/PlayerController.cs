using System;
using Board;
using DG.Tweening;
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
            player.position = GetPlayerPosition();
        }
        
        public void Move(Vector2Int move, Action onMoveEnd)
        {
            state.playerPosition += move;
            SetPosition(onMoveEnd);
        }

        private void SetPosition(Action onComplete)
        {
            var position = GetPlayerPosition();
            player.DOMove(position, .3f)
                .OnComplete(() => onComplete())
                .SetEase(Ease.OutBack);

        }

        private Vector3 GetPlayerPosition()
        {
            return new Vector3(state.playerPosition.x, 0, state.playerPosition.y) + offset;
        }
    }
}
