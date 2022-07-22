using System.Text.RegularExpressions;

namespace Daikin.DotNetLove.General
{
    public class ColorHex
    {
        #region Fields
        private string? _hexValue;
        #endregion

        #region Properties
        public string HexValue
        {
            get => _hexValue ?? string.Empty;
            set => SetHexValue(value);
        }
        #endregion

        #region Constructors
        public ColorHex(string hexValue, bool checkValid = true)
        {
            SetHexValue(hexValue, checkValid);
        }

        public ColorHex(string r, string g, string b)
        {
            SetHexValue(r.PadLeft(2, '0'), g.PadLeft(2, '0'), b.PadLeft(2, '0'));
        }

        public ColorHex(int r, int g, int b)
        {
            if (r < 0) r = 0;
            if (r > 255) r = 255;
            if (g < 0) g = 0;
            if (g > 255) g = 255;
            if (b < 0) b = 0;
            if (b > 255) b = 255;
            SetHexValue(r.ToString("X2"), g.ToString("X2"), b.ToString("X2"));
        }
        #endregion

        #region Methods
        public void SetHexValue(string hex, bool checkValid = true)
        {
            if (hex.Length > 0 && hex.StartsWith("#")) hex = hex[1..];
            if (checkValid && !Regex.IsMatch(hex, @"^[a-fA-F0-9]+$")) throw new ArgumentException("Invalid Hex Values Passed");
            if (hex.Length > 6) hex = hex[..6];
            if (hex.Length < 6) hex = hex.PadLeft(6, '0');
            if (hex.Length > 0 && !hex.StartsWith("#")) hex = "#" + hex;
            _hexValue = hex;
        }

        public void SetHexValue(string r, string g, string b, bool checkValid = true)
        {
            SetHexValue($"{r}{g}{b}", checkValid);
        }
        #endregion
    }
}
