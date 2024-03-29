import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { Home } from "./Home"
import { MyPlan } from "./plan/MyPlan"
import { Workout } from "./workout/Workout"


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={<AuthorizedRoute loggedInUser={loggedInUser}>
            <Home />
          </AuthorizedRoute>
          }
        />
        <Route
        index 
        element={<AuthorizedRoute loggedInUser={loggedInUser}>
          <Workout />
        </AuthorizedRoute>
        }
        />
        <Route
        index 
        element={<AuthorizedRoute loggedInUser={loggedInUser}>
          <MyPlan />
        </AuthorizedRoute>
        }
        />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}