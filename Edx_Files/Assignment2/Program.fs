open System

//- Function to check if the number of people is valid
let isvalidnumberpeople number_people  =
    let mutable valid = true
    for c in number_people do
        if (Char.IsDigit(c) = false) then
           valid <- false
    if (valid) then
        let rangeCheck = int number_people
        if (rangeCheck < 1 || rangeCheck > 100) then
            valid <- false
    valid

//- Function to check if the name is valid
let isvalidname name = 
    let mutable valid = true
    for c in name do
        if (Char.IsLetter(c) = false && Char.IsSeparator(c) = false && Char.IsWhiteSpace(c) = false) then
            valid <- false
    valid

//- Function to check if the age is valid
let isvalidage age =
    let mutable valid = true
    for c in age do
        if (Char.IsDigit(c) = false) then
           valid <- false
    if (valid) then
        let rangeCheck = int age
        if (rangeCheck < 0 || rangeCheck > 130) then
            valid <- false
    valid


//- Main Entry Point
//- Allow the user to decide when to quit the program by entering 'q' 

[<EntryPoint>]
let main argv = 

    let mutable running = true
    while (running) do

    
        let mutable person_count = 0
        let person_name = Array.create 100 ""
        let person_age = Array.create 100 0

        //- Get the number of people to process - Maximum = 100
        Console.Write("Enter Number of People: ")
        let number_people = Console.ReadLine()

        //- Enter Person Infomation if the number of people is valid
        //- Check the validity of the name and age of the person
        if (isvalidnumberpeople number_people) then
            
            let number_people = int number_people

            while (person_count < number_people) do
                Console.Write("Enter Name of Person: ")
                let name = Console.ReadLine()
            
                if (isvalidname name) then
                    Console.Write("Enter Age of Person: ")
                    let age = Console.ReadLine()
                
                    if (isvalidage age) then
                        let age = int age
                        person_name.SetValue(name,person_count)
                        person_age.SetValue(age,person_count)
                        person_count <- person_count + 1
                    else
                        Console.WriteLine("****Invalid Age Entered!!")
                else
                    Console.WriteLine("****Invalid Name Entered!!")
        else
            Console.WriteLine("****Invalid Number of People Entered!!")

        //- Once we have all the information output the information to the Console
        if (isvalidnumberpeople number_people) then
            if (person_count = int number_people && int number_people > 0) then
                Console.WriteLine("\n\nNames and Ages of People Entered:\n")
                for i=0 to int number_people - 1 do
                    let theage = int32(person_age.GetValue(i).ToString())
                    if (theage > 20) then
                        Console.WriteLine(person_name.GetValue(i).ToString() + " is an Adult")
                    elif (theage < 20 && theage >= 13) then
                        Console.WriteLine(person_name.GetValue(i).ToString() + " is a Teenager")
                    else
                        Console.WriteLine(person_name.GetValue(i).ToString() + " is a Child")

        Console.WriteLine("\n\nPress Any Key to Continue, Press 'q' to quit...")
        let option = Console.ReadLine()
        if (option = "q") then
            running <- false
    0 // return an integer exit code
