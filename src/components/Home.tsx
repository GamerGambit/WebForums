import React, { Component } from "react";

interface IHomeState {
    categories: [{}];
    loading: boolean;
}

export class Home extends Component<{}, IHomeState> {
    static displayName = Home.name;

    constructor(props) {
        super(props);

        this.state = {
            categories: [{}],
            loading: true
        };
    }

    componentDidMount() {
        this.fetchCategories();
    }

    static FormatCategories(categories) {
        return (
            categories.map((category, index) =>
                <table className="table-bordered mb-2" key={index}>
                    <thead>
                        <tr>
                            <th colSpan={2}>{category.title}</th>
                        </tr>
                    </thead>

                    <tbody>
                        {category.forums.map((forum, index) =>
                            <tr key={index}>
                                <td>
                                    <p className="p-0 m-0">{forum.title}</p>
                                    <small className="text-muted">{forum.description}</small>
                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>
            )
        );
    }

    render() {
        if (this.state.loading)
            return (<p>Loading...</p>);

        return Home.FormatCategories(this.state.categories);
    }

    async fetchCategories() {
        const data = await fetch("/api/categories").then(r => r.json());
        this.setState({ categories: data, loading: false });
    }
}