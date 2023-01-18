using GridWalker;
using GridWalker.Input;

var input = Console.In
    .ReadToEnd()
    .Split(',')
    .Select(int.Parse)
    .ToArray();

IInputProvider inputProvider = new IntArrayInputProvider(input);

TableWalkSimulator simulator = new(inputProvider); ;

var result = simulator.Run() ?? new(-1, -1);

Console.WriteLine($"[{result.X}, {result.Y}]");