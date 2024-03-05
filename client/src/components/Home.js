import "./Home.css"
import "../index.css"
//import ChoreChart from "../images/ChoreChart.jpg"

export const Home = () => {
    return (
        <div className="home">
            {/* <div className="image" style={{ backgroundImage: `url(${ChoreChart})` }}></div> */}
            <div className="header">
                <h2>Welcome to Fit Track Pro</h2>
                <h5>Fit Track Pro allows you to track your workouts and make your own program</h5>
            </div>
        </div>
    )
}