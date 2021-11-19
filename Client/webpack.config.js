const path = require("path");
const ExtractTextPlugin = require("extract-text-webpack-plugin");
module.exports = {
    entry: './index.js',
    mode: "development",
    output: {
        path: path.resolve(__dirname, 'wwwroot/site'),
        filename: "bundle.js"
    },
    module: {
        rules: [
            {
                test: /\.(png|jpe?g|gif|ttf|eot|svg|gif|woff|woff2)$/i,
                loader: 'file-loader',
                options: {
                    name(file) {
                        return '[path][name].[ext]'
                    },
                    publicPath: '/assets/images/',
                    outputPath: '../assets/images/'
                },
            },
            {
                test: /\.(css)?$/,
                use: ExtractTextPlugin.extract({
                    fallback: "style-loader",
                    use: "css-loader"
                })
            }
        ]
    },
    plugins: [
        new ExtractTextPlugin("styles.css"),
    ]
};