
namespace Tetris.HUD
{
    class UI
    {
        private int X { get; }
        private int Y { get; }

        public Grid grid;

        public static UI instance;

        private UI(int offSetX, int offSetY)
        {
            X = offSetX;
            Y = offSetY;

            grid = new Grid(20, 20, 30 + offSetX, 0 + offSetY);
        }

        public static Grid GetGrid()
        {
            return instance.grid;
        }

        public static UI GetInstance()
        {
            if (instance == null)
            {
                instance = new UI(5, 5);
            }

            return instance;
        }
    }
}
