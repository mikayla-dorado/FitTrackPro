import { useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {
    Button,
    Collapse,
    Nav,
    NavLink,
    NavItem,
    Navbar,
    NavbarBrand,
    NavbarToggler,
} from "reactstrap";
import { logout } from "../managers/authManager";
import "./NavBar.css"

export default function NavBar({ loggedInUser, setLoggedInUser }) {
    const [open, setOpen] = useState(false);

    const toggleNavbar = () => setOpen(!open);


    return (
        <div>
            <Navbar className="navbar"  light fixed="true" expand="lg">
                <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
                    Fit Track Pro
                </NavbarBrand>
                {loggedInUser ? (
                    <>
                        <NavbarToggler onClick={toggleNavbar} />

                        <Collapse isOpen={open} navbar>
                            <Nav navbar>
                            <NavItem onClick={() => setOpen(false)}>
                                    
                                    <NavLink tag={RRNavLink} to="/workouts">
                                        Workouts
                                    </NavLink>
                            </NavItem>
                            <NavItem onClick={() => setOpen(false)}>
                                    
                                    <NavLink tag={RRNavLink} to="/myplan">
                                        My Plan
                                    </NavLink>
                            </NavItem>
                            </Nav>
                        </Collapse>
                        <Button
                        className="logout"
                            
                            onClick={(e) => {
                                e.preventDefault();
                                setOpen(false);
                                logout().then(() => {
                                    setLoggedInUser(null);
                                    setOpen(false);
                                });
                            }}
                        >
                            Logout
                        </Button>
                    </>
                ) : (
                    <Nav navbar>
                        <NavItem>
                            <NavLink tag={RRNavLink} to="/login">
                                <Button color="primary">Login</Button>
                            </NavLink>
                        </NavItem>
                    </Nav>
                )}
            </Navbar>
        </div>
    );
}