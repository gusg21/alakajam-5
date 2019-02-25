using BS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alakajam.Objects
{
    class Hook : GameObject
    {
        public Vector2 target;
        public Vector2 position;
        public float moveSpeed;
        Texture2D tex;
        Fish holding;

        public Hook(Texture2D tex, Vector2 position, float moveSpeed, Vector2 target)
        {
            this.tex = tex;
            this.position = position;
            this.target = target;
            this.moveSpeed = moveSpeed;

        }
        public Hook(Texture2D tex, Vector2 position) : this(tex, position, 0, position)
        {
        }
        public Hook(Texture2D tex, Vector2 position, float moveSpeed) : this(tex, position, moveSpeed, position)
        {
        }
        public void SetTarget(Vector2 target)
        {
            this.target = target;
        }
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(tex, position, Color.White);
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            position.X = MathHelper.Lerp(position.X, target.X, moveSpeed);
            if (holding != null)
            {
                for (int i = 0; i < Parent.children.Count; i++)
                {
                    if (Parent.children[i] is Fish)
                    {
                        holding = (Fish)Parent.children[i];
                        holding.caught = true;
                        break;
                    }
                }
            }
            else
            {
                holding.position = position;
            }
            //Console.WriteLine(position.X + " HOOK X ");
        }
    }
}
