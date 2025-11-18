// ====================================================================
// TASK 1 — F# Syntax & Basics
// Description:
//   Demonstration of core F# syntax, data types, variables, operators,
//   and differences from traditional languages like C/Java/Python.
// ====================================================================


// -------------------------------------------------------------
// 1. Basic Printing Syntax 
// -------------------------------------------------------------

printfn "Hello from F#!"
printfn "F# is a functional-first language running on .NET"



// -------------------------------------------------------------
// 2. Immutable vs Mutable Variables
// -------------------------------------------------------------

// 'let' creates an immutable value (default in F#).
let x = 10
printfn "Immutable x = %d" x

// 'let mutable' allows updating the value.
let mutable counter = 1
printfn "Initial counter = %d" counter

counter <- counter + 1     // assignment uses '<-'
printfn "Updated counter = %d" counter


// DIFFERENCE: In C/Java, variables are mutable by default.  
// In F#, immutability is used to promote safer code.



// -------------------------------------------------------------
// 3. Data Types in F#
// -------------------------------------------------------------

let anInt : int = 50
let aFloat : float = 3.14
let aBool : bool = true
let aString : string = "F# is powerful!"

printfn "Int: %d" anInt
printfn "Float: %f" aFloat
printfn "Bool: %b" aBool
printfn "String: %s" aString

// Type inference: F# automatically detects the type.
let inferred = 42   // inferred as int
printfn "Inferred type value = %d" inferred



// -------------------------------------------------------------
// 4. Operators (Arithmetic, Comparison, Logical)
// -------------------------------------------------------------

let a = 20
let b = 7

let sum = a + b
let diff = a - b
let mul = a * b
let div = a / b
let modVal = a % b

printfn "\nArithmetic:"
printfn "Sum = %d" sum
printfn "Difference = %d" diff
printfn "Multiply = %d" mul
printfn "Divide = %d" div
printfn "Modulus = %d" modVal

// Comparison
printfn "\nComparison:"
printfn "a > b  = %b" (a > b)
printfn "a < b  = %b" (a < b)
printfn "a = b  = %b" (a = b)

// Logical
let isAdult = true
let hasID = false

printfn "\nLogical:"
printfn "AND  = %b" (isAdult && hasID)
printfn "OR   = %b" (isAdult || hasID)
printfn "NOT  = %b" (not isAdult)



// -------------------------------------------------------------
// 5. Simple Function Syntax
// -------------------------------------------------------------

let addNumbers n1 n2 =
    n1 + n2

printfn "\nFunction Example:"
printfn "10 + 20 = %d" (addNumbers 10 20)

// DIFFERENCE:  
// In C/Java → add(10, 20)  
// In F# → add 10 20   (no parentheses required)



// -------------------------------------------------------------
// 6. Conditional Expression (if-elif-else)
// -------------------------------------------------------------

let number = 15

let result =
    if number % 2 = 0 then "Even number"
    elif number > 10 then "Odd & Greater than 10"
    else "Odd number"

printfn "\nCondition result: %s" result

// DIFFERENCE:  
// F# uses expressions → every block returns a value.  
// Java/C use statements → they DO, but do not RETURN values.



// -------------------------------------------------------------
// 7. Lists (very common in functional languages)
// -------------------------------------------------------------

let myList = [1; 2; 3; 4; 5]

printfn "\nList Example:"
printfn "List = %A" myList
printfn "Head = %d" myList.Head
printfn "Tail = %A" myList.Tail



// -------------------------------------------------------------
// 8. Tuples (lightweight pairing of values)
// -------------------------------------------------------------

let student = ("Kritika", 21)   // Name + Age

let name, age = student

printfn "\nTuple Example:"
printfn "Name = %s, Age = %d" name age


