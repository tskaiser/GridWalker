namespace GridWalker.Input
{
    public class IntArrayInputProvider : IInputProvider
    {
        private readonly int[] _input;

        public IntArrayInputProvider(int[] input) {
            _input = input.ToArray();
        }

        public IEnumerable<Command> GetCommands() => _input
            .Skip(4) // Skip header
            .Select(x => (Command)x);

        public Header GetHeader()
        {
            if (_input.Length < 4)
                throw new InvalidOperationException(
                    $"header requires 4 inputs (width, height, start x, start y) but input length is {_input.Length}.");

            var width = _input[0];
            if (width < 1)
                throw new InvalidOperationException($"table width must be greater than zero, but was {width}.");

            var height = _input[1];
            if (height < 1)
                throw new InvalidOperationException($"table height must be greater than zero, but was {height}.");

            var startX = _input[2];
            if (startX < 0)
                throw new InvalidOperationException($"starting position, x, must not be negative, but was {startX}.");

            var startY = _input[3];
            if (startY < 0)
                throw new InvalidOperationException($"starting position, y, must not be negative, but was {startY}.");

            return new Header(_input[0], _input[1], new(_input[2], _input[3]));
        }
    }
}
