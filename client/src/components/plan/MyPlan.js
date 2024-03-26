import { useState } from "react"


export const MyPlan = () => {
 const [name, setName] = useState("")
 const [user, setUser] = useState("") // is this correct??
}
    //my plan component will have a flexbox style list of the workouts the user added to their plan
    //the plan will be broken down by day: Mon = leg day, Tues = rest, etc
    //when the user clicks on the day, it will take them to the detailed plan including the specified workout for that day