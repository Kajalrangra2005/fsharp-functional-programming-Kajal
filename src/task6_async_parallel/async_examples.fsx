// ====================================================================
// TASK 6 — Asynchronous & Parallel Programming
// Description:
//   Demonstrates F# async workflows and .NET Task Parallel Library (TPL)
//   using real-life examples for concurrent execution.
// ====================================================================

open System
open System.Threading.Tasks



// -------------------------------------------------------------
// 1. ASYNC WORKFLOW — Real-life Example:
//    Fetching data from 3 different servers (simulated)
// -------------------------------------------------------------

let fetchData serverName delay =
    async {
        printfn "Starting fetch from %s..." serverName
        do! Async.Sleep (delay : int)     // simulates network delay
        printfn "Completed fetch from %s!" serverName
        return $"{serverName} → Data received"
    }

// Run async tasks in parallel
let asyncJob =
    [ fetchData "Server A" 1500
      fetchData "Server B" 1000
      fetchData "Server C" 2000 ]
    |> Async.Parallel
    |> Async.RunSynchronously

printfn "\nAsync Workflow Results:"
asyncJob |> Array.iter (printfn "%s")

// DIFFERENCE:
// In Java/Python, async handling needs threads/futures manually.
// F# uses async workflows with clean syntax.



// -------------------------------------------------------------
// 2. ASYNC LET BINDINGS (more readable async code)
// -------------------------------------------------------------

let asyncExample =
    async {
        let! a = fetchData "API 1" 1200
        let! b = fetchData "API 2" 800
        return [a; b]
    }
    |> Async.RunSynchronously

printfn "\nSequential Async Example:"
asyncExample |> List.iter (printfn "%s")



// -------------------------------------------------------------
// 3. PARALLEL PROGRAMMING — Using .NET Task Parallel Library (TPL)
// -------------------------------------------------------------

// Real-life Example: Processing 5 images in parallel

let processImage id =
    printfn "Processing Image %d on thread %d" id Threading.Thread.CurrentThread.ManagedThreadId
    System.Threading.Thread.Sleep(500)
    $"Image {id} processed"

let tasks =
    [1..5]
    |> List.map (fun id -> Task.Run(fun () -> processImage id))

// Wait for all tasks
tasks
|> List.map (fun t -> t :> Task)   // upcast to Task
|> List.toArray
|> Task.WaitAll


printfn "\nParallel Processing Results:"
tasks
|> List.map (fun t -> t.Result)
|> List.iter (printfn "%s")

// DIFFERENCE:
// In Java: Executors + Future + Thread pools.
// In F#: Task.Run + Async workflows = fast + simple.



// -------------------------------------------------------------
// 4. MIXING ASYNC + TASK (common in real apps)
// -------------------------------------------------------------

let mixedTask =
    Task.Run(fun () ->
        printfn "\nStarting CPU work on background thread..."
        Threading.Thread.Sleep(700)
        999
    )

let asyncResult =
    async {
        let! x = mixedTask |> Async.AwaitTask
        return x * 2
    }
    |> Async.RunSynchronously

printfn "Mixed async + TPL result: %d" asyncResult
