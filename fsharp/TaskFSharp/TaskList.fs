namespace TaskListFSharp

open System
open System.Collections.Generic
open TaskListFSharp.RealConsole

module TaskList =
    let tasks = Dictionary<string, ResizeArray<Task>>()
    let mutable lastId = 0
    let console = RealConsole()

    let help () =
        console.WriteLine "Commands: "
        console.WriteLine "\t show"
        console.WriteLine "\t add project <project name>"
        console.WriteLine "\t add task <project name> <task description>"
        console.WriteLine "\t check <task ID>"
        console.WriteLine "\t uncheck <task ID>"

    let show () =
        for project in tasks do
            console.WriteLine project.Key

            for task in project.Value do
                let taskDone = if task.Done then "x" else " "
                console.WriteLine $"[{taskDone}] {task.Id}:{task.Description}"

    let addProject projectName = tasks.Add(projectName, ResizeArray<Task>())

    let addTask projectName taskDescription =
        let result, projectTasks = tasks.TryGetValue(projectName)

        if result = false then
            console.WriteLine $"Could not find a project with {projectName}"

        lastId <- lastId + 1

        projectTasks.Add(
            { Id = lastId
              Description = taskDescription
              Done = false }
        )


    let updateTask id state tasks =
         tasks |> List.map (fun (x:Task) ->
             if x.Id = id then {x with Done = state} else x) |> ResizeArray
    let check taskId =
        let taskIdInt = Int32.Parse taskId
        let projects = tasks.Keys

        projects |> Seq.iter(fun x -> tasks.[x] <- updateTask taskIdInt true (tasks.[x] |> Seq.toList))

    let uncheck taskId =
        let taskIdInt = Int32.Parse taskId
        let projects = tasks.Keys

        projects |> Seq.iter(fun x -> tasks.[x] <- updateTask taskIdInt false (tasks.[x] |> Seq.toList))


    let error command =
        console.WriteLine $"I don't know what the command {command} is."

    let add (command: string) =
        let subcommandRest = command.Split(" ", 2)
        let subcommand = subcommandRest.[0]

        if subcommand = "project" then
            addProject subcommandRest.[1]
        else if subcommand = "task" then
            let projectTask = subcommandRest.[1].Split(" ", 2)
            addTask projectTask.[0] projectTask.[1]

        ()

    let execute (commandLine: string) =
        let commandRest = commandLine.Split(" ", 2)
        let command = commandRest.[0]

        if command = "help" then
            help ()
        else if command = "add" then
            add commandRest.[1]
        else if command = "check" then
            check commandRest.[1]
        else if command = "uncheck" then
            uncheck commandRest.[1]
        else if command = "show" then
            show ()
        else
            error command

    let mutable continueLooping = true

    let write () =
        while continueLooping do
            console.Write " >"
            let command = console.ReadLine()

            if command = "quit" then
                continueLooping <- false
            else
                execute command

(*
thoughts:
    1. block comments in F# use (* and *) instead of /* */
    2. trying to rewrite mutable code to F# isn't easy but that's great! It forces you to try better
    3. C# List is not the same as F# list, it's ResizeArray!
*)