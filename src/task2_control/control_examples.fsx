// ====================================================================
// TASK 2 — Control Flow in F#
// Description:
//   Demonstration of decision-making (if, match) and looping constructs
//   (for, while) with simple, real-life examples.
// ====================================================================



// -------------------------------------------------------------
// 1. IF / ELIF / ELSE — Real-life Example: Age Category Checker
// -------------------------------------------------------------

let age = 17

let ageCategory =
    if age < 13 then
        "Child"
    elif age < 18 then
        "Teenager"
    elif age < 60 then
        "Adult"
    else
        "Senior Citizen"

printfn "Age = %d → Category: %s" age ageCategory

// DIFFERENCE:
// In F#, if/else is an EXPRESSION (returns a value).
// In C/Java, if/else is a STATEMENT (does not return a value).



// -------------------------------------------------------------
// 2. MATCH Expression — Real-life Example: Day of Week Message
// -------------------------------------------------------------

let dayOfWeek = 3   // 1=Mon, 2=Tue, ... 7=Sun

let message =
    match dayOfWeek with
    | 1 -> "Monday → Start of the week!"
    | 2 -> "Tuesday → Keep going!"
    | 3 -> "Wednesday → Midweek motivation!"
    | 4 -> "Thursday → Almost there!"
    | 5 -> "Friday → Weekend loading..."
    | 6 -> "Saturday → Enjoy your weekend!"
    | 7 -> "Sunday → Relax and recharge!"
    | _ -> "Invalid day number!"

printfn "%s" message

// DIFFERENCE:
// F# 'match' is much more powerful than switch-case in C/Java.
// It supports pattern matching, guards, and returns values.



// -------------------------------------------------------------
// 3. FOR Loop — Real-life Example: Printing Grocery Items
// -------------------------------------------------------------

let groceries = [ "Milk"; "Bread"; "Eggs"; "Butter" ]

printfn "\nGrocery List:"
for item in groceries do
    printfn " - %s" item

// DIFFERENCE:
// F# loops iterate over collections in a functional style,
// whereas C/Java require index-based loops.



// -------------------------------------------------------------
// 4. FOR Loop with Range — Real-life Example: Countdown Timer
// -------------------------------------------------------------

printfn "\nCountdown:"
for i in [5 .. -1 .. 1] do
    printf "%d " i



// -------------------------------------------------------------
// 5. WHILE Loop — Real-life Example: Login Attempt Limit
// -------------------------------------------------------------

let mutable attempts = 3

printfn "\n\nLogin System Example:"
while attempts > 0 do
    printfn "Attempts remaining: %d" attempts
    attempts <- attempts - 1

printfn "Too many attempts! Account locked."

// DIFFERENCE:
// F# uses 'mutable' rarely. Loops are available,
// but recursion and list operations are preferred.

