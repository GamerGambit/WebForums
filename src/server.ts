import * as express from "express";
import { createConnection } from "typeorm"
import * as path from "path"

const app = express();
app.use(express.json());

createConnection()
	.then(() => console.log("Connected to database."))
	.catch(reason => {
		console.log("Connection to database failed: " + reason);
		process.exit(1);
	});
app.use(express.static(path.join(__dirname, "../public")))
app.get("*", (req, res) => res.sendFile(path.resolve(__dirname, "../public/index.html")));

app.listen(3000, () => console.log("Server listening on port 3000."));
