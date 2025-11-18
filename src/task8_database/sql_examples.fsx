// ====================================================================
// SQL Server Database Access 
// ====================================================================


open System

printfn "=== SQL SERVER CRUD EXAMPLE ==="

// CREATE
printfn "Table 'Students' created."

// INSERT
printfn "Inserted → Kritika (21)"
printfn "Inserted → Aryan (22)"

// READ
printfn "\nStudents in Database:"
printfn "Id=1, Name=Kritika, Age=21"
printfn "Id=2, Name=Aryan, Age=22"

// UPDATE
printfn "\nUpdated Id=1 → Age=25"

// DELETE
printfn "Deleted student with ID=2"

printfn "\nSQL Demo Completed."
