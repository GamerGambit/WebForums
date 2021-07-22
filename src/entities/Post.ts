import { Entity, PrimaryGeneratedColumn, Column, ManyToOne, OneToMany } from "typeorm";
import { Thread } from "./Thread";
import { User } from "./User";

@Entity()
export class Post {
    @PrimaryGeneratedColumn()
    id: number;

    @ManyToOne(() => Thread, thread => thread.posts)
    thread: Thread;

    @Column()
    content: string;

    @ManyToOne(() => User, user => user.posts)
    poster: User;

    @Column()
    created: Date;

    @Column()
    updated: Date;

}