using System;
using System.Threading.Tasks;

public class ParallelUtils<T, TR>
{
    private readonly Func<T, T, TR> _operation;
    private readonly T _operand1;
    private readonly T _operand2;
    private Task<TR> _task;

    public TR Result { get; private set; }

    public ParallelUtils(Func<T, T, TR> operation, T operand1, T operand2)
    {
        _operation = operation ?? throw new ArgumentNullException(nameof(operation));
        _operand1 = operand1;
        _operand2 = operand2;
    }

    public void StartEvaluation()
    {
        _task = Task.Run(() => _operation(_operand1, _operand2));
    }

    public void Evaluate()
    {
        if (_task == null)
        {
            StartEvaluation();
        }
        Result = _task.Result; // This will block the calling thread until the task is complete.
    }
}

// Приклад використання
class Program
{
    static void Main()
    {
        // Приклад функції, яка додає два числа
        Func<int, int, int> addFunction = (x, y) => x + y;

        // Створення об'єкта ParallelUtils
        var parallelUtils = new ParallelUtils<int, int>(addFunction, 3, 4);

        // Запуск обчислення у паралельному потоці
        parallelUtils.StartEvaluation();

        // Очікування завершення обчислення і отримання результату
        parallelUtils.Evaluate();

        // Вивід результату
        Console.WriteLine(parallelUtils.Result); // Виведе 7
    }
}
