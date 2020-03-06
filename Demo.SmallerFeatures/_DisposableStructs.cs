using System;
using System.Buffers;
using System.Text;

namespace Demo.SmallerFeatures
{
    // ValueUtf8Converter from corefx
    internal ref struct ValueUtf8Converter
    {
        private byte[] _arrayToReturnToPool;
        private Span<byte> _bytes;

        public ValueUtf8Converter(Span<byte> initialBuffer)
        {
            _arrayToReturnToPool = null;
            _bytes = initialBuffer;
        }

        public Span<byte> ConvertAndTerminateString(ReadOnlySpan<char> value)
        {
            int maxSize = Encoding.UTF8.GetMaxByteCount(value.Length) + 1;
            if (_bytes.Length < maxSize)
            {
                Dispose();
                _arrayToReturnToPool = ArrayPool<byte>.Shared.Rent(maxSize);
                _bytes = new Span<byte>(_arrayToReturnToPool);
            }

            // Grab the bytes and null terminate
            int byteCount = Encoding.UTF8.GetBytes(value, _bytes);
            _bytes[byteCount] = 0;
            return _bytes.Slice(0, byteCount + 1);
        }

        public void Dispose()
        {
            byte[] toReturn = _arrayToReturnToPool;
            if (toReturn != null)
            {
                _arrayToReturnToPool = null;
                ArrayPool<byte>.Shared.Return(toReturn);
            }
        }
    }

    public class _DisposableStructs
    {
        public void Sample()
        {
            using var converter = new ValueUtf8Converter();

            Span<byte> result = converter.ConvertAndTerminateString("some string here");
        }
    }
}
