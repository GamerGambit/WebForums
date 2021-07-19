module.exports = {
    devtool: "source-map",
    entry: "./src/client.jsx",
    mode: "development",
    output: {
        path: __dirname + "/public",
        filename: "./app-bundle.js"
    },
    resolve: {
        extensions: [ ".js", ".jsx" ]
    },
    module: {
        rules: [
            {
                test: /\.tsx?/,
                exclude: /(node_modules|bower_components)/,
                use: "ts-loader"
            },
            {
                test: /\.jsx?/,
                exclude: /(node_modules|bower_components)/,
                use: "babel-loader"
            }
        ]
    }
}