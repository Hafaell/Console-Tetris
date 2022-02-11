
namespace Tetris.HUD
{
    class UI
    {
        public Grid grid;

        public static UI instance;

        private UI()
        {
            grid = new Grid(10, 20, 5, 5);
        }

        public static Grid GetGrid()
        {
            return instance.grid;
        }

        public static UI GetInstance()
        {
            if (instance == null)
            {
                instance = new UI();
            }

            return instance;
        }
    }
}
