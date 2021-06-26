import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);

        this.state = { categories: [], loading: true };
	}

    componentDidMount() {
        this.fetchCategories();
    }

    static FormatCategories(categories) {
        return (
            <table className="table">
                {categories.map(category =>
                    <>
                        <thead><tr key={"c" + category.id.toString()}><th> {category.title}</th></tr></thead>
                    <tbody>
                        {category.forums.map(forum =>
                            <tr><td key={"f" + forum.id.toString()}>{forum.title}</td></tr>
                        )}
                    </tbody></>
                )}
            </table>
        );
    }

    render() {
        if (this.state.loading)
            return (<p>Loading...</p>);

        return Home.FormatCategories(this.state.categories);
	}

    async fetchCategories() {
        const response = await fetch("api/categories");
        console.log(response);
        const data = await response.json();
        this.setState({ categories: data, loading: false });
	}
}
