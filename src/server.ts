import * as express from "express";
import { createConnection } from "typeorm"

const app = express();
app.use(express.json());

createConnection()
	.then(() => console.log("Connected to database."))
	.catch(reason => {
		console.log("Connection to database failed: " + reason);
		process.exit(1);
	});

app.get("*", (req, res) => res.status(200).json("success"));

app.listen(3000, () => console.log("Server listening on port 3000."));
