open System

let goldenRatio = (1.0 + Math.Sqrt(5.0))/2.0
let calculateRatio x = x*goldenRatio
let isNumber x = 
    let mutable valid = true
    for c in x do
        if (Char.IsDigit(c) = false) then
           valid <- false
    valid

[<EntryPoint>]
let main argv = 

    let ratios =
        [ let mutable run = true
          while run do
            
            Console.WriteLine(":Enter value: ")
            let value = Console.ReadLine()
            if isNumber value then
                yield (float value, calculateRatio(float value))
            else
                Console.WriteLine("Invalid Number!")
            Console.WriteLine("Do your want to add another value (y/n)?")
            if Console.ReadLine().ToLower() <> "y" then
                run <- false]


    Console.WriteLine("\nResults:")
    for x in ratios do
        let v,r = x
        Console.WriteLine("Value: {0:0.00}     Result: {1:0.00}", v, r)

    Console.ReadLine()
    0 // return an integer exit code