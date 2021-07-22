import { Entity, PrimaryGeneratedColumn, Column, OneToMany } from "typeorm";
import { Thread } from "./Thread";
import { Post } from "./Post";

@Entity()
export class User {
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    username: string;

    @OneToMany(() => Thread, thread => thread.starter)
    threads: Thread[];

    @OneToMany(() => Post, post => post.poster)
    posts: Post[];
}