import { Router, Request, Response } from "express";
import { getRepository } from "typeorm";
import { Category } from "../entities/Category";

const router: Router = Router();

router.get("/", async (req: Request, res: Response) => {
    const data = await getRepository(Category).find({ relations: [ "forums" ] });
    res.json(data);
});

/*
TODO: add post and push actions, requires auth
*/

export default router;