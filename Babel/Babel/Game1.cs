using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Babel
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState oldkb;
        Enum gameState;
        Enum language;
        int posInPhases = 0;
        String[] statePhases = new String[3];
        // Dictionary<string, string> English = new Dictionary<string, string>();
        Dictionary<string, string> English;
        Dictionary<string, string> Spanish;
        Dictionary<string, string> German;
        String currentLanguage = "English";
        Texture2D tempTexture;
        string[] lines;
        SpriteFont font;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            English = new Dictionary<string, string>();
            Spanish = new Dictionary<string, string>();
            German = new Dictionary<string, string>();
            // TODO: Add your initialization logic here
            lines = System.IO.File.ReadAllLines(@"Content/languagetext.txt");

             for (int x=0;x<14;x=x+5) {
            English.Add(lines[x],lines[x+1]);
            Spanish.Add(lines[x], lines[x + 2]);
            German.Add(lines[x], lines[x + 3]);
            }
            statePhases[0] = "English";
            statePhases[1] = "Spanish";
            statePhases[2] = "German";
            oldkb = Keyboard.GetState();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tempTexture = Content.Load<Texture2D>("bluesquare");
            font = Content.Load<SpriteFont>("SpriteFont1");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.D1)) {
                 currentLanguage = statePhases[0];
            }
            else if (kb.IsKeyDown(Keys.D2))
            {
                currentLanguage = statePhases[1];
            }
            else if (kb.IsKeyDown(Keys.D3))
            {
                currentLanguage = statePhases[2];
            }
            // TODO: Add your update logic here
            oldkb = kb;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            String string1 = "";
            String string2 = "";
            String string3 = "";
            switch (currentLanguage) {
                case "English":
                    string1 = English["start"];
                    string2 = English["save"];
                    string3 = English["done"];
                    break;
                case "Spanish":
                    string1 = Spanish["start"];
                    string2 = Spanish["save"];
                    string3 = Spanish["done"];
                    break;
                case "German":
                    string1 = German["start"];
                    string2 = German["save"];
                    string3 = German["done"];
                    break;
            }
            spriteBatch.DrawString(font,string1 , new Vector2(50, 20), Color.White);
            spriteBatch.DrawString(font, string2, new Vector2(50, 60), Color.White);
            spriteBatch.DrawString(font, string3, new Vector2(50, 100), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
