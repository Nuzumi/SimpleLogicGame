using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Board
{
    public interface IBoardElementState
    {
        event Action OnStateNumberChanged;
        int Number { get; }
        Vector3 Position { get; }
    }
    
    public class BoardElementState : IBoardElementState
    {
        public event Action OnStateNumberChanged;
        
        [JsonIgnore]
        public int Number
        {
            get => number;
            set
            {
                number = value;
                OnStateNumberChanged?.Invoke();
            }
        }
        
        public Vector3 Position { get; set; }

        [JsonProperty]
        private int number;
    }
}