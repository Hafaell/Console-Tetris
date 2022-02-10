namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new StartGame();
            game.Start();
            game.Update();
        }       
    }

}
