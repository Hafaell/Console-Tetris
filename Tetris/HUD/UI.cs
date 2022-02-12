
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

            grid = new Grid(10, 20, 0 + offSetX, 0 + offSetY);
        }

        public static Grid GetGrid()
        {
            return instance.grid;
        }

        public static UI GetInstance()
        {
            if (instance == null)
            {
                instance = new UI(0, 0);
            }

            return instance;
        }
    }
}
