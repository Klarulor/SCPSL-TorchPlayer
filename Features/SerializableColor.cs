using UnityEngine;

namespace TorchPlayer.Features
{
    public class SerializableColor
    {

        public SerializableColor()
        {
            
        }
        public SerializableColor(float r, float g, float b, float w)
        {
            R = r;
            G = g;
            B = b;
            W = w;
        }

        public SerializableColor(Vector4 color): this((float)color.x, (float)color.y, (float)color.z, (float)color.w){}

        /// <summary>
        /// Red color
        /// </summary>
        public float R { get; set; } = 0;
        /// <summary>
        /// Green color
        /// </summary>
        public float G { get; set; } = 0;

        /// <summary>
        /// Blue color
        /// </summary>
        public float B { get; set; } = 0;
        
        /// <summary>
        /// Brightness color
        /// </summary>
        public float W { get; set; } = 0;
        
        public static implicit operator Color(SerializableColor a) => new Color(a.R, a.G, a.B);
        public static implicit operator Vector4(SerializableColor a) => new Vector4(a.R, a.G, a.B, a.W);
        public static explicit operator SerializableColor(Vector4 a) => new SerializableColor(a);

        public SerializableColor Normalize()
        {
            Vector4 vec = this;
            Vector4 norm = vec.normalized;
            return (SerializableColor)norm;
        }
    }
}