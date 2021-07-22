import { Entity, PrimaryGeneratedColumn, Column, OneToMany } from "typeorm";
import { Forum } from "./Forum";

@Entity()
export class Category {
    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    title: string;

    @OneToMany(() => Forum, forum => forum.category)
    forums: Forum[];
}