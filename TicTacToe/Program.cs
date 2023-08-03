using ConsoleManager;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IConsoleManager, ConsoleManager.ConsoleManager>()
    .AddSingleton<IConsoleUI, ConsoleUI>()
    .AddSingleton<IGame, Game>()
    .AddSingleton<IRandomNumberGenerator, RandomNumberGenerator>()
    .BuildServiceProvider();

var consoleUI = serviceProvider.GetService<IConsoleUI>();

consoleUI?.Run(args);

