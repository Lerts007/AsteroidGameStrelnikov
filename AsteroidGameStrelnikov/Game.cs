using AsteroidGameStrelnikov.VisualObjects;
using AsteroidGameStrelnikov.VIsualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGameStrelnikov
{
    static class Game
    {
        private static BufferedGraphicsContext __Cotext;

        private static BufferedGraphics __Buffer;

        private static ImageObject[] __GameObjects;

        

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

            Random r = new Random();

            var game_objects = new List<ImageObject>();

            for (int i = 0; i < 15; i++)
            {
                game_objects.Add(new Asteroid(
                    new Point(r.Next(0, Width - 50), r.Next(0, Height - 75)),
                    new Point(r.Next(1, 20), r.Next(1, 20)),
                    40));
            }

            for (int i = 1; i < 16; i++)
            {
                game_objects.Add(new Star(
                    new Point(r.Next(0, Width - 50), r.Next(0, Height - 75)),
                    new Point(i, 0),
                    40));
            }

            for (int i = 1; i < 16; i++)
            {
                game_objects.Add(new Bullet(
                    new Point(r.Next(0, Width - 50), r.Next(0, Height - 75)),
                    new Point(i, 0),
                    40));
            }

            __GameObjects = game_objects.ToArray();
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
