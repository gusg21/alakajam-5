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
        float rodRotate = 0;
		float rodAngleOffset = 0;

        PlayerController controller;
		BreaddedCamera camera;

        Hook hook;

		public Player(PlayerNumber number, PlayerController controller, ContentManager content, BreaddedCamera camera) : base()
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
            hook = new Hook(GenerateTexture.Circle(tex.GraphicsDevice, Color.Red, 10), new Vector2(position.X, position.Y), .01F);
			rodAngleOffset = (number == PlayerNumber.ONE) ? -25 : 25;
			this.camera = camera;
		}

		public Vector2 GetRodBasePosition()
		{
			float xOffset = (number == PlayerNumber.ONE ? 0 : fishingRod.Width);
			Vector2 val = position + rodOffset + new Vector2 (xOffset, fishingRod.Height);
			Console.WriteLine (val);
			return val;
		}

		public Vector2 GetRelativeRodBasePosition()
		{
			float xOffset = (number == PlayerNumber.ONE ? 0 : fishingRod.Width);
			Vector2 val = new Vector2 (xOffset, fishingRod.Height);
			Console.WriteLine (val);
			return val;
		}

		public override void Draw(SpriteBatch batch)
		{
			batch.Draw (tex, position, Color.White);
			batch.Draw (fishingRod, position + rodOffset, null, Color.White, rodRotate, GetRelativeRodBasePosition(), Vector2.One, rodFlip, 0f);
            //Console.WriteLine("Mouse X " + Mouse.GetState().X, " Mouse Y " + Mouse.GetState().Y);
            hook.Draw(batch);
			base.Draw (batch);
		}

        public override void Update(GameTime gameTime)
        {
			Vector2 mousePos = camera.MouseToWorld(Mouse.GetState());
			Vector2 rodBase = GetRodBasePosition();

			if ((number == PlayerNumber.ONE && mousePos.X > rodBase.X) || (number == PlayerNumber.TWO && mousePos.X < rodBase.X))
				rodRotate = (float) Math.Atan ((rodBase.Y - mousePos.Y) / (rodBase.X - mousePos.X)) + rodAngleOffset;


			controller.Update(gameTime);
            if (controller.fireButton.Pressed())
            {
                Console.WriteLine("test");
                hook.SetTarget(new Vector2(mousePos.X, mousePos.Y));
            }

            hook.Update(gameTime);
        }
	}

	enum PlayerNumber
	{
		ONE, TWO
	}
}
