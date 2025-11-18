// ====================================================================
// TASK 7 — Object-Oriented Programming in F#
// Description:
//   Demonstrates classes, interfaces, inheritance, and .NET OOP
//   interoperability using simple examples.
// ====================================================================

open System



// -------------------------------------------------------------
// 1. SIMPLE CLASS — Real-life Example: Bank Account
// -------------------------------------------------------------

type BankAccount(initialBalance: float) =
    let mutable balance = initialBalance

    member this.Deposit(amount: float) =
        balance <- balance + amount

    member this.Withdraw(amount: float) =
        if amount <= balance then
            balance <- balance - amount
        else
            printfn "Insufficient funds!"

    member this.GetBalance() = balance

// Using the class
let acc = BankAccount(1000.0)
acc.Deposit(500.0)
acc.Withdraw(300.0)

printfn "Final Bank Balance = %.2f" (acc.GetBalance())



// -------------------------------------------------------------
// 2. CLASS WITH PROPERTIES — Real-life Example: Student Record
// -------------------------------------------------------------

type Student(name: string, age: int) =
    member val Name = name with get, set
    member val Age = age with get, set

    member this.Intro() =
        $"My name is {this.Name} and I am {this.Age} years old."

let s = Student("Kritika", 21)
printfn "\nStudent Intro: %s" (s.Intro())



// -------------------------------------------------------------
// 3. INTERFACE + IMPLEMENTATION — Real-life Example: Shape Area
// -------------------------------------------------------------

type IShape =
    abstract member Area: unit -> float

type Circle(radius: float) =
    interface IShape with
        member this.Area() = Math.PI * radius * radius

type Rectangle(w: float, h: float) =
    interface IShape with
        member this.Area() = w * h

let shapes : IShape list =
    [ Circle(5.0) :> IShape
      Rectangle(4.0, 6.0) :> IShape ]

printfn "\nShape Areas:"
shapes |> List.iter (fun shape -> printfn "%.2f" (shape.Area()))



// -------------------------------------------------------------
// 4. INHERITANCE — Real-life Example: Employees
// -------------------------------------------------------------

type Employee(name: string) =
    member this.Name = name
    member this.Work() =
        $"{this.Name} is working."

type Manager(name: string, teamSize: int) =
    inherit Employee(name)
    member this.TeamSize = teamSize
    member this.Manage() =
        $"{this.Name} manages a team of {this.TeamSize} people."

let e = Employee("Riya")
let m = Manager("Aryan", 10)

printfn "\nEmployee: %s" (e.Work())
printfn "Manager: %s" (m.Manage())



// -------------------------------------------------------------
// 5. .NET INTEROPERABILITY — Using .NET System Classes
// -------------------------------------------------------------

let now = DateTime.Now
printfn "\nCurrent Date & Time from .NET = %A" now

let guid = Guid.NewGuid()
printfn "Generated GUID (from .NET) = %A" guid
