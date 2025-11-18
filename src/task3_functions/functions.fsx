// ====================================================================
// TASK 3 — Functions in F#
// Description:
//   Demonstrates basic functions, recursive functions,
//   higher-order functions, and currying with simple examples.
// ====================================================================



// -------------------------------------------------------------
// 1. BASIC FUNCTION — Real-life Example: Calculate Discount
// -------------------------------------------------------------

let calculateDiscount price =
    price * 0.10   // 10% discount

let price = 500.0
printfn "Basic Function: 10%% discount on %.1f = %.1f" price (calculateDiscount price)

// DIFFERENCE:
// In C/Java → function parameters must have parentheses.
// In F# → calculateDiscount 500.0   (clean, functional style)



// -------------------------------------------------------------
// 2. FUNCTION WITH MULTIPLE PARAMETERS
// -------------------------------------------------------------

let addNumbers a b =
    a + b

printfn "Add 10 + 20 = %d" (addNumbers 10 20)



// -------------------------------------------------------------
// 3. RECURSIVE FUNCTION — Real-life Example: Factorial
// -------------------------------------------------------------

let rec factorial n =
    if n <= 1 then 1
    else n * factorial (n - 1)

printfn "Factorial 5 = %d" (factorial 5)

// DIFFERENCE:
// F# uses 'rec' keyword to enable recursion.



// -------------------------------------------------------------
// 4. RECURSIVE FUNCTION — Fibonacci Series
// -------------------------------------------------------------

let rec fib n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> fib (n - 1) + fib (n - 2)

printfn "Fibonacci(7) = %d" (fib 7)


// -------------------------------------------------------------
// 5. HIGHER-ORDER FUNCTION — Real-life Example: Apply Tax
// -------------------------------------------------------------

// A higher-order function is a function that takes another function as input.

let applyTax amount taxFunction =
    taxFunction amount

let gst amount = amount * 0.18
let serviceTax amount = amount * 0.10

printfn "\nHigher-Order Function:"
printfn "GST on 1000 = %.2f" (applyTax 1000.0 gst)
printfn "Service Tax on 1000 = %.2f" (applyTax 1000.0 serviceTax)

// DIFFERENCE:
// In Java/C → passing functions needs interfaces or delegates.
// In F# → functions are FIRST-CLASS values.



// -------------------------------------------------------------
// 6. HIGHER-ORDER FUNCTION — Using List.map
// -------------------------------------------------------------

let numbers = [1; 2; 3; 4; 5]
let doubled = List.map (fun x -> x * 2) numbers

printfn "\nDoubled numbers = %A" doubled



// -------------------------------------------------------------
// 7. CURRYING — Real-life Example: Grocery Billing
// -------------------------------------------------------------

// A curried function takes one parameter at a time.

let addItem price quantity =
    price * float quantity

// Curried version by partial application
let priceOfApple = addItem 40.0   // only price fixed
let priceOfBanana = addItem 10.0

printfn "\nCurrying (Partial Application):"
printfn "Apples (40 each) for 3 qty = %.1f" (priceOfApple 3)
printfn "Bananas (10 each) for 6 qty = %.1f" (priceOfBanana 6)



// -------------------------------------------------------------
// 8. CURRIED FUNCTION DEFINITION
// -------------------------------------------------------------

let multiply a b =
    a * b      // This is automatically curried in F#

let mulBy5 = multiply 5   // Now b is pending

printfn "\nMultiply 5 with 8 = %d" (mulBy5 8)

