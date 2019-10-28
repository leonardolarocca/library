import React from 'react'
import { Nav, Navbar } from 'react-bootstrap'

export default function Navigation () {
    return(
        <div>
            <Navbar bg="light">
                <Navbar.Brand href="#home">My Library</Navbar.Brand>
                <Nav>
                    <Nav.Link>Books</Nav.Link>
                </Nav>
            </Navbar>
        </div>
    );
}