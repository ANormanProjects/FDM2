 -- DELETE ALL TABLES (FOR THE LOVE OF GOD DONT RUN THESE)
 -- DROP TABLE __MigrationHistory;
 -- DROP TABLE Comments;
 -- DROP TABLE Posts;
 -- DROP TABLE Users;
 -- DROP TABLE Groups;
 
 
 --	DELETE ENTRIES FROM DATABASE (Not Tables)
 -- DELETE FROM Comments
 -- DELETE FROM Posts
 -- DELETE FROM Users
 -- DELETE FROM Groups

 -- RESEED PRIMARY KEY VALUES (START FROM 0 AGAIN)
 DBCC CHECKIDENT (Users, RESEED, 0)
 DBCC CHECKIDENT (Comments, RESEED, 0)
 DBCC CHECKIDENT (Posts, RESEED, 0)
 DBCC CHECKIDENT (Groups, RESEED, 0)


 -- Populate Users
INSERT INTO Users(username, password, fullName, gender)
VALUES ('snewton', 'password', 'Spencer Newton', 'Male');
INSERT INTO Users(username, password, fullName, gender)
VALUES ('bmeghani', 'password', 'Bishan Meghani', 'Male');
INSERT INTO Users(username, password, fullName, gender)
VALUES ('skhan', 'password', 'Suleman Khan', 'Male');
INSERT INTO Users(username, password, fullName, gender)
VALUES ('anorman', 'password', 'Andrew Norman', 'Male');
INSERT INTO Users(username, password, fullName, gender)
VALUES ('mreid', 'password', 'Mario Reid', 'Male');
INSERT INTO Users(username, password, fullName, gender)
VALUES ('dmason', 'password', 'Daniel Mason', 'Male');
INSERT INTO Users(username, password, fullName, gender)
VALUES ('bbowes', 'password', 'Benjamin Bowes', 'Male');

 -- Populate Posts
INSERT INTO Posts(time, likes, title, user_userId, Discriminator) VALUES (GETDATE(), 10, 'I Love C#', 1, 'UserPost');
SELECT postId, time, likes, title, language, content, Discriminator FROM Posts;

 -- Populate Comments
INSERT INTO Comments(content, post_postId, user_userId) VALUES ('That was so funny haha lol - Bish', 1, 2);
SELECT commentId, content, post_postId, user_userId FROM Comments;

 -- Populate Groups
 INSERT INTO Groups(groupName, owner_userId) VALUES ('Cerf Squad', 1);
 SELECT groupID, groupName, owner_userId FROM Groups;