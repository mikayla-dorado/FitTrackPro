import { useState } from "react"


export const Workout = () => {
    const [name, setName] = useState({})
    const [workoutType, setWorkoutType] = useState({})
    const [plan, setPlan] = useState("")
}
//this will display a list of workouts available in flexbox style
    //each workout will include an image, the name of the workout and the type (upper body, lower, etc)
    //an 'add to plan' btn will be available so a user can add that workout to their own plan

    //?
    //workouts have a name, workoutTypesId, and planId