// ====================================================================
// TASK 9 — Data Querying using F# Query Expressions
// Description:
//   Demonstrates filtering, grouping, and joining using LINQ-style
//   F# query expressions with real-life examples.
// ====================================================================

open System
open Microsoft.FSharp.Linq

// --------------------------------------------------------------------
// SAMPLE DATA
// --------------------------------------------------------------------

type Student =
    { Id: int
      Name: string
      Age: int
      DeptId: int }

type Department =
    { DeptId: int
      DeptName: string }

let students =
    [ { Id = 1; Name = "Kritika"; Age = 21; DeptId = 101 }
      { Id = 2; Name = "Aryan"; Age = 22; DeptId = 102 }
      { Id = 3; Name = "Riya"; Age = 20; DeptId = 101 }
      { Id = 4; Name = "Mehul"; Age = 23; DeptId = 103 }
      { Id = 5; Name = "Sanya"; Age = 22; DeptId = 101 } ]

let departments =
    [ { DeptId = 101; DeptName = "Computer Science" }
      { DeptId = 102; DeptName = "Electronics" }
      { DeptId = 103; DeptName = "Mechanical" } ]


// --------------------------------------------------------------------
// 1. FILTERING — Students above age 21
// --------------------------------------------------------------------

let filteredStudents =
    query {
        for s in students do
        where (s.Age > 21)
        select s
    }

printfn "=== FILTERING: Students Age > 21 ==="
filteredStudents
|> Seq.iter (fun s -> printfn "%s (%d years)" s.Name s.Age)


// --------------------------------------------------------------------
// 2. GROUPING — Students grouped by Department
// --------------------------------------------------------------------

let groupedStudents =
    query {
        for s in students do
        groupBy s.DeptId into g
        select g
    }

printfn "\n=== GROUPING: Students Grouped by DeptId ==="

for group in groupedStudents do
    printfn "Department %d:" group.Key
    group
    |> Seq.iter (fun s -> printfn " - %s" s.Name)


// --------------------------------------------------------------------
// 3. JOIN — Students with their Department Names
// --------------------------------------------------------------------

let studentDeptJoin =
    query {
        for s in students do
        join d in departments on (s.DeptId = d.DeptId)
        select (s.Name, d.DeptName)
    }

printfn "\n=== JOIN: Student → Department ==="

studentDeptJoin
|> Seq.iter (fun (name, dept) ->
    printfn "%s → %s" name dept)


// --------------------------------------------------------------------
// 4. ADVANCED QUERY — Students sorted by Age descending
// --------------------------------------------------------------------

let sortedStudents =
    query {
        for s in students do
        sortByDescending s.Age
        select s
    }

printfn "\n=== SORTING: Students by Age (Desc) ==="
sortedStudents
|> Seq.iter (fun s -> printfn "%s (%d)" s.Name s.Age)


