using System;
using Xamarin.Forms;

namespace PakaPakaCalc.Views
{
    public class Style
    {
        private static readonly double _baseScreenWidth = 320d;

        private static Func<double> ratio = () => { return _screenWidth / _baseScreenWidth; };

        public const double _marginMid = 20d;
        public const double _marginSmall = 10d;

        public const double _fontSizeBiggest = 100d;
        public const double _fontSizeBig = 50d;
        public const double _fontSizeLarge = 30d;
        public const double _fontSizeMid = 20d;

        public static double MarginMid       { get { return _marginMid   * ratio(); } }
        public static double MarginSmall     { get { return _marginSmall * ratio(); } }
        public static double FontSizeBiggest { get { return _fontSizeBiggest * ratio(); } }
        public static double FontSizeBig     { get { return _fontSizeBig * ratio(); } }
        public static double FontSizeLarge   { get { return _fontSizeLarge * ratio(); } }
        public static double FontSizeMid     { get { return _fontSizeMid * ratio(); } }

        private static double _screenWidth;
        public static void Init(double screenWidth)
        {
            _screenWidth = screenWidth;
        }
    }
}

