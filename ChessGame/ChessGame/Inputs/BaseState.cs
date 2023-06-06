using System;

namespace ChessGame.Inputs
{
    public abstract class BaseState
    {
        public static InputHandler InputHandler;
        
        public BaseState(InputHandler inputHandler)
        {
            InputHandler = inputHandler;
        }
        public abstract void Enter();
        public abstract void Update(Tuple<int, int> position, Player currentPlayer);
        public abstract void Exit();
    }
}