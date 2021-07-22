import {MigrationInterface, QueryRunner} from "typeorm";

export class Initial1626971520395 implements MigrationInterface {
    name = 'Initial1626971520395'

    public async up(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query("CREATE TABLE `post` (`id` int NOT NULL AUTO_INCREMENT, `content` varchar(255) NOT NULL, `created` datetime NOT NULL, `updated` datetime NOT NULL, `threadId` int NULL, `posterId` int NULL, PRIMARY KEY (`id`)) ENGINE=InnoDB");
        await queryRunner.query("CREATE TABLE `user` (`id` int NOT NULL AUTO_INCREMENT, `username` varchar(255) NOT NULL, PRIMARY KEY (`id`)) ENGINE=InnoDB");
        await queryRunner.query("CREATE TABLE `thread` (`id` int NOT NULL AUTO_INCREMENT, `title` varchar(255) NOT NULL, `forumId` int NULL, `starterId` int NULL, PRIMARY KEY (`id`)) ENGINE=InnoDB");
        await queryRunner.query("CREATE TABLE `forum` (`id` int NOT NULL AUTO_INCREMENT, `title` varchar(255) NOT NULL, `description` varchar(255) NOT NULL, `categoryId` int NULL, PRIMARY KEY (`id`)) ENGINE=InnoDB");
        await queryRunner.query("CREATE TABLE `category` (`id` int NOT NULL AUTO_INCREMENT, `title` varchar(255) NOT NULL, PRIMARY KEY (`id`)) ENGINE=InnoDB");
        await queryRunner.query("ALTER TABLE `post` ADD CONSTRAINT `FK_b148d2f5a22e7904160c69b09f8` FOREIGN KEY (`threadId`) REFERENCES `thread`(`id`) ON DELETE NO ACTION ON UPDATE NO ACTION");
        await queryRunner.query("ALTER TABLE `post` ADD CONSTRAINT `FK_fd91f9bffb081d0f822ea655985` FOREIGN KEY (`posterId`) REFERENCES `user`(`id`) ON DELETE NO ACTION ON UPDATE NO ACTION");
        await queryRunner.query("ALTER TABLE `thread` ADD CONSTRAINT `FK_ae78b49aab1b25526cfc55921f0` FOREIGN KEY (`forumId`) REFERENCES `forum`(`id`) ON DELETE NO ACTION ON UPDATE NO ACTION");
        await queryRunner.query("ALTER TABLE `thread` ADD CONSTRAINT `FK_06cd940e729681c4a58e4dc01a2` FOREIGN KEY (`starterId`) REFERENCES `user`(`id`) ON DELETE NO ACTION ON UPDATE NO ACTION");
        await queryRunner.query("ALTER TABLE `forum` ADD CONSTRAINT `FK_48caa8bf665a6b06d78f8e6aa0f` FOREIGN KEY (`categoryId`) REFERENCES `category`(`id`) ON DELETE NO ACTION ON UPDATE NO ACTION");
    }

    public async down(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query("ALTER TABLE `forum` DROP FOREIGN KEY `FK_48caa8bf665a6b06d78f8e6aa0f`");
        await queryRunner.query("ALTER TABLE `thread` DROP FOREIGN KEY `FK_06cd940e729681c4a58e4dc01a2`");
        await queryRunner.query("ALTER TABLE `thread` DROP FOREIGN KEY `FK_ae78b49aab1b25526cfc55921f0`");
        await queryRunner.query("ALTER TABLE `post` DROP FOREIGN KEY `FK_fd91f9bffb081d0f822ea655985`");
        await queryRunner.query("ALTER TABLE `post` DROP FOREIGN KEY `FK_b148d2f5a22e7904160c69b09f8`");
        await queryRunner.query("DROP TABLE `category`");
        await queryRunner.query("DROP TABLE `forum`");
        await queryRunner.query("DROP TABLE `thread`");
        await queryRunner.query("DROP TABLE `user`");
        await queryRunner.query("DROP TABLE `post`");
    }

}
