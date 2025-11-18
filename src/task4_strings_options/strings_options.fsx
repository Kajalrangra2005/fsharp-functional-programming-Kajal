// ====================================================================
// TASK 4 — Strings, Options, and Immutable Data
// Description:
//   Demonstrates string operations, F# Option type, and
//   immutable collections with real-life examples.
// ====================================================================



// -------------------------------------------------------------
// 1. STRING OPERATIONS
// -------------------------------------------------------------

let name = "Kritika"
let college = "KRMU"
let course = "F# Programming"

// Concatenation
let intro = name + " from " + college
printfn "Concatenation: %s" intro

// String interpolation
let intro2 = $"Hello, I am {name} and I study {course}."
printfn "Interpolation: %s" intro2

// Length
printfn "Length of name = %d" (name.Length)

// Substring
printfn "First 3 letters: %s" (name.Substring(0, 3))

// Replace
let updatedCourse = course.Replace("F#", "Functional")
printfn "Updated Course Name: %s" updatedCourse

// ToUpper / ToLower
printfn "Uppercase: %s" (name.ToUpper())
printfn "Lowercase: %s" (name.ToLower())



// -------------------------------------------------------------
// 2. OPTION TYPE
// -------------------------------------------------------------
// Option prevents null errors by wrapping values in Some or None.
// Very useful in safe programming.

let tryDivide a b =
    if b = 0 then None
    else Some(a / b)

let result1 = tryDivide 10 2
let result2 = tryDivide 10 0

printfn "\nOption Type Example:"

match result1 with
| Some value -> printfn "10 / 2 = %d" value
| None -> printfn "Cannot divide by zero."

match result2 with
| Some value -> printfn "10 / 0 = %d" value
| None -> printfn "Cannot divide by zero (handled safely)."

// DIFFERENCE:
// In F#, Option avoids runtime null pointer errors.
// In C/Java → null can crash program.


// Another real-life example: find student by ID
let getStudentName id =
    match id with
    | 101 -> Some "Kritika"
    | 102 -> Some "Aryan"
    | _ -> None

match getStudentName 101 with
| Some name -> printfn "Student found: %s" name
| None -> printfn "Student not found."

match getStudentName 999 with
| Some name -> printfn "Student found: %s" name
| None -> printfn "Student not found."



// -------------------------------------------------------------
// 3. IMMUTABLE COLLECTIONS
// -------------------------------------------------------------
// Most F# collections (List, Array, Seq) are immutable by default.

let cities = [ "Delhi"; "Gurgaon"; "Noida" ]   // Immutable List

printfn "\nImmutable List:"
printfn "Cities = %A" cities

// Trying to 'modify' actually returns a NEW list
let newCities = "Mumbai" :: cities

printfn "After adding Mumbai → new list = %A" newCities
printfn "Original list still unchanged = %A" cities


// Immutable Array
let marks = [| 85; 90; 92 |]
let updatedMarks = Array.append marks [| 95 |]

printfn "\nArray Example:"
printfn "Original: %A" marks
printfn "Updated: %A" updatedMarks


// Immutable Map (key-value store)
let studentAges =
    Map [
        ("Kritika", 21)
        ("Aryan", 22)
        ("Riya", 20)
    ]

printfn "\nImmutable Map:"
printfn "Kritika's age = %d" studentAges["Kritika"]

let updatedMap = studentAges.Add("Rahul", 23)

printfn "After adding Rahul = %A" updatedMap



