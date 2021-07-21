import React, { Component } from "react";
import { Navbar } from "react-bootstrap";

export class Layout extends Component {
    static diplayName = Layout.name;

    render(){
        return (
            <div className="page">
                <Navbar className="top-row pl-4">
                    <a className="navbar-brand" href="">WebForums</a>
                </Navbar>

                <div className="content px-4">
                    {this.props.children}
                </div>
            </div>
        );
    }
}