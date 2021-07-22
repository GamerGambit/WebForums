import * as express from "express";
import { createConnection } from "typeorm"
import * as path from "path"

const app = express();
app.use(express.json());

createConnection({
		type: "mysql",
		host: "192.168.0.5",
		port: 6603,
		username: "root",
		password: "root",
		database: "webforums",
		entities: [ path.join(__dirname, "../bin/entities/**/*.js")],
		migrations: [ "./migrations/**/*.ts" ],
		cli: {
			migrationsDir: "./src/migrations",
			entitiesDir: "./src/entities"
		},
		logging: true,
		synchronize: false
	})
	.then(() => console.log("Connected to database."))
	.catch(reason => {
		console.log("Connection to database failed: " + reason);
		process.exit(1);
	});
app.use(express.static(path.join(__dirname, "../dist")));
app.get("*", (req, res) => res.sendFile(path.resolve(__dirname, "../dist/index.html")));

app.listen(3000, () => console.log("Server listening on port 3000."));
