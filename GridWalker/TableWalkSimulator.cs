using GridWalker.Entities;
using GridWalker.Geometry;
using GridWalker.Input;

namespace GridWalker
{
    public class TableWalkSimulator
    {
        private IInputProvider _inputProvider;

        public TableWalkSimulator(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        /// <summary>
        /// Runs a simulation of a walker moving across a table.
        /// </summary>
        /// <returns>The position of the walker at the end of the simulation,
        /// or null if the walker fell off the table.</returns>
        /// <exception cref="NotImplementedException">Thrown if a command is not recognized.</exception>
        /// <exception cref="InvalidOperationException">Thrown if a Quit command is not provided before the end of input.</exception>
        public Point? Run()
        {
            var header = _inputProvider.GetHeader();

            Table table = new(header.TableWidth, header.TableHeight);
            Walker walker = new(header.StartingPosition);

            var fallenOffTheTable = false;
            foreach (var command in _inputProvider.GetCommands())
            {
                if (!(fallenOffTheTable || table.IsOnTable(walker)))
                    fallenOffTheTable = true;

                /* Even if we fell off the table we still continue executing commands,
                 * moving around the walker (and potentially getting back on the table),
                 * but once we've fallen off the table once the end result will always be null to indicate this.
                 * 
                 * We could exit early, or stop moving the walker, but neither behavior is explicitly specified.
                 * The input provider might expect us to exhaust the commands enumerable until we reach the command to quit.
                 */
                switch (command)
                {
                    case Command.Quit:
                        return fallenOffTheTable ? null : walker.Position;
                    case Command.MoveForward:
                        walker.MoveForward();
                        break;
                    case Command.MoveBackward:
                        walker.MoveBackward();
                        break;
                    case Command.RotateLeft:
                        walker.TurnLeft();
                        break;
                    case Command.RotateRight:
                        walker.TurnRight();
                        break;
                    default:
                        throw new NotImplementedException("unknown command");
                }
            }

            throw new InvalidOperationException("input ended before reaching a Quit command");
        }
    }
}
