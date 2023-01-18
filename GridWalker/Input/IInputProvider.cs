namespace GridWalker.Input
{
    public interface IInputProvider
    {
        /// <summary>
        /// Gets the header from the input.
        /// </summary>
        /// <returns>The header.</returns>
        Header GetHeader();

        /// <summary>
        /// Gets the commands from the input as an IEnumerable.
        /// </summary>
        /// <returns>The commands.</returns>
        IEnumerable<Command> GetCommands();
    }
}
