import React, { Component } from 'react';
import { Link } from 'react-router-dom';

/*
 * This component represents a single "Category".
 * The data can be sourced in 3 ways:
 * 1: Passed in as the `category` prop.
 * 2: Passed in via Link state.
 * 3: Fetched from /api/categories/:id
 */
export class Category extends Component {
    static displayName = Category.name;

    constructor(props) {
        super(props);

        this.state = { category: [], loading: true };

        if (this.props.category) {
            this.state.category = this.props.category;
            this.state.loading = false;
        }
        else if (this.props.location && this.props.location.state && this.props.location.state.category) {
            this.state.category = this.props.location.state.category;
            this.state.loading = false;
		}
    }

    componentDidMount() {
        this.fetchForums();
    }

    static FormatForums(category) {
        return (
            <table className="table-bordered mb-2">
                <thead>
                    <tr>
                        <th><Link to={{ pathname: "/category/" + category.id, state: { category } }}>{category.title}</Link></th>
                    </tr>
                </thead>

                <tbody>
                    {category.forums.map((forum, index) =>
                        <tr key={index}>
                            <td key={index}>
                                <p className="p-0 m-0">{forum.title}</p>
                                <small className="text-muted">{forum.description}</small>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        if (this.state.loading)
            return (<p>Loading...</p>);

        return Category.FormatForums(this.state.category);
    }

    async fetchForums() {
        if (!this.state.loading)
            return;

        const response = await fetch("api/categories/" + this.props.match.params.id);
        const data = await response.json();
        this.setState({ category: data, loading: false });
    }
}
