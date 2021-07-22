import { Entity, PrimaryGeneratedColumn, Column, ManyToOne, OneToMany } from "typeorm"
import { Category } from "./Category";
import { Thread } from "./Thread";

@Entity()
export class Forum {
    @PrimaryGeneratedColumn()
    id: number;

    @ManyToOne(() => Category, category => category.forums)
    category: Category;

    @Column()
    title: string;

    @Column()
    description: string;

    @OneToMany(() => Thread, thread => thread.forum)
    threads: Thread[];
}