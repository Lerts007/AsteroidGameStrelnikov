using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGameStrelnikov
{
    static class Game
    {
        private static BufferedGraphicsContext __Cotext;

        private static BufferedGraphics __Buffer;

        private static VizualObject[] __GameObjects;

        public static int Width { get; set; }

        public static int Height { get; set; }

        public static void Initialize(Form GameForm)
        {
            Width = GameForm.Width;
            Height = GameForm.Height;

            __Cotext = BufferedGraphicsManager.Current;
            Graphics g = GameForm.CreateGraphics();

            __Buffer = __Cotext.Allocate(g, new Rectangle(0, 0, Width, Height));

        }

        public static void Load()
        {
            const int visual_objects_count = 30;
            __GameObjects = new VizualObject[visual_objects_count];

            for (int i = 0; i < __GameObjects.Length; i++)
            {
                __GameObjects[i] = new VizualObject(
                    new Point(600, i * 20),
                    new Point(15 - i, 20 - i),
                    new Size(20, 20));
            }
        }

        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;

            g.Clear(Color.Black);

            foreach (var game_object in __GameObjects)
            {
                game_object.Draw(g);
            }

            __Buffer.Render();
        }

        public static void Update()
        {
            foreach (var game_object in __GameObjects)
            {
                game_object.Update();
            }
        }
    }
}
