import React, { Component } from 'react';
import { Category } from './Category';

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
            categories.map((category, index) =>
                <Category category={category} key={index} />
            )
        );
    }

    render() {
        if (this.state.loading)
            return (<p>Loading...</p>);

        return Home.FormatCategories(this.state.categories);
	}

    async fetchCategories() {
        const response = await fetch("api/categories");
        const data = await response.json();
        this.setState({ categories: data, loading: false });
	}
}
