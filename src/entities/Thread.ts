import { Entity, PrimaryGeneratedColumn, Column, ManyToOne, OneToMany } from "typeorm";
import { Forum } from "./Forum";
import { User } from "./User";
import { Post } from "./Post";

@Entity()
export class Thread {
    @PrimaryGeneratedColumn()
    id: number;

    @ManyToOne(() => Forum, forum => forum.threads)
    forum: Forum;

    @Column()
    title: string;

    @ManyToOne(() => User, user => user.threads)
    starter: User;

    @OneToMany(() => Post, post => post.thread)
    posts: Post[];
}