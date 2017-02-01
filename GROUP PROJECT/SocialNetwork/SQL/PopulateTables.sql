 -- DELETE ALL TABLES (FOR THE LOVE OF GOD DONT RUN THESE)
 -- DROP TABLE __MigrationHistory;
 -- DROP TABLE Comments;
 -- DROP TABLE Posts;
 -- DROP TABLE Users;
 -- DROP TABLE Groups;
 -- DROP TABLE UserFriends
 -- DROP TABLE UserGroups
 
 
 --	DELETE ENTRIES FROM DATABASE (Not Tables)
DELETE FROM Comments
DELETE FROM Posts
DELETE FROM Groups
DELETE FROM Users
DELETE FROM UserFriends
DELETE FROM UserGroups

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

SELECT userId, username, fullName, gender FROM Users

 -- Populate User-Friends
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 6);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (1, 7);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 6);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (2, 7);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 6);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (3, 7);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 6);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (4, 7);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 6);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (5, 7);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (6, 7);

INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 1);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 2);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 3);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 4);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 5);
INSERT INTO UserFriends(UserRefId, FriendRefId) VALUES (7, 6);

SELECT U1.username, U2.username FROM UserFriends
INNER JOIN Users U1 ON U1.userId = UserRefId
INNER JOIN Users U2 ON U2.userId = FriendRefId;

 -- Populate Groups
INSERT INTO Groups(groupName, owner_userId) VALUES ('Cerf Squad', 1);

SELECT groupID, groupName, owner_userId FROM Groups;

 -- Populate User-Groups
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 1);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 2);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 3);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 4);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 5);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 6);
INSERT INTO UserGroups(GroupRefId, UserRefId) VALUES (1, 7);

SELECT G.groupName, U.username FROM UserGroups
INNER JOIN Users U ON U.userId = UserRefId
INNER JOIN Groups G ON G.groupId = GroupRefId;

 -- Populate Posts
INSERT INTO Posts(time, likes, title, user_userId, Discriminator) VALUES (GETDATE(), 10, 'I Love C#', 1, 'UserPost');
INSERT INTO Posts(time, likes, title, group_groupId, Discriminator) VALUES (GETDATE(), 20, 'I Despise C#', 1, 'GroupPost');

SELECT postId, time, likes, title, language, content, Discriminator, group_groupID, user_userId FROM Posts;



 -- Populate Comments
INSERT INTO Comments(content, post_postId, user_userId) VALUES ('That was so funny haha lol - Bish', 1, 2);
INSERT INTO Comments(content, post_postId, user_userId) VALUES ('That wasnt funny :(', 2, 1);

SELECT commentId, content, post_postId, user_userId FROM Comments;