using Alakajam.Input;
using Alakajam.Objects;
using BS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alakajam
{
	class Player : MotionGameObject
	{
		PlayerNumber number;
		Texture2D tex;
		Texture2D fishingRod;
		SpriteEffects rodFlip;
		Vector2 rodOffset;
        Vector2 rodCenter;
        float rodRotate = 0;
        PlayerController controller;
        Hook hook;

        public Player(PlayerNumber number, PlayerController controller, ContentManager content) : base()
		{
			this.number = number;
            this.controller = controller;

			if (number == PlayerNumber.ONE)
			{
				position = new Vector2 (1, 31);
			}
			else if (number == PlayerNumber.TWO)
			{
				position = new Vector2 (291, 31);
			}

			tex = content.Load<Texture2D> ("Images/player-" + (number == PlayerNumber.ONE ? "blue" : "green"));
			fishingRod = content.Load<Texture2D> ("Images/fishing-rod");
			rodFlip = (number == PlayerNumber.ONE ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
			rodOffset = (number == PlayerNumber.ONE ? new Vector2(23, 31) : new Vector2 (7, 31));
            rodCenter =  (number == PlayerNumber.ONE) ? new Vector2(0, 21) : new Vector2(11,21);
            hook = new Hook(GenerateTexture.Circle(tex.GraphicsDevice, Color.Red, 10), new Vector2(position.X, position.Y), .01F);
        }
		public override void Draw(SpriteBatch batch)
		{
			batch.Draw (tex, position, Color.White);
			batch.Draw (fishingRod, position + rodOffset, null, Color.White, rodRotate, rodCenter, Vector2.One, rodFlip, 0f);
            //Console.WriteLine("Mouse X " + Mouse.GetState().X, " Mouse Y " + Mouse.GetState().Y);
            hook.Draw(batch);
			base.Draw (batch);
		}

        public override void Update(GameTime gameTime)
        {
            controller.Update(gameTime);
            MouseState mouse = Mouse.GetState();
            rodRotate = (float)Math.Atan((position.Y - mouse.Y) / (position.X - mouse.X));
            if (controller.fireButton.Pressed())
            {
                Console.WriteLine("test");
                hook.SetTarget(new Vector2(mouse.X, mouse.Y));
            }
            hook.Update(gameTime);
        }
	}

	enum PlayerNumber
	{
		ONE, TWO
	}
}
