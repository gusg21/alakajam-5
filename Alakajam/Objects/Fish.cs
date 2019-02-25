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
    class Fish : MotionGameObject
    {
        public enum FishType
        {
            FIRE,
            WATER,
            AIR,
            EARTH
        }
        public enum Direction
        {
            LEFT = -1,
            RIGHT = 1
        }

        public Dictionary<FishType, float> baseSpeeds = new Dictionary<FishType, float>()
        {
            { FishType.WATER, 1F },
            { FishType.FIRE, 1.5F },
            { FishType.AIR, 3F },
            { FishType.EARTH, .5F }
        };
        public FishType type;
        public Direction direction;
        public bool caught { get; set; } = false;
        Texture2D tex;

        public Fish(FishType type, Direction direction, ContentManager content)
        {
            this.type = type;
            this.direction = direction;
            if(type == FishType.FIRE)
            {
                tex = content.Load<Texture2D>("Images/fireFish");
            }
            else if (type == FishType.WATER)
            {
                tex = content.Load<Texture2D>("Images/waterFish");
            }
            else if (type == FishType.AIR)
            {
                tex = content.Load<Texture2D>("Images/airFish");
            }
            else if (type == FishType.EARTH)
            {
                tex = content.Load<Texture2D>("Images/earthFish");
            }
            velocity.X = baseSpeeds[type] * (int)direction;

    }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(tex, position, Color.White);
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
    }
}
