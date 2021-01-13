using System;
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

            Timer timer = new Timer { Interval = 100 };

            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Load()
        {
            const int visual_objects_count = 30;
            __GameObjects = new VizualObject[visual_objects_count];

            Random r = new Random();


            for (int i = 0; i < __GameObjects.Length / 2; i++)
            {
                __GameObjects[i] = new VizualObject(
                    new Point(r.Next(0, Width - 50), r.Next(0, Height - 75)),
                    new Point(r.Next(1, 20), r.Next(1, 20)),
                    new Size(r.Next(20, 40), r.Next(20, 40)));
            }
            for (int i = __GameObjects.Length / 2; i < __GameObjects.Length; i++)
            {
                __GameObjects[i] = new Star(
                    new Point(r.Next(0, Width - 50), r.Next(0, Height - 50)),
                    new Point(i, 0),
                    40);
            }
        }

        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;

            g.Clear(Color.Black);

            foreach (var game_object in __GameObjects)
                game_object.Draw(g);

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
