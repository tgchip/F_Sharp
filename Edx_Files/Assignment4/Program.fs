open System
open System.IO

type Target = 
    {
        X : float
        Y : float 
        Speed : float
        Distance : float
        Name : string
    }


(* Helper Functions*)
let angle_of_reach distance speed = 0.5*Math.Asin((9.81*distance)/(speed*speed))
let angle x y = Math.Atan2(y,x)
let distance_travelled speed angle = (speed*speed)*Math.Sin(2.0*angle)/9.81

(* Helper Function to get the file name*)
let GetFile = 
    Console.Write("Enter the full path to the name of the input file: ")
    Console.ReadLine()

[<EntryPoint>]
let main argv = 

    try
        (* Read the data from the file *)
        use input =
            new StreamReader(match argv.Length with
                             | 0 -> GetFile    
                             | _ -> argv.[0])

        let targets =
            [ while not input.EndOfStream do
                  let raw = input.ReadLine()
                  let values = raw.Split(',')
                  yield { X = float values.[0]
                          Y = float values.[1]
                          Speed = float values.[2]
                          Distance = float values.[3]
                          Name = values.[4] } ]

        (* Loop through all the targets and determine if it hit the target *)
        for t in targets do
            match t with
            | { Speed=s; Distance=d; Name=n} when (9.81*d)/(s*s) > 1.0 -> Console.WriteLine("Gun {0} Target Unreachable",n)
            | { X=x; Y=y; Speed=s; Distance=d; Name=n } when 
                (distance_travelled s (angle x y))<>d -> 
                Console.WriteLine("Gun {0} Missed - Change Angle By: {1:0.00}", n, (angle_of_reach d s) - (angle x y))
            | { X=x; Y=y; Speed=s; Distance=d; Name=n} when (distance_travelled s (angle x y))=d -> Console.WriteLine("Gun {0} Hit", n)
            | _ -> Console.WriteLine("Error!!!")
        Console.ReadLine()
        0
    with
    | :? System.IO.FileNotFoundException ->
        Console.Write("File Not Found. Press a key to exit")
        Console.ReadKey()
        -1
    | _ ->
        Console.Write("Something else happened")
        Console.ReadKey()
        -1