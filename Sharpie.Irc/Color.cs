using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpie.Irc
{
    public class Color
    {
        public string Code { get; set; }

        private Color(String code)
        {
            this.Code = code;
        }

        public static readonly Color White = new Color("00");
        public static readonly Color Black = new Color("01");
        public static readonly Color Blue = new Color("02");
        public static readonly Color Green = new Color("03");
        public static readonly Color Red = new Color("04");
        public static readonly Color Brown = new Color("05");
        public static readonly Color Purple = new Color("06");
        public static readonly Color Orange = new Color("07");
        public static readonly Color Yellow = new Color("08");
        public static readonly Color LightGreen = new Color("09");
        public static readonly Color Cyan = new Color("10");
        public static readonly Color LightCyan = new Color("11");
        public static readonly Color LightBlue = new Color("12");
        public static readonly Color Pink = new Color("13");
        public static readonly Color Grey = new Color("14");
        public static readonly Color LightGrey = new Color("15");

        public String WithWhiteBackground { get { return this + "," + Color.White.Code; } }
        public String WithBlackBackground { get { return this + "," + Color.Black.Code; } }
        public String WithBlueBackground { get { return this + "," + Color.Blue.Code; } }
        public String WithGreenBackground { get { return this + "," + Color.Green.Code; } }
        public String WithRedBackground { get { return this + "," + Color.Red.Code; } }
        public String WithBrownBackground { get { return this + "," + Color.Brown.Code; } }
        public String WithPurpleBackground { get { return this + "," + Color.Purple.Code; } }
        public String WithOrangeBackground { get { return this + "," + Color.Orange.Code; } }
        public String WithYellowBackground { get { return this + "," + Color.Yellow.Code; } }
        public String WithLightGreenBackground { get { return this + "," + Color.LightGreen.Code; } }
        public String WithCyanBackground { get { return this + "," + Color.Cyan.Code; } }
        public String WithLightCyanBackground { get { return this + "," + Color.LightCyan.Code; } }
        public String WithLightBlueBackground { get { return this + "," + Color.LightBlue.Code; } }
        public String WithPinkBackground { get { return this + "," + Color.Pink.Code; } }
        public String WithGreyBackground { get { return this + "," + Color.Grey.Code; } }
        public String WithLightGreyBackground { get { return this + "," + Color.LightGrey.Code; } }

        public override string ToString()
        {
            return "\x03" + Code;
        }

    }
}
