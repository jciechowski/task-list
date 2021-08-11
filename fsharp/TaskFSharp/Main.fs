module TaskListFSharp.main

open TaskListFSharp

module TaskList =
    [<EntryPoint>]
    let main args =
        TaskList.write()
        0