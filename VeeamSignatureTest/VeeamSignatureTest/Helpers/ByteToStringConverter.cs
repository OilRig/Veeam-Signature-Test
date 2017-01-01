namespace VeeamSignatureTest.Helpers
{
    public static class ByteToStringConverter
    {
        public static string BytesToString(byte[] input)
        {
            var buffer = string.Empty;
            foreach (var item in input)
            {
                buffer += item.ToString();
            }
            return buffer;
        }


    }
}
