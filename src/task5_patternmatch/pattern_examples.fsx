// ====================================================================
// TASK 5 — Pattern Matching
// Description:
//   Demonstrates pattern matching using tuples, records,
//   and discriminated unions with real-life examples.
// ====================================================================



// -------------------------------------------------------------
// 1. PATTERN MATCHING WITH TUPLES
// -------------------------------------------------------------
// Real-life Example: Determine ticket price based on (age, isStudent)

let getTicketPrice (age, isStudent) =
    match (age, isStudent) with
    | age, true when age < 18 -> 50
    | age, true -> 80
    | age, false when age < 18 -> 70
    | _ -> 120

printfn "Ticket price (15, student) = %d" (getTicketPrice (15, true))
printfn "Ticket price (25, student) = %d" (getTicketPrice (25, true))
printfn "Ticket price (10, non-student) = %d" (getTicketPrice (10, false))
printfn "Ticket price (30, non-student) = %d" (getTicketPrice (30, false))

// DIFFERENCE:
// In C/Java, you'd need nested if-else.
// F# matches directly on tuple values = cleaner and safer.



// -------------------------------------------------------------
// 2. PATTERN MATCHING WITH RECORDS
// -------------------------------------------------------------

type Student =
    { Name: string
      Marks: int }

let evaluateStudent student =
    match student with
    | { Marks = m } when m >= 90 -> $"{student.Name} → Excellent"
    | { Marks = m } when m >= 75 -> $"{student.Name} → Good"
    | { Marks = m } when m >= 50 -> $"{student.Name} → Average"
    | _ -> $"{student.Name} → Needs Improvement"

let s1 = { Name = "Kritika"; Marks = 92 }
let s2 = { Name = "Aryan"; Marks = 78 }
let s3 = { Name = "Riya"; Marks = 45 }

printfn "\nRecord Pattern Matching:"
printfn "%s" (evaluateStudent s1)
printfn "%s" (evaluateStudent s2)
printfn "%s" (evaluateStudent s3)

// DIFFERENCE:
// Destructuring records during match is unique to F#.
// Java needs getters, Python needs dictionary access.



// -------------------------------------------------------------
// 3. DISCRIMINATED UNIONS — Real-life Example: Payment Methods
// -------------------------------------------------------------

type PaymentMethod =
    | Cash
    | CreditCard of cardNumber: string
    | UPI of upiId: string
    | Wallet of provider: string * balance: float

let processPayment method =
    match method with
    | Cash ->
        "Paid using Cash."

    | CreditCard number ->
        $"Paid using Credit Card ending with {number.Substring(number.Length - 4)}."

    | UPI upi ->
        $"Paid through UPI ID: {upi}"

    | Wallet (provider, balance) when balance >= 100.0 ->
        $"Paid via {provider} Wallet (Balance OK)."

    | Wallet (provider, _) ->
        $"{provider} Wallet → Insufficient balance!"

printfn "\nDiscriminated Union Examples:"
printfn "%s" (processPayment Cash)
printfn "%s" (processPayment (CreditCard "1234567812345678"))
printfn "%s" (processPayment (UPI "kritika@upi"))
printfn "%s" (processPayment (Wallet ("Paytm", 150.0)))
printfn "%s" (processPayment (Wallet ("PhonePe", 50.0)))

// DIFFERENCE:
// Discriminated Unions = F# superpower.
// Equivalent in Java/C = many classes + switch + instanceof + boilerplate.


