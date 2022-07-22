namespace Daikin.DotNetLove.Tests
{
    public class ColorHexTests
    {
        [Fact]
        public void DirectWellFormatted()
        {
            var color = new General.ColorHex("0097E0");
            Assert.Equal("#0097E0", color.HexValue);
        }

        [Fact]
        public void DirectWellFormattedWithHash()
        {
            var color = new General.ColorHex("#0097E0");
            Assert.Equal("#0097E0", color.HexValue);
        }

        [Fact]
        public void DirectMalFormattedLong()
        {
            var color = new General.ColorHex("0097E01");
            Assert.Equal("#0097E0", color.HexValue);
        }

        [Fact]
        public void DirectMalFormattedShort()
        {
            var color = new General.ColorHex("0097E");
            Assert.Equal("#00097E", color.HexValue);
        }

        [Fact]
        public void DirectInvalidHexUpper()
        {
            Assert.Throws<ArgumentException>(() => new General.ColorHex("00HH55"));
        }

        [Fact]
        public void DirectInvalidHexLower()
        {
            Assert.Throws<ArgumentException>(() => new General.ColorHex("00hh55"));
        }

        [Fact]
        public void InDirectInvalidHexUpper()
        {
            Assert.Throws<ArgumentException>(() => new General.ColorHex("0", "H", "5"));
        }

        [Fact]
        public void InDirectInvalidHexLower()
        {
            Assert.Throws<ArgumentException>(() => new General.ColorHex("0", "h", "5"));
        }


        [Fact]
        public void IntegerWellFormed()
        {
            var color = new General.ColorHex(0, 151, 224);
            Assert.Equal("#0097E0", color.HexValue);
        }

        [Fact]
        public void StringWellformed()
        {
            var color = new General.ColorHex("0", "151", "224");
            Assert.NotEqual("#0097E0", color.HexValue);
        }
    }
}