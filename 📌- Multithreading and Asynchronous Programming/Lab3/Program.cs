internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("\tMethod Main started!");

        // Thread method #1 - creating & starting new thread 
        var thread = new Thread(DoWork);
        thread.Start();

        // Thread method #2 - running multiple tasks on different threads
        var thread1 = new Thread(() => ProcessData("Thread 1", 1000));
        var thread2 = new Thread(() => ProcessData("Thread 2", 2000));
        var thread3 = new Thread(() => ProcessData("Thread 3", 3000));
        thread1.Start();
        thread2.Start();
        thread3.Start();

        // Thread method #3 - using parameters in threads
        var thread4 = new Thread(DoWorkWithParams);
        thread4.Start("Task 1");
        var thread5 = new Thread(DoWorkWithParams);
        thread5.Start("Task 2");

        // Async–Await method #1 - using 'async' & 'await' keywords
        await DoWorkAsync();
        
        // Async–Await method #2 - execution of several tasks in different threads using asynchronous methods
        await Task.WhenAll(
            DoTasksAsync("Async Task 1", 1000),
            DoTasksAsync("Async Task 2", 2000),
            DoTasksAsync("Async Task 3", 3000)
        );
        
        // Async–Await method #3 - using asynchronous methods from the HttpClient class to receive a response from the web server
        var response = await GetResponseAsync();
        Console.WriteLine($"Response: {response}");
    }

    /* Thread methods
    Thread method #1 - New thread is created using the Thread class and started by the 'Start()' method.
    After a new thread is started, the main thread continues to execute regardless of the execution of the new thread. */
    private static void DoWork()
    {
        Console.WriteLine("Starting thread work");
        Thread.Sleep(2000);
        Console.WriteLine("Finishing thread work");
    }

    /* Thread method #2 - 3 new threads are created and started. 
    Each thread performs its task - waiting for a certain amount of time and outputting a completion message. 
    Code in the main thread can continue to execute independently of the execution of other threads. */
    private static void ProcessData(string threadName, int delay)
    {
        Console.WriteLine($"Starting processing data in {threadName}");
        Thread.Sleep(delay);
        Console.WriteLine($"Finishing processing data in {threadName}");
    }
    
    /* Thread method #3 - New thread is created and parameter (task name) - is passed using the 'Start()' method.
    The 'DoWorkWithParams()' method gets this parameter and executes the task. 
    So, parameters can be passed to threads and used to perform any tasks. */
    private static void DoWorkWithParams(object taskNameObject)
    {
        var taskName = (string)taskNameObject;
        Console.WriteLine($"Starting work in {taskName}");
        Thread.Sleep(2000);
        Console.WriteLine($"Finishing work in {taskName}");
    }

    /* Async–Await methods
    Async–Await method #1 - the async and await keywords are used to perform asynchronous operations.
    The Main method is marked async because it calls the 'DoWorkAsync()' method with the await keyword. 
    It means that program execution will not stop on the 'DoWorkAsync()' method, but will continue while the DoWorkAsync method is running.
    After the execution of the DoWorkAsync method is complete, execution will return to the Main method. */
    private static async Task DoWorkAsync()
    {
        Console.WriteLine("Starting async work");
        await Task.Delay(2000);
        Console.WriteLine("Finishing async work");
    }
    
    /* Async–Await method #2 - 'Task.WhenAll()' method is used to execute multiple tasks asynchronously and simultaneously.
    Each task is executed by the 'DoTasksAsync()' method. */
    static async Task DoTasksAsync(string taskName, int delay) {
        Console.WriteLine($"Starting work in {taskName}");
        await Task.Delay(delay);
        Console.WriteLine($"Finishing work in {taskName}");
    }
    
    /* Async–Await method #3 - HttpClient class is used to make an HTTP request to a web server.
    The GetAsync method returns an HttpResponseMessage object that we can use to get the response.
    After that, the ReadAsStringAsync method is called to get a string representation of the response. */
    static async Task<string> GetResponseAsync() {
        var client = new HttpClient();
        var response = await client.GetAsync("http://webcode.me/");
        return await response.Content.ReadAsStringAsync();
    }
}